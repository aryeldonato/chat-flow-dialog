using Microsoft.Extensions.DependencyInjection;

namespace ChatFlow.Dialog.Api.Extensions
{
    public static class IMvcBuilderExtensions
    {
        public static IMvcBuilder AddCustomJsonOptions(this IMvcBuilder builder)
        {
            builder.AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.IgnoreNullValues = true;
                opt.JsonSerializerOptions.WriteIndented = true;
            });

            return builder;
        }
    }

}
