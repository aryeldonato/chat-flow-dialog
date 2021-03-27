using Akka.Actor;
using Akka.Event;
using ChatFlow.Dialog.Domain.Infrastructure.Configuration;
using ChatFlow.Dialog.Domain.Models;
using System;
using System.Collections.Generic;

namespace ChatFlow.Dialog.Domain.Application
{
    public abstract class BaseActor : UntypedActor
    {
        public int RejCountLimit = 2;
        public int SilCountLimit = 2;
        public int IncCountLimit = 2;
        public Interaction interaction;
        private readonly ILoggingAdapter _logger = Logging.GetLogger(Context);

        public virtual void DefineCurrentState() =>
            interaction.CurrentState = this.StateName;

        public string ActorName
        {
            get => this.GetType().Name;
        }

        public string StateName
        {
            get => this.GetType().Name.Replace("Actor", "");
        }

        protected override void OnReceive(object message)
        {
            this.interaction = (Interaction)message;

            _logger.Info("A message was received");

            DefineCurrentState();

            switch (interaction.MessageType)
            {
                case MessageType.ProcessTransition:

                    DefineProcessTransitionBehavior();
                    break;

                case MessageType.RequestPrompt:

                    DefineRequestPromptBehavior();
                    interaction.SendEndSignal();
                    break;

                case MessageType.Rejection:

                    DefineRejectionBehavior();
                    interaction.SendEndSignal();
                    break;

                case MessageType.Incomplete:

                    DefineIncompleteBehavior();
                    interaction.SendEndSignal();
                    break;

                case MessageType.Silence:

                    DefineSilenceBehavior();
                    interaction.SendEndSignal();
                    break;

                case MessageType.End:

                    DefineEndBehavior();
                    interaction.SendEndSignal();
                    break;

                default:
                    break;
            }

        }

        public void TellInteractionToNextActor(string actorName)
        {
            var nextActor = Context.ActorSelection($"../{actorName}");

            nextActor.Tell(interaction);
        }

        public void TellInteractionToNextActor<TActor>()
            where TActor : BaseActor
        {
            var actorType = typeof(TActor);
            var actorName = actorType.Name;

            var nextActor = Context.ActorSelection($"../{actorName}");

            nextActor.Tell(interaction);
        }

        public abstract void DefineProcessTransitionBehavior();

        public virtual void DefineRequestPromptBehavior()
        {
            interaction.AddPrompt(new List<string> { $"{interaction.CurrentState}_Ini" }, PromptType.Question);
        }

        public virtual void DefineSilenceBehavior()
        {
            int silCount = ++interaction.InteractionContext.MenuSilCounter;

            if (silCount > this.SilCountLimit)
                PerformMaxSil();
            else
                interaction.AddPrompt(new List<string> { $"{interaction.CurrentState}_Sil{silCount}" }, PromptType.Question);
        }

        public virtual void DefineRejectionBehavior()
        {
            int rejCount = ++interaction.InteractionContext.MenuRejCounter;

            if (rejCount > this.RejCountLimit)
                PerformMaxRej();
            else
                interaction.AddPrompt(new List<string> { $"{interaction.CurrentState}_Rej{rejCount}" }, PromptType.Question);
        }

        private void DefineIncompleteBehavior()
        {
            int incCount = ++interaction.InteractionContext.MenuIncCounter;

            if (incCount > this.IncCountLimit)
                PerformMaxRej();
            else
                interaction.AddPrompt(new List<string> { $"{interaction.CurrentState}_Inc{incCount}" }, PromptType.Question);
        }

        public virtual void DefineEndBehavior() => throw new NotImplementedException();

        public virtual void PerformMaxSil() => throw new NotImplementedException();

        public virtual void PerformMaxRej() => throw new NotImplementedException();
    }
}
