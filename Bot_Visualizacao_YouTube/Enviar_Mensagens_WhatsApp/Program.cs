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

            mensagens.NovasRespostas("Olar! Sou o bot TS. Em que posso ajudar?");
            mensagens.NovasRespostas("Bom Dia! Como vai? Em que posso ajudar?");
            mensagens.NovasRespostas("Boa tarde! Como vai? Em que posso ajudar?");
            mensagens.NovasRespostas("Descreva detalhadamente o problema, por favor");
            mensagens.NovasRespostas("Eu que agradeço! Tchau!");
            mensagens.NovasRespostas("Aguarde, em instantes ele entrará em contato com voces.");
            mensagens.NovasRespostas("SOFTCOM");
            mensagens.NovasRespostas("Sou um bot de mensagens automáticas");

            acoes.ChamaNavegador();
            Thread.Sleep(TimeSpan.FromSeconds(10));

            acoes.BuscaContato("mamãe");

            while (acoes.ProcrandoUltimaMensagem())
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                //acoes.BuscaContato("mamãe");
            }

            /*
            string nome = "";
            // string mensagem = "";
            int i = 0;

            while (i < 31)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                //detecta a ultima mensagem
                for (i = 1; i < 30; i++)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    try
                    {
                        nome = driver.FindElement(By.CssSelector("#main > div._3zJZ2 > div > div > div._9tCEa > div:nth-child(" + i + ")")).GetAttribute("class");
                    }
                    catch (NoSuchElementException)
                    {
                        if (nome.Contains("message-in"))
                        {
                            mensagem = driver.FindElement(By.CssSelector("#main > div._3zJZ2 > div > div > div._9tCEa > div:nth-child(" + (i - 1) + ") > div > div > div > div.copyable-text > div > span._3FXB1.selectable-text.invisible-space.copyable-text")).Text;
                            i = 31;
                        }
                    }
                }
                Thread.Sleep(TimeSpan.FromSeconds(2));
                if (mensagem == "Olar")
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    driver.SetText(By.XPath("//*[@id='main']/footer/div[1]/div[2]/div/div[2]"), "Olar! Sou um bot e estão me testando!");
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    driver.FindElement(By.XPath("//*[@id='main']/footer/div[1]/div[3]/button")).Click();
                    mensagem = "";
                }
                i = 0;
            }
            */
            Console.ReadKey();
            //LINK INTERESSANTE SOBRE SELENIUM
            ////http://pythonclub.com.br/selenium-parte-1.html
        }
    }
}