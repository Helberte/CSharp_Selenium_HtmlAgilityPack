using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


namespace Enviar_Mensagens_WhatsApp
{
    class Driver
    {
        public static IWebDriver driver;

        private Driver() { }

        public static IWebDriver GetDriver()
        {
            if (driver is null)
                driver = new ChromeDriver();
            return driver;
        } 
    }
}
