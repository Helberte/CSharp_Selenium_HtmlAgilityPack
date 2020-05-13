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
        long numero = 0;
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

        private void FazPesquiza(string pesquiza)
        {   
            //CLICA NA PESQUIZA
            driver.FindElement(By.XPath("//*[@id='side']/div[1]/div/label/div/div[2]")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            driver.FindElement(By.XPath("//*[@id='side']/div[1]/div/label/div/div[2]")).SendKeys(pesquiza);
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }

        private bool ProcuraResultadoNumerico(string contato)
        {
            //PROCURA O RESULTADO

            int i = 1;
            inicio:
            string title = "";

            try
            {
                //saber quantas divs existem
                while (i < 500)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    title = driver.FindElement(By.XPath("//*[@id='pane-side']/div[1]/div/div/div[" + i + "]/div/div/div[2]/div[1]/div[1]/span")).GetAttribute("title");
                 
                    if (title.ToUpper() == contato.ToUpper())
                    {
                        driver.FindElement(By.XPath("//*[@id='pane-side']/div[1]/div/div/div[" + i + "]/div/div")).Click();
                        return true;
                    }
                    i++;
                }
                for (int letra = 0; letra < contato.Length; letra++)
                {
                    driver.FindElement(By.XPath("//*[@id='side']/div[1]/div/label/div/div[2]")).SendKeys(Keys.Backspace);
                }
                return false;
            }
            catch (NoSuchElementException)
            {
                i++;
                goto inicio;
            }
        }

        private bool ProcuraResultadoNaoNumerico(string contato)
        {
            //PROCURA O RESULTADO
            int i = 1;
            inicio:
            string title = "";
            try
            {
                //saber quantas divs existem
                while (i < 500)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    title = driver.FindElement(By.XPath("//*[@id='pane-side']/div[1]/div/div/div[" + i + "]/div/div/div[2]/div[1]/div[1]/span/span")).GetAttribute("title");                
                    if (title.ToUpper() == contato.ToUpper())
                    {
                        driver.FindElement(By.CssSelector("#pane-side > div:nth-child(1) > div > div > div:nth-child("+i+") > div")).Click();
                        return true;
                    }
                    i++;
                }
                for (int letra = 0; letra < contato.Length; letra++)
                {
                    driver.FindElement(By.XPath("//*[@id='side']/div[1]/div/label/div/div[2]")).SendKeys(Keys.Backspace);
                }
                return false;
            }
            catch (NoSuchElementException)
            {
                i++;
                goto inicio;
            }
        }
        public bool BuscaContato(string contato)
        {          
            if (long.TryParse(contato, out numero))
            {
                //https://www.caelum.com.br/apostila-csharp-orientacao-objetos/manipulacao-de-strings/#exerccios
                //manipular strings

                contato = contato.Substring(0, 2) + " " + contato.Substring(2, 4) + "-" + contato.Substring(6, 4);
                contato = "+55 " + contato;

                FazPesquiza(contato);

                return ProcuraResultadoNumerico(contato);
            }
            else
            {
                FazPesquiza(contato);
                return ProcuraResultadoNaoNumerico(contato);
            }
        }

        public bool ProcrandoUltimaMensagem()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            

            var topicos = driver.FindElements(By.ClassName("vW7d1"));

            int total = topicos.Count;
            int teste = total;
            inicio:
            if (total >= (teste + 1))
            { 
                string mensagem = driver.FindElement(By.XPath("//*[@id='main']/div[3]/div/div/div[3]/div[" + topicos.Count + "]/div/div/div/div[1]/div/span[1]")).Text;
            }

            total += 1;

            goto inicio;







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
                if (segundos > 30)
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
            driver.FindElement(By.XPath("//*[@id='main']/footer/div[1]/div[2]/div/div[2]")).SendKeys(Keys.Enter);          
        }

        public void EnviarParaTodos(List<string> lista)
        {
            int quantidade = lista.Count();

            for (int i = 0; i < quantidade; i++)
            {
                if (BuscaContato(lista[i].ToString()))
                {
                    //EscreveResposta("Esta mensagem será enviada para todos os contatos da lista");
                    ProcrandoUltimaMensagem();
                }
            }           
        }

        public void EncontrarNotificação()
        {
            var lista = driver.FindElements(By.ClassName("_2wP_Y"));
            string notificacao = "";

            for (int i = 1; i < lista.Count; i++)
            {
                try
                {
                    driver.FindElement(By.XPath("//*[@id='pane-side']/div[1]/div/div/div[" + i + "]/div/div/div[2]/div[1]/div[1]/span/span"));
                    notificacao = driver.FindElement(By.XPath("//*[@id='pane-side']/div[1]/div/div/div[" + i + "]/div/div")).GetAttribute("class");
                    if (notificacao.Contains("CxUIE"))
                    {
                        driver.FindElement(By.XPath("//*[@id='pane-side']/div[1]/div/div/div[" + i + "]/div/div")).Click();

                        EscreveResposta("Olar! Agradecemos o seu contato e encaminharemos um menu de opções," +
                                        " escolha a opção desejada informando o número da mesma");

                        string menu;
                        menu = mensagem.ListaDeOpcao("MENU DE SERVIÇOS REMOTOS");
                        menu += mensagem.ListaDeOpcao("-----------------------------");
                        menu += mensagem.ListaDeOpcao("*1 - Financeiro*");
                        menu += mensagem.ListaDeOpcao("*2 - Nota Fiscal*");
                        menu += mensagem.ListaDeOpcao("*3 - Produtos*");
                        menu += mensagem.ListaDeOpcao("*4 - Sair*");

                        EscreveResposta(menu);

                        // entrar no chatbot

                        Thread.Sleep(TimeSpan.FromSeconds(10));
                                                
                        //entra no contato
                    }
                }
                catch (NoSuchElementException) { }
            }
        }
    }
}