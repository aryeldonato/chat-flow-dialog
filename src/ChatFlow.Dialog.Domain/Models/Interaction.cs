using Akka.Actor;
using System.Collections.Generic;
using System.Linq;

namespace ChatFlow.Dialog.Domain.Models
{
    public class Interaction
    {
        public IActorRef ControlActor;
        public IActorRef Origin;
        public MessageType MessageType;
        public string ConversationId;
        public string CurrentState;
        public string LastState;
        public List<string> States;
        public List<int> ScriptPoints;
        public string Input;
        public string From;
        public string To;
        public InteractionPrompt InteractionPrompt;
        public InteractionContext InteractionContext;

        public void AddPrompt(List<string> prompts, PromptType promptType)
        {
            if (InteractionPrompt == null)
                InteractionPrompt = new InteractionPrompt(promptType, prompts);
        }

        public void AddPrompt(List<string> prompts, List<string> text, PromptType promptType)
        {
            if (InteractionPrompt == null)
                InteractionPrompt = new InteractionPrompt(promptType, prompts, text);
        }

        public void AddQuestionPrompts(string[] prompts)
        {
            if (InteractionPrompt == null)
                InteractionPrompt = new InteractionPrompt(PromptType.Question, prompts.ToList());
        }

        public void SendEndSignal()
        {
            this.MessageType = MessageType.End;
            this.ControlActor.Tell(this);
        }

        public bool CameFrom(string actorName)
        {
            string stateName = actorName.Replace("Actor", "");

            if (this.States.Any(c => c == stateName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    public enum MessageType
    {
        ProcessTransition,
        RequestPrompt,
        Rejection,
        Incomplete,
        Silence,
        End
    }

    public enum PromptType
    {
        Question,
        Statement,
        Hangup,
        Transfer,
        Complement,
    }
}
