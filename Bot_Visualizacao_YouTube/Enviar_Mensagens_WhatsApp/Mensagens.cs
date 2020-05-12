using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviar_Mensagens_WhatsApp
{
    public class Mensagens
    {
        public List<string> Respostas = new List<string>();
        public List<string> Perguntas = new List<string>();

        public void NovasRespostas(string resposta)
        {
            this.Respostas.Add(resposta);
        }

        public void NovasPerguntas(string resposta)
        {
            this.Perguntas.Add(resposta);
        }
    }
}
