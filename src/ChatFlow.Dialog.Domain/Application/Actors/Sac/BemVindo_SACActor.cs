using ChatFlow.Dialog.Domain.Models;
using System;
using System.Collections.Generic;

namespace ChatFlow.Dialog.Domain.Application.Actors.Sac
{
    public class BemVindo_SACActor : BaseActor
    {
        public override void DefineProcessTransitionBehavior()
        {
            interaction.MessageType = MessageType.RequestPrompt;

            TellInteractionToNextActor<AniNaoLigouSACActor>();
        }

        public override void DefineRequestPromptBehavior()
        {
            string promptKey = $"{interaction.CurrentState}_{DefinePromptKey()}";

            interaction.AddPrompt(new List<string> { $"{promptKey}" }, PromptType.Statement);
        }

        private string DefinePromptKey()
        {
            string siglaPeriodo;
            int hour = DateTime.Now.Hour;
            if (hour < 12)
                siglaPeriodo = "AM";
            else if (hour < 18)
                siglaPeriodo = "PM1";
            else
                siglaPeriodo = "PM2";

            int rand = new Random().Next(1, 3);

            return $"{siglaPeriodo}_RDM{rand}";
        }
    }
}
