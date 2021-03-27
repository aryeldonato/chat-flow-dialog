namespace ChatFlow.Dialog.Domain.Dtos.BehaviorBot
{
    /// <summary>
    /// Prompt do tipo Wait utilizado quando há algum problema na requisição ao Dialog pelo BehaviorBot.
    /// É um prompt que pode se repetir até o BehaviorBot obter alguma resposta do Dialog.
    /// </summary> 
    public class WaitPromptInstruction : PromptInstruction
    {
    }
}
