using System.Collections.Generic;

namespace ChatFlow.Dialog.Domain.Models
{
    public class InteractionPrompt
    {
        public PromptType promptType;
        public List<string> audios;
        public List<string> texts;
        public List<string> transferValues;

        public InteractionPrompt(PromptType promptType, List<string> audios, List<string> texts = null, List<string> transferValues = null)
        {
            this.promptType = promptType;
            this.audios = audios;
            this.texts = texts;
            this.transferValues = transferValues;
        }
    }
}
