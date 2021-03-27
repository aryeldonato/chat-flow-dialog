using System.Collections.Generic;

namespace ChatFlow.Dialog.Domain.Dtos.BehaviorBot
{
    /// <summary>
    /// Instrução que contém um ramal, indicando para onde transferir. Além disso, pode existir o motivo da transferência.
    /// </summary>
    public class TransferInstruction
    {
        /// <summary>
        /// Contém o ramal para a qual será transferido.
        /// </summary>
        public string Value { get; set; }

        public List<string> Values { get; set; }

        /// <summary>
        /// Contém o motivo da transferência.
        /// </summary>
        public string Reason { get; set; }
    }
}
