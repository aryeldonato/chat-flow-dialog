namespace ChatFlow.Dialog.Domain.Dtos.BehaviorBot
{
    /// <summary>
    /// Define alguns parâmetros globais utilizados na conversação.
    /// </summary>
    public class Options
    {
        /// <summary>
        /// Define se o DTMF será reproduzido a partir de áudios pré gravados ou será a partir de um texto transcrito por um TTS (Text-To-Speech).
        /// </summary>
        public bool DtmfAudio { get; set; }

        /// <summary>
        /// Define o tempo máximo de silêncio quando existir algum texto transcrito por um STT (Speech-To-Text).
        /// </summary>
        public int SpeechSilenceTimeout { get; set; }

        /// <summary>
        /// Define o tempo máximo de silêncio quando o usuário digitou algo.
        /// </summary>
        public int DigitSilenceTimeout { get; set; }

        /// <summary>
        /// Define o tempo máximo de silêncio quando o usuário não falou nada ou não foi transcrito por um STT.
        /// </summary>
        public int LongSilenceTimeout { get; set; }
    }
}
