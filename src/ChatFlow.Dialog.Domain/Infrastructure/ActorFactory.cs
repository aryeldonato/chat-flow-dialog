using Akka.Actor;
using System.Linq;
using System.Reflection;

namespace ChatFlow.Dialog.Domain.Infrastructure
{
    public class ActorFactory
    {
        public void Build(ActorSystem actorSystem)
        {
            var actors = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(c => c.FullName.EndsWith("Actor"))
                .Where(c => !c.FullName.Contains("BaseActor"));

            foreach (var act in actors)
            {
                actorSystem.ActorOf(Props.Create(act), act.Name);
            }
            //actorSystem.ActorOf(Props.Create<InicioActor>(), nameof(InicioActor));
            //actorSystem.ActorOf(Props.Create<MenuPrincipalActor>(), nameof(MenuPrincipalActor));
            //actorSystem.ActorOf(Props.Create<PedeCPFActor>(), nameof(PedeCPFActor));
            //actorSystem.ActorOf(Props.Create<FimActor>(), nameof(FimActor));
        }
    }
}
