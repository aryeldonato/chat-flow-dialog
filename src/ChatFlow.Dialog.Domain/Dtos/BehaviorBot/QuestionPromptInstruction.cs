namespace ChatFlow.Dialog.Domain.Dtos.BehaviorBot
{
    /// <summary>
    /// Prompt do tipo Question que aguarda o input do usuário após a reprodução de um áudio ou texto.
    /// Existem três tipos de silêncios:
    ///
    /// - SpeechSilenceTimeout - Define o tempo máximo de silêncio quando existir algum texto transcrito por um STT (Speech-To-Text).
    /// - DigitSilenceTimeout - Define o tempo máximo de silêncio quando o usuário digitou algo.
    /// - LongSilenceTimeout - Define o tempo máximo de silêncio quando o usuário não falou nada ou não foi transcrito por um STT.
    ///
    /// Os tipos de silêncios dependem dos valores no parâmetro "input".
    /// </summary>
    public class QuestionPromptInstruction : BasePromptInstruction
    {
    }
}
