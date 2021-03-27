using System.Collections.Generic;

namespace ChatFlow.Dialog.Domain.Dtos.BehaviorBot
{
    public class FlowTagContext
    {
        public string Id { get; set; }
        
        public Dictionary<string, string> Attributes { get; set; }
    }
}