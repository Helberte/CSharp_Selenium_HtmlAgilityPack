using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prmToolkit.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Obtendo_Seguidores
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            try
            {
                driver.Navigate().GoToUrl("https://www.instagram.com/accounts/login/?source=auth_switcher");
                Thread.Sleep(TimeSpan.FromSeconds(5));

                driver.SetText(By.Name("username"), "software_helberte");
                driver.SetText(By.Name("password"), "92285184");
                driver.Submit(By.TagName("button"));

                Thread.Sleep(TimeSpan.FromSeconds(10));

                driver.Navigate().GoToUrl("https://www.instagram.com/helberte_costa/");
                Thread.Sleep(TimeSpan.FromSeconds(5));

                //não funciona o caminho XPath
                driver.FindElement(By.XPath("//button[contains(text(), 'seguir')]")).Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                driver.Close();
                driver.Dispose();
            }

            ///COISAS INTERESSANTES

            //var content = driver.FindElement(By.XPath("/html/head/link[22]"));
            //content.Click();
            //driver.Quit();

            //curso de selenium
            ////https://www.selenium.dev/documentation/en/webdriver/driver_requirements/

            //novos recursos no webdriver
            ////https://www.alura.com.br/conteudo/selenium-csharp-webdriver

            //recursos no selenium
            ////https://www.alura.com.br/conteudo/selenium-csharp-mais-recursos

            //Códigos essenciais do selenium
            ////https://www.automatetheplanet.com/selenium-webdriver-csharp-cheat-sheet/

            //instalação
            ////https://take.net/blog/take-test/selenium-webdriver-instalacao-configuracao-e-teste-inicial-com-c

            //Maneiras de selecionar tags no selectnode
            ////https://docs.microsoft.com/pt-br/dotnet/standard/data/xml/select-nodes-using-xpath-navigation
            ///

            Console.ReadKey();
        }
    }
}
