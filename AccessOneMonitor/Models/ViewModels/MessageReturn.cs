using System.Collections.Generic;

namespace AccessOneMonitor.Models.ViewModels
{
    public class MessageReturn
    {
        public MessageReturn(bool sucesso, IEnumerable<string> mensagem, object data)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Data = data;
        }

        public bool Sucesso { get; set; }
        public IEnumerable<string> Mensagem { get; set; }
        public object Data { get; set; }
    }
}
