using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Enviar_mensagens_WhatsApp_2
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            ////   AINDA EM ANDAMENTO

            try
            {

                driver.Navigate().GoToUrl("https://web.whatsapp.com/");
                Thread.Sleep(TimeSpan.FromSeconds(4));

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
            Console.ReadKey();
        }
    }
}
