using Akka.Actor;
using ChatFlow.Dialog.Domain.Dtos.BehaviorBot;
using ChatFlow.Dialog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatFlow.Dialog.Domain.Application
{
    public class StateMachine
    {
        private readonly ActorSystem actorSystem;

        public StateMachine(ActorSystem actorSystem)
        {
            this.actorSystem = actorSystem;
        }

        public BBotMessage RunChain(BBotMessage message)
        {
            var interaction = AdaptToInteraction(message);

            var controlActor = actorSystem.ActorOf(Props.Create<ControlActor>(), "control-actor-" + Guid.NewGuid());

            var controlTask = controlActor.Ask<Interaction>(interaction);

            controlTask.Wait(TimeSpan.FromSeconds(15));

            actorSystem.Stop(controlActor);

            if (controlTask.IsCompleted)
            {
                var botMessage = AdaptToBotMessage(interaction, message); 
                return botMessage;
            }
            else
            {
                return null;
            }           
        }

        private Interaction AdaptToInteraction(BBotMessage message)
        {
            var interaction = new Interaction()
            {
                ConversationId = message.ConversationId,
                MessageType = MessageType.ProcessTransition,
                Input = message.Query,
                From = message.SessionContext.From,
                To = message.SessionContext.To,
                CurrentState = message.Bag.Tags.LastOrDefault(),
                LastState = message.Bag.Tags.LastOrDefault(),
                InteractionContext = message.SessionContext.InteractionContext,
                States = message.Bag.Tags
            };

            return interaction;
        }

        private BBotMessage AdaptToBotMessage(Interaction interaction, BBotMessage message)
        {
            message.Query = "";
            message.Bag.Tags.Add(interaction.CurrentState);

            var lst = new List<string>();

            foreach (var item in interaction?.InteractionPrompt.audios)
            {
                // lst.Add($"{dialogConfiguration.PromptPath}/{item}.wav");
                lst.Add($"{item}.wav");
            }

            lst.Add("sat");

            switch (interaction.InteractionPrompt.promptType)
            {
                case PromptType.Question:

                    message.Bag.QuestionPromptInstruction = new QuestionPromptInstruction
                    {
                        Audios = lst,
                        Input = "dtmf",
                    };

                    break;

                case PromptType.Statement:

                    message.Bag.StatementPromptInstruction = new StatementPromptInstruction
                    {
                        Audios = lst,
                        Input = "dtmf"
                    };
                    break;

                case PromptType.Hangup:

                    message.Bag.HangupPromptInstruction = new HangupPromptInstruction
                    {
                        Audios = lst
                    };

                    break;

                case PromptType.Transfer:

                    message.Bag.TransferPromptInstruction = new TransferPromptInstruction
                    {
                        Audios = lst
                    };
                    message.Bag.TransferInstruction = new TransferInstruction { Values = interaction.InteractionPrompt.transferValues };

                    break;

                default:
                    break;
            }

            return message;
        }
    }
}
