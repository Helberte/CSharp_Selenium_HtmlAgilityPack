using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BotUsandoJason
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Olar Pessoal! Tecle ENTER");

            string url = @"https://www.google.com/search?q=megasena&rlz=1C1GCEA_enBR892BR892&oq=megasena&aqs=chrome..69i57j0l7.2022j0j7&sourceid=chrome&ie=UTF-8";
            string html;
           
            WebClient valor = new WebClient();

            valor.Headers["Cookies"] = "security=true";
            html = valor.DownloadString(url);

           // html = html.Replace("", "");

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
            lista.Add(int.Parse(teste[3].Substring(0,1)));

            Console.WriteLine("--------------------------");
            Console.WriteLine("---------RESULTADO--------");

            foreach (int numero in lista)
            {
                Console.WriteLine("Numero: " + numero);
            }
            /*
            Console.WriteLine("");
            lista.OrderBy(x => x).ToList().ForEach(num => {
                Console.WriteLine(num);
            });*/
            Console.ReadKey();
        }
    }
}
