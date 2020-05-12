using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;

namespace Enviar_Mensagens_WhatsApp
{
    public class Acoes
    {
        public string Url { get; private set; }
        IWebDriver driver = Driver.GetDriver();
        string classNome;
        Mensagens mensagem;

        public Acoes(Mensagens mensagens, string url)
        {
            this.mensagem = mensagens;
            this.Url = url;
        }

        public void ChamaNavegador()
        {
            driver.Navigate().GoToUrl(Url);
            driver.Manage().Window.Maximize();
        }

        public void BuscaContato(string contato)
        {
            //CLICA NA PESQUIZA
            driver.FindElement(By.XPath("//*[@id='side']/div[1]/div/label/div/div[2]")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            driver.FindElement(By.XPath("//*[@id='side']/div[1]/div/label/div/div[2]")).SendKeys(contato);
            Thread.Sleep(TimeSpan.FromSeconds(2));

            //PROCURA O RESULTADO
            int i = 1;
            inicio:
            string title = "";
            try
            {
                //saber quantas divs existem
                while(i < 1000)
                {
                    title = driver.FindElement(By.XPath("//*[@id='pane-side']/div[1]/div/div/div[" + i + "]/div/div/div[2]/div[1]/div[1]/span/span")).GetAttribute("title");
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    if (title.ToUpper() == contato.ToUpper())
                    {
                        driver.FindElement(By.XPath("//*[@id='pane-side']/div[1]/div/div/div[" + i + "]/div/div")).Click();
                        break;
                    }
                    i++;
                }
            }
            catch (NoSuchElementException)
            {
                i++;
                goto inicio;
            }    
        }

        public bool ProcrandoUltimaMensagem()
        {
            //DETECTA A ÚLTIMA MENSAGEM
            //saber quantas tags divs existem no código
            int segundos = 0;
            int valor = 0;

            for (int i = 1; i < 1000; i++)
            {
                try
                {
                    classNome = driver.FindElement(By.XPath("//*[@id='main']/div[3]/div/div/div[3]/div[" + i + "]")).GetAttribute("class");
                    valor = i;
                }
                catch (NoSuchElementException)
                {
                    if (classNome.Contains("message-in"))
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                        DisparandoMensagens(driver.FindElement(By.XPath("//*[@id='main']/div[3]/div/div/div[3]/div[" + valor + "]/div/div/div/div[1]/div/span[1]")).Text);
                        return true;                      
                    }
                    i = 1;
                }   
                if (i == 10)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    segundos++;                 
                }
                if (segundos > 10)
                {
                    EscreveResposta("Atendimento encerrado! Obrigado!");
                    goto fim;
                }
            }
            fim: return false;
        }

        private void DisparandoMensagens(string mens)
        {
            //fazer verificação de qual mensagem é e reponder

            Thread.Sleep(TimeSpan.FromSeconds(2));

            int perguntas = mensagem.Perguntas.Count();

            for (int i = 0; i < perguntas; i++)
            {               
                if (mensagem.Perguntas[i].ToString() == mens)
                {
                    EscreveResposta(mensagem.Respostas[i].ToString());
                    mens = "";
                    break;
                }                
            }        
        }

        private void EscreveResposta(string resposta)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            driver.FindElement(By.XPath("//*[@id='main']/footer/div[1]/div[2]/div/div[2]")).SendKeys(resposta);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            driver.FindElement(By.XPath("//*[@id='main']/footer/div[1]/div[3]/button")).Click();          
        }
    }
}
