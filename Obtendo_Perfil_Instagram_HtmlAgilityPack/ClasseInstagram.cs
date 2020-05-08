using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Instagram
{
    public class ClasseInstagram
    {
        public static Profile GetProfileByUser(string user)
        {
            Profile profile = new Profile(user); 

            string url = @"https://www.instagram.com/" + user + "/";
            string texto;

            using (WebClient c = new WebClient())
            {
                texto = c.DownloadString(url);
            }
            
            //Cria-se o objeto da classe htmlDocument() que pertence ao nomespace htmlAgilityPack
            //Através deste objeto, será possível carregar o html que já foi baixado para este objeto
            //htmlDocument();  

            // 1° - Cria-se o objeto htmlDocument;
            HtmlDocument html = new HtmlDocument();
            
            // 2° - A partir deste objeto, carrega-se o html texto dentro do mesmo objeto;
            html.LoadHtml(texto);

            //Na verdade o objeto manipulável nada mais é do que um htmlDocument, com a sring html carregada la dentro;

            //HtmlDocument objWeb = new HtmlWeb().Load("https://www.facebook.com/helberte.costa.5");
                             
            //A propriedade DocumentNode representa o arquivo html por completo, permiindo selecionar-se tags especificas dentro do
            //documento html. Isto será possível através do metodo SelectNodes(); 
            //com o "//nomeDaTag", ele irá selecionar todas as tags com este nome e formar uma lista;

            HtmlNodeCollection lista = html.DocumentNode.SelectNodes("//meta");


            foreach (var tag in lista)
            {   
                string conteudo = tag.GetAttributeValue("property","");
                string conteudo2 = tag.GetAttributeValue("name","");
                
                if (conteudo == "al:ios:app_name")
                {
                    profile.IosAppName = tag.GetAttributeValue("content", "");
                }
                if (conteudo == "al:ios:app_store_id")
                {
                    profile.IosApId = tag.GetAttributeValue("content","");
                }
                if (conteudo == "al:ios:url")
                {
                    profile.IosUrl = tag.GetAttributeValue("content","");
                }
                if (conteudo == "al:android:app_name")
                {
                    profile.AndroidAppName = tag.GetAttributeValue("content","");
                }
                if (conteudo == "al:android:package")
                {
                    profile.AndroidAppId = tag.GetAttributeValue("content","");
                }
                if (conteudo == "al:android:url")
                {
                    profile.AndroidUrl = tag.GetAttributeValue("content","");
                }
                if (conteudo == "og:type")
                {
                    profile.Type = tag.GetAttributeValue("content","");
                }
                if (conteudo == "og:image")
                {
                    profile.Image = tag.GetAttributeValue("content", "");
                }
                if (conteudo == "og:title")
                {
                    profile.Title = tag.GetAttributeValue("content","");
                }
                if (conteudo == "og:description")
                {
                    profile.Description = tag.GetAttributeValue("content","");
                }
                if (conteudo == "og:url")
                {
                    profile.Description = tag.GetAttributeValue("content","");
                }
                if (conteudo2 == "description")
                {
                    profile.Seguidores = tag.GetAttributeValue("content", "");
                }
            }
            return profile;
        }
    }
}