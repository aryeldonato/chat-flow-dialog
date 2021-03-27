using ChatFlow.Dialog.Domain.Models;
using System.Collections.Generic;

namespace ChatFlow.Dialog.Domain.Application.Actors.Sac
{
    public class MenuNuncaComprouActor : BaseActor
    {
        public override void DefineRequestPromptBehavior()
        {
            string promptSuffix = "";

            if (this.interaction.CameFrom(nameof(AniNaoLigouSACActor)))
                promptSuffix = "_OkEntao";

            interaction.AddPrompt(new List<string> { $"{interaction.CurrentState}_Ini{promptSuffix}" }, PromptType.Question);
        }

        public override void DefineProcessTransitionBehavior()
        {
            interaction.MessageType = MessageType.RequestPrompt;

            switch (interaction.Input)
            {
                case "1":

                    TellInteractionToNextActor<InfoLojasFisicasActor>();

                    break;

                case "2":

                    TellInteractionToNextActor<MenuCadastroSemResetSenhaActor>();

                    break;

                case "3":

                    TellInteractionToNextActor<MenuListaDeCasamentoActor>();

                    break;

                case "4":

                    TellInteractionToNextActor<MenuOutrosServSemOpcCobrActor>();

                    break;

                case "5":

                    TellInteractionToNextActor<MenuMagazineVoceActor>();

                    break;

                case "6":

                    TellInteractionToNextActor<MenuProdutosActor>();

                    break;

                default:

                    if (string.IsNullOrEmpty(interaction.Input))
                        interaction.MessageType = MessageType.Silence;
                    else
                        interaction.MessageType = MessageType.Rejection;

                    TellInteractionToNextActor<MenuNuncaComprouActor>();

                    break;
            }
        }
    }
}
