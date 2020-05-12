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
        public List<string> Contatos = new List<string>();
        long numero = 0;

        public void NovosContatos(string contatos)
        {
            if (long.TryParse(contatos, out numero))
            {
                //https://www.caelum.com.br/apostila-csharp-orientacao-objetos/manipulacao-de-strings/#exerccios
                //manipular strings
                string cont = contatos;

                string nova = cont.Substring(0, 2) + " " + contatos.Substring(3, 6) + " ";

                this.Contatos.Add("+55 " + nova);
            }
            else
                this.Contatos.Add(contatos);
        }

        public void NovasRespostas(string resposta)
        {
            this.Respostas.Add(resposta);
        }

        public void NovasPerguntas(string perguntas)
        {
            this.Perguntas.Add(perguntas);
        }
    }
}
