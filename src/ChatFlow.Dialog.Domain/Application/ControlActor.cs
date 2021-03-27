using ChatFlow.Dialog.Domain.Models;

namespace ChatFlow.Dialog.Domain.Application
{
    public class ControlActor : BaseActor
    {
        public override void DefineEndBehavior()
        {
            interaction.Origin.Tell(interaction, Self);
        }

        public override void DefineCurrentState()
        {
            //base.DefineCurrentState();
        }

        public override void DefineProcessTransitionBehavior()
        {
            interaction.ControlActor = Self;
            interaction.Origin = Sender;

            string actorName;
            if (interaction.CurrentState == "start")
            {
                actorName = "Inicio";
                interaction.MessageType = MessageType.RequestPrompt;
            }
            else
            {
                actorName = interaction.CurrentState;
            }

            TellInteractionToNextActor(actorName + "Actor");
        }

        public override void DefineRequestPromptBehavior()
        {
            throw new System.NotImplementedException();
        }

    }
}
