using System.Collections.Generic;

namespace ChatFlow.Dialog.Domain.Dtos.BehaviorBot
{
    /// <summary>
    /// Define uma tag numa estrutura hierárquica.
    /// </summary>
    public class HistoryNode
    {
        /// <summary>
        /// Define o nome da tag.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Contém a referência ou identificação em forma numérica da tag.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Define as tags filhas.
        /// </summary>
        public List<HistoryNode> Children { get; set; }

        public HistoryNode() {
            this.Children = new List<HistoryNode>();
        }
    }
}
