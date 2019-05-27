using System.ComponentModel.DataAnnotations;

namespace MyAccount.Models
{
    public class ContaModel
    {

        public int Id
        {
            get;
            set;
        }
        public double Saldo { get; set; }

        private double _cotacao;
        [Display(Name = "Dólar Hoje")]
        public double Cotacao
        {
            get
            {
                _cotacao = new CotacaoDolar().Valor;
                return _cotacao;
            }
        }

        [Display(Name = "Saldo em Dólar")]
        public double SaldoEmDolar
        {
            get
            {
                return Saldo / Cotacao;
            }
        }


    }
}
