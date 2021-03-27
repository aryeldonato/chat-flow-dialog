using ChatFlow.Dialog.Domain.Application.Actors.Sac;
using ChatFlow.Dialog.Domain.Models;
using System.Collections.Generic;

namespace ChatFlow.Dialog.Domain.Application.Actors
{
    public class InicioActor : BaseActor
    {
        public override void DefineProcessTransitionBehavior()
        {
            interaction.MessageType = MessageType.RequestPrompt;

            TellInteractionToNextActor<BemVindo_SACActor>();
        }

        public override void DefineRequestPromptBehavior()
        {
            interaction.AddPrompt(new List<string> { "RingbackTone2500" }, PromptType.Statement);
        }
    }
}
