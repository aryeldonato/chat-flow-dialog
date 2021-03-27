using System.Collections.Generic;

namespace ChatFlow.Dialog.Domain.Dtos.BehaviorBot
{
    /// <summary>
    /// Contém os dados de um script point.
    /// </summary>
    public class Navigation
    {
        public string Nome { get; set; }
        public int Codigo { get; set; }
    }

    /// <summary>
    /// É uma lista de script points.
    /// </summary>
    public class Navigations : List<Navigation> { }
}
