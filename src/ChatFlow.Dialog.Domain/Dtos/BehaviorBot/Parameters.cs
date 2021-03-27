namespace ChatFlow.Dialog.Domain.Dtos.BehaviorBot
{
    /// <summary>
    /// Contém alguns contadores, tais como contador de silêncio ou de rejeição.
    /// </summary>
    public class Parameters
    {
        /// <summary>
        /// Contador de silêncio.
        /// </summary>
        public int SilCount { get; set; }

        /// <summary>
        /// Contador de rejeição.
        /// </summary>
        public int RejCount { get; set; }

        /// <summary>
        /// Indica se a requisição deve voltar para o mesmo estado
        /// </summary>
        public bool IsCallBack { get; set; }
    }
}
