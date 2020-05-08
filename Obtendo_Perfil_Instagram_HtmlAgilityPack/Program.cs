using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram
{
    class Program
    {
        static void Main(string[] args)
        {
            string Nome_usuário;
            Console.WriteLine("Informe o nome de usuário");
            Nome_usuário = Console.ReadLine();
            
            Profile variavel = ClasseInstagram.GetProfileByUser(Nome_usuário);

            Console.WriteLine(variavel.AndroidAppId);
            Console.WriteLine(variavel.AndroidAppName);
            Console.WriteLine(variavel.AndroidUrl);
            Console.WriteLine(variavel.Description);
            Console.WriteLine(variavel.Image);
            Console.WriteLine(variavel.IosApId);
            Console.WriteLine(variavel.IosAppName);
            Console.WriteLine(variavel.IosUrl);
            Console.WriteLine(variavel.Title);
            Console.WriteLine(variavel.Type);
            Console.WriteLine(variavel.Url);
            Console.WriteLine(variavel.UserName);
            Console.WriteLine(variavel.Seguidores);

            Console.ReadKey();
                        
        }
    }
}
