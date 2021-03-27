using Akka.Actor;
using Akka.Configuration;
using ChatFlow.Dialog.Api.Extensions;
using ChatFlow.Dialog.Domain.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ChatFlow.Dialog.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; private set; }

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            this.Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddCustomJsonOptions();

            services
                //.AddMediatR(AppDomain.CurrentDomain.GetAssemblies())
                .AddCustonConfig(Configuration)
                .AddHealthChecks(Configuration)
                .AddSwagger();

            services
                .AddOptions();
            
            services.AddSingleton(options =>
            {
                var config = ConfigurationFactory.ParseString(@"
                    my-dispatcher {
                        type = Dispatcher
                        throughput = 100
                        throughput-deadline-time = 0ms
                    }
                    my-fork-join-dispatcher {
                        type = ForkJoinDispatcher
                        throughput = 100
                        dedicated-thread-pool {
                            thread-count = 30
                            deadlock-timeout = 3s
                            threadtype = background
                        }
                    }
                    akka {
                        # here we are configuring log levels
                        log-config-on-start = on
                        stdout-loglevel = INFO
                        loglevel = ERROR
                        
                        # this config section will be referenced as akka.actor
                        actor {
                            # provider = remote
                            debug {
                                receive = off
                                autoreceive = off
                                lifecycle = off
                                event-stream = off
                                unhandled = off
                            }

                            # default-dispatcher {
                            #    type = Dispatcher
                            #    executor = default-executor

                            #    default-executor {
                            #    }
                            #}

                            #fork-join-executor {
                            #    type = ForkJoinDispatcher
                            #    throughput = 100

                            #    dedicated-thread-pool {
                            #        thread-count = 30
                            #        threadtype = background
                            #    }
                            #}
                        }
                      }
                    "
                );

                var system = ActorSystem.Create("actor-system", config);
                new ActorFactory().Build(system);
                return system;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                //endpoints.MapHealthChecks("/health");
            });

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cable API");
            //});
        }
    }
}
