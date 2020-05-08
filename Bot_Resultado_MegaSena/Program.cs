using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Olar Pessoal! Tecle ENTER");

            string url = @"https://www.google.com/search?q=megasena&rlz=1C1GCEA_enBR894BR894&oq=megasena&aqs=chrome.0.69i59j0l4j69i60l3.1719j0j4&sourceid=chrome&ie=UTF-8";
            string html;

            WebClient valor = new WebClient();

            valor.Headers["Cookies"] = "security=true";
            html = valor.DownloadString(url);

            html = html.Replace("<!doctype html>", "");
            html = html.Replace("<title>", "");
            html = html.Replace("</title>", "");
            html = html.Replace("<head>", "");
            html = html.Replace("</head>", "");
            html = html.Replace("<body>", "");
            html = html.Replace("</body>", "");
            html = html.Replace("</li>", "");

            html = html.Trim();
            string[] teste = Regex.Split(html, "<li>");
            //substring
            for (int i = 0; i < teste.Length; i++)
            {
                teste[i] = teste[i].Replace("\r\n", "");
                teste[i] = teste[i].Trim();
            }
      
            List<int> lista = new List<int>();
   
            lista.Add(int.Parse(teste[1]));
            lista.Add(int.Parse(teste[2]));
            lista.Add(int.Parse(teste[3]));

            Console.WriteLine("");
            lista.OrderBy(x => x).ToList().ForEach(num => {
                Console.WriteLine(num);    
            });
            Console.ReadKey();
        }
    }
}