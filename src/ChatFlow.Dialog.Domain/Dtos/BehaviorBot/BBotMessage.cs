using ChatFlow.Dialog.Domain.BehaviorBot;

namespace ChatFlow.Dialog.Domain.Dtos.BehaviorBot
{
    /// <summary>
    /// Estrutura que contém os dados enviados pelo BehaviorBot ao Dialog e vice-versa.
    /// </summary>
    public class BBotMessage
    {
        /// <summary>
        /// Identificação da conversação.
        /// </summary>        
        public string ConversationId { get; set; }

        /// <summary>
        /// Texto capturado do usuário, que pode ser um dígito (DTMF) ou um texto transcrito pelo STT (Speech-To-Text).
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// O BehaviorBot envia somente as Tags dentro da Bag ao Dialog e, como resposta, obtém uma lista de tags e os prompts
        /// para serem reproduzidos.
        /// </summary>
        public Bag Bag { get; set; }

        /// <summary>
        /// Estrutura utilizada para complementar a conversação com informações geradas pelo Dialog.
        /// O BehaviorBot adiciona alguns dados, tais como From, To, Created, e outros. São dados imutáveis.
        /// Em contrapartida, o Dialog pode adicionar dados que serão recebidos por ele na próxima interação.
        /// </summary>
        public SessionContext SessionContext { get; set; }

        /// <summary>
        /// Define alguns parâmetros globais utilizados na conversação.
        /// </summary>
        public Options Options { get; set; }

        /// <summary>
        /// Contém um histórico de tags enviados pelo BehaviorBot ao Dialog.
        /// </summary>
        public History TagHistory { get; set; }

        /// <summary>
        /// Contém um histórico de script points enviados pelo BehaviorBot ao Dialog.
        /// </summary>
        public History ScriptPointHistory { get; set; }

        public BBotMessage() {
            this.Bag = new Bag();
            this.SessionContext = new SessionContext();
            this.TagHistory = new History();
            this.ScriptPointHistory = new History();
        }
    }
}
