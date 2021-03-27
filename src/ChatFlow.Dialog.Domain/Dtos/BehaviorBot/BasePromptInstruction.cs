using System.Collections.Generic;

namespace ChatFlow.Dialog.Domain.Dtos.BehaviorBot
{
    public abstract class BasePromptInstruction : PromptInstruction
    {

        /// <summary>
        /// Indica se os números digitados pelo usuários precisam ser reproduzidos ou não.
        /// </summary>
        public bool DtmfSecure { get; set; }

        /// <summary>
        /// Contém o tipo de input do usuário que será coletado, os valores aceitos são: "dtmf" para indicar que só aceita 
        /// o input do teclado númerico, "speech" para indicar que o áudio capturado será repassado para o STT (Speech-To-Text).
        /// Pode se utilizar os dois valores ao mesmo tempo, "dtmf speech" para indicar que um dois que ocorrer primeiro será processado.
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// Número máximo de dígitos aceitos quando o "Input" for "dtmf". Ao atingir o número máximo, o BehaviorBot irá enviar os dígitos
        /// ao Dialog.
        /// </summary>
        public int MaxDigits { get; set; }

        /// <summary>
        /// Contém qual o caractere que será utilizado para indicar o fim do input, quando este for "dtmf".
        /// Por exemplo, se definido o caractere "#" e, após o usuário digitar os valores "123#", o BehaviorBot irá
        /// enviar o valor "123#" ao Dialog.
        /// </summary>
        public string FinishOnKey { get; set; }

        /// <summary>
        /// Lista de informações no formato chave/valor que complementa o Prompt.
        /// Pode existir um JSON que apresenta botões para um texto em chat.
        /// </summary>
        public Dictionary<string, object> Properties { get; set; }

        public BasePromptInstruction()
        {
            this.Properties = new Dictionary<string, object>();
        }
    }
}
