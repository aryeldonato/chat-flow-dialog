using System.Collections.Generic;

namespace ChatFlow.Dialog.Domain.Dtos.BehaviorBot
{
    /// <summary>
    /// # Stop points
    ///
    /// Dentro de uma lista de áudios, é possível adicionar quatro tipos de stop points:
    ///
    /// - Stop Any Point (sap) - Interrompe após o áudio ser reproduzido.
    /// - Stop Any Time (sat) - Interrompe em qualquer momento de uma reprodução de áudio.
    /// - Stop Point (sp) - Interrompe no ponto definido.
    /// - Non Stop Point (nsp) - Não interrompe até o ponto definido e continua no próximo áudio.
    ///
    /// Por exemplo:
    ///
    /// - ["áudio1", "áudio2", "sap"] => Irá parar entre o primeiro e segundo áudio ou depois do segundo.
    /// - ["áudio1", "áudio2", "sta"] => Irá parar em qualquer áudio, inclusive no meio de um áudio.
    /// - ["áudio1", "áudio2", "sp"] => Irá parar somente após o segundo áudio.
    /// - ["áudio1", "áudio2", "nsp", "áudio3", "sat"] => Não irá parar no segundo áudio, irá reproduzir o terceiro áudio e pode interromper em qualquer momento somente no terceiro áudio.
    /// </summary>
    public class PromptInstruction
    {
        /// <summary>
        /// Contém o texto a ser transcrito por um TTS (Text-To-Speech) ou ser reproduzido no chat.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Define o(s) áudio(s) que será(ão) reproduzido(s).
        /// </summary>
        public List<string> Audios { get; set; }

        public PromptInstruction()
        {
            Audios = new List<string>();
        }
    }
}
