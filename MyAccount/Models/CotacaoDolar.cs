using Cotacao;
namespace MyAccount.Models
{
    public class CotacaoDolar
    {
        private double _valor;
        public double Valor
        {
            get
            {
                var cotacao = new Dolar();
                _valor = cotacao.DolarHoje();
                return _valor;
            }
        }

    }
}
