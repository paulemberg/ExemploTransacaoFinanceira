using HtmlAgilityPack;
using System;

namespace Cotacao
{
    public class DolarRobot
    {
        private readonly string Url = @"https://economia.uol.com.br/";


        public double CotacaoHoje()
        {
            var web = new HtmlWeb();
            
            var htmlDoc = web.Load(Url);

            //var nodes = htmlDoc.DocumentNode.SelectNodes("//h3/a");
            var node = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/section[1]/div[2]/div[1]/div[1]/div[1]/h3[1]/a[3]");
                        
            var valor = node.InnerText;

            valor = valor.Remove(0, 2);
            valor = valor.Replace('\"',' ');
            valor = valor.Trim();

            var retorno = Convert.ToDouble(valor) ;

            return retorno;
        }


    }

   
}
