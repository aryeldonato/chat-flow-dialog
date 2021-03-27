using ChatFlow.Dialog.Domain.Dtos.BehaviorBot;
using System.Collections.Generic;

namespace ChatFlow.Dialog.Domain.BehaviorBot
{
    /// <summary>
    /// Estrutura que contém as instruções essenciais para o BehaviorBot interagir com o usuário.
    /// </summary>
    public class Bag
    {
        /// <summary>
        /// Lista de tags utilizada para indicar um ponto dentro do diálogo ou para onde ir no mesmo.
        /// </summary>
        public List<string> Tags { get; set; }

        public List<ScriptPoint> ScriptPoints { get; set; }

        /// <summary>
        /// Prompt do tipo Question que aguarda o input do usuário após a reprodução de um áudio ou texto.
        /// </summary>        
        public QuestionPromptInstruction QuestionPromptInstruction { get; set; }

        /// <summary>
        /// Prompt do tipo Statement que NÃO aguarda o input do usuário após a reprodução de um áudio ou texto.
        /// </summary>        
        public StatementPromptInstruction StatementPromptInstruction { get; set; }

        /// <summary>
        /// Prompt do tipo Hangup que não captura o input do usuário e indica que a ligação ocorreu com sucesso.
        /// </summary>
        public HangupPromptInstruction HangupPromptInstruction { get; set; }

        /// <summary>
        /// Prompt do tipo Transfer que não captura o input do usuário e indica que ligação foi transferida.
        /// </summary>
        public TransferPromptInstruction TransferPromptInstruction { get; set; }

        /// <summary>
        /// Prompt do tipo Wait utilizado quando há algum problema na requisição ao Dialog pelo BehaviorBot.
        /// É um prompt que pode se repetir até o BehaviorBot obter alguma resposta do Dialog.
        /// </summary>
        public WaitPromptInstruction WaitPromptInstruction { get; set; }

        /// <summary>
        /// Prompt do tipo Complement que adiciona um áudio ou texto no meio de um prompt do tipo Question ou Statement.
        /// </summary>
        public ComplementPromptInstruction ComplementPromptInstruction { get; set; }

        /// <summary>
        /// Instrução que contém um ramal, indicando para onde transferir. Além disso, pode existir o motivo da transferência.
        /// </summary>        
        public TransferInstruction TransferInstruction { get; set; }

        public Bag() {
            this.Tags = new List<string>();
            this.ScriptPoints = new List<ScriptPoint>();
        }
    }
}
