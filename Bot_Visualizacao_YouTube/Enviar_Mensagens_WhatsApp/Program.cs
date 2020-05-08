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

namespace Enviar_Mensagens_WhatsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://web.whatsapp.com/");
            driver.Manage().Window.Maximize();

            Thread.Sleep(TimeSpan.FromSeconds(5));

            driver.FindElement(By.XPath("//*[@id='side']/div[1]/div/label/div/div[2]")).Click();
            driver.SetText(By.XPath("//*[@id='side']/div[1]/div/label/div/div[2]"), "ts sistemas");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            driver.FindElement(By.XPath("//*[@id='pane-side']/div[1]/div/div/div[3]/div/div")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            driver.SetText(By.XPath("//*[@id='main']/footer/div[1]/div[2]/div/div[2]"),"Teste de Bot Para enviar mensagens");           
            Thread.Sleep(TimeSpan.FromSeconds(2));
            driver.FindElement(By.XPath("//*[@id='main']/footer/div[1]/div[3]/button")).Click();

            Console.ReadKey();

            //LINK INTERESSANTE SOBRE SELENIUM
            ////http://pythonclub.com.br/selenium-parte-1.html
        }
    }
}