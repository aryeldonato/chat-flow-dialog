using System.Collections.Generic;

namespace ChatFlow.Dialog.Domain.Dtos.BehaviorBot
{
    /// <summary>
    /// Contém um histórico de tags enviados pelo BehaviorBot ao Dialog.
    /// </summary>
    public class History
    {
        /// <summary>
        /// Define as tags numa estrutura hierárquica.
        /// </summary>
        public List<HistoryNode> HistoryNodes { get; set; }

        /// <summary>
        /// É uma lista de referências às tags.
        /// </summary>
        public List<HistoryLog> HistoryLogs { get; set; }

        public History() {
            this.HistoryNodes = new List<HistoryNode>();
            this.HistoryLogs = new List<HistoryLog>();
        }
    }
}
