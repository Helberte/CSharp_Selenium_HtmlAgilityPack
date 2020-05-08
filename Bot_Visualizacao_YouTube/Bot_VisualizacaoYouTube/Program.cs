using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prmToolkit.Selenium;
using OpenQA.Selenium;
using Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using System.Threading;
using System.IO;

namespace Bot_VisualizacaoYouTube
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            try
            {
                Console.WriteLine("Abrindo o video");
                driver.Navigate().GoToUrl("https://www.youtube.com/watch?v=F9YtNh_Yw7I");
                Thread.Sleep(TimeSpan.FromSeconds(5));

                driver.FindElement(By.XPath("//*[@id='movie_player']/div[5]/button")).Click();

                Console.WriteLine("Aguardando para clicar no pular anuncio");
                Thread.Sleep(TimeSpan.FromSeconds(7));
   
                try
                {
                    Console.WriteLine("procurando o elemento");
                    driver.FindElement(By.XPath("//*[@id='skip-button:d']/span")).Click();

                    Thread.Sleep(TimeSpan.FromSeconds(30));
                }
                catch (NoSuchElementException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                driver.Close();
                driver.Dispose();
            } 
            Console.ReadKey();
        }
    }
}
