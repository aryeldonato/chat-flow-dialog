using ChatFlow.Dialog.Domain.Application.Fixtures;
using ChatFlow.Dialog.Domain.Application.Fixtures.Strategies;
using ChatFlow.Dialog.Domain.Models;
using System.Collections.Generic;

namespace ChatFlow.Dialog.Domain.Application.Actors.Sac
{
    public class AniNaoLigouSACActor : BaseActor
    {
        public override void DefineProcessTransitionBehavior()
        {
            var fixture = new DigitsFixtures(interaction.Input);
            var lstStrategies = new List<IDigitsStrategy>
            {
                new CPFDigitsStrategy(),
                new CNPJDigitStrategy(),
                new SingleDigitStrategy("*"),
                new MultiDigitsStrategy(8,10),
            };
            fixture.strategies.AddRange(lstStrategies);

            switch (fixture.Validate())
            {
                case CompoundDigitsFixtureResult result when result.digitsFixtureResult == DigitsFixtureResult.Ok:

                    if (result.type is SingleDigitStrategy)
                    {
                        interaction.MessageType = MessageType.RequestPrompt;

                        TellInteractionToNextActor<MenuNuncaComprouActor>();
                    }
                    else
                    {
                        interaction.MessageType = MessageType.ProcessTransition;

                        TellInteractionToNextActor<LatenciaAniNaoActor>();
                    }

                    break;

                case CompoundDigitsFixtureResult result when result.digitsFixtureResult == DigitsFixtureResult.Silence:

                    interaction.MessageType = MessageType.Silence;

                    TellInteractionToNextActor<AniNaoLigouSACActor>();

                    break;

                case CompoundDigitsFixtureResult result when result.digitsFixtureResult == DigitsFixtureResult.Rejection:

                    interaction.MessageType = MessageType.Rejection;

                    TellInteractionToNextActor<AniNaoLigouSACActor>();

                    break;

                case CompoundDigitsFixtureResult result when result.digitsFixtureResult == DigitsFixtureResult.Incomplete:

                    interaction.MessageType = MessageType.Incomplete;

                    TellInteractionToNextActor<AniNaoLigouSACActor>();

                    break;

                default:
                    break;
            }
        }
    }
}
