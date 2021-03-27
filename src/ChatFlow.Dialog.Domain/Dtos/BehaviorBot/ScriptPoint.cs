namespace ChatFlow.Dialog.Domain.Dtos.BehaviorBot
{
    /// <summary>
    /// Define um script point que complementa o fluxo baseado em tags.
    /// </summary>
    public class ScriptPoint
    {
        /// <summary>
        /// Define o nome do script point.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Contém a referência ou identificação em forma numérica do script point.
        /// </summary>
        public int Id { get; set; }

        public ScriptPoint()
        {

        }

        public ScriptPoint(int Id) {
            this.Id = Id;
        }

        public ScriptPoint(int Id, string Name) {
            this.Id = Id;
            this.Name = Name;
        }

    }
}
