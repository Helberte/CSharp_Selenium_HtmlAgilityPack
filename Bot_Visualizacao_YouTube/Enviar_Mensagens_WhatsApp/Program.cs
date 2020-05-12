using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using prmToolkit.Selenium;
using System.Net;
using System.IO;
using System.Xml.XPath;

namespace Enviar_Mensagens_WhatsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Mensagens mensagens = new Mensagens();
            Acoes acoes = new Acoes(mensagens,"https://web.whatsapp.com/");
           
            //O NÚMERO DA PERGUNTA PRECISA SER CORRESPONDENTE AO NÚMERO DA RESPOSTA
            mensagens.NovasPerguntas("Olar");
            mensagens.NovasPerguntas("Bom Dia");
            mensagens.NovasPerguntas("Boa Tarde");
            mensagens.NovasPerguntas("Problemas com o programa");
            mensagens.NovasPerguntas("Obrigado");
            mensagens.NovasPerguntas("Gostaria de falar com o carlos");
            mensagens.NovasPerguntas("Qual o nome do sistema?");
            mensagens.NovasPerguntas("Quem é voce?");

            mensagens.NovasRespostas("Olar! Sou o bot TS. Em que posso ajudar? <h1>TESTE</h1>");
            mensagens.NovasRespostas("Bom Dia! Como vai? Em que posso ajudar?");
            mensagens.NovasRespostas("Boa tarde! Como vai? Em que posso ajudar?");
            mensagens.NovasRespostas("Descreva detalhadamente o problema, por favor");
            mensagens.NovasRespostas("Eu que agradeço! Tchau!");
            mensagens.NovasRespostas("Aguarde, em instantes ele entrará em contato com voces.");
            mensagens.NovasRespostas("SOFTCOM");
            mensagens.NovasRespostas("Sou um bot de mensagens automáticas");

            mensagens.NovosContatos("6992080440");
            mensagens.NovosContatos("ts sistemas");
            mensagens.NovosContatos("executiva yuri");
          

            acoes.ChamaNavegador();
            Thread.Sleep(TimeSpan.FromSeconds(5));

            //SELECIONA TODOS OS CONTATOS DE UMA LISTA E ENVIA UMA MENSAGEM

            acoes.EnviarParaTodos(mensagens.Contatos);


            //CHAT BOT
            //while (acoes.ProcrandoUltimaMensagem())
            //{
            //    Thread.Sleep(TimeSpan.FromSeconds(2));
                //acoes.BuscaContato("mamãe");
            //}


            Console.ReadKey();
            //LINK INTERESSANTE SOBRE SELENIUM
            ////http://pythonclub.com.br/selenium-parte-1.html
        }
    }
}