using ChatFlow.Dialog.Domain.Models;
using System;


namespace ChatFlow.Dialog.Domain.Dtos.BehaviorBot
{
    /// <summary>
    /// É a estrutura que contém os dados enviados pelo BehaviorBot ao Dialog.
    /// Ao mesmo tempo, mantém os dados adicionados pelo Dialog e que podem ser utilizados na próxima interação.
    /// </summary>
    public class SessionContext
    {
        public SessionContext()
        {
            InteractionContext = new InteractionContext();
        }

        /// <summary>
        /// É o canal da conversação, pode ser "voice" ou "chat".
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// Data de criação da conversação.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// É o rementente da conversação que normalmente é o ramal do usuário.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// É o destinatário da conversação, que normalmente é o ramal associado ao BehaviorBot.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// E a qualidade do áudio (8kHz ou 16kHz) definido durante a ligação entre o softphone do usuário e o PBX (Asterisk, Genesys ou outro).
        /// </summary>
        public string SampleRate { get; set; }
        
        public string FileNumber { get; set; }

        /// <summary>
        /// Nome da interaction usado no tracing.
        /// </summary>
        public string CurrentInteractionName { get; set; }

        /// <summary>
        /// Duração da conversação em milliseconds.
        /// </summary>
        public string ConversationDuration { get; set; }
        
        public string SuccessTransferValue { get; set; }

        public InteractionContext InteractionContext { get; set; }
    }
}
