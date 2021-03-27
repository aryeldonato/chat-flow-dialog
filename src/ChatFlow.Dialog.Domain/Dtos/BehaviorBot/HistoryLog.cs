using System.Collections.Generic;

namespace ChatFlow.Dialog.Domain.Dtos.BehaviorBot
{

    /// <summary>
    /// É a estrutura que contém as referências às tags.
    /// Um HistoryLog representa as tags recebidas pelo BehaviorBot.
    /// </summary>
    public class HistoryLog
    {
        /// <summary>
        /// É uma lista de referências numéricas que apontam para as tags.
        /// </summary>
        public List<int> Indexes { get; set; }

        public HistoryLog() {
            this.Indexes = new List<int>();
        }
    }
}
