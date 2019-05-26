using MyAccount.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAccount.Business
{
    public class TransacaoConta
    {
        private readonly ContaModel _conta;

        public TransacaoConta(ContaModel conta)
        {
            this._conta = conta;
        }


        public ContaModel Debito(double valorDebito)
        {
            return _conta;
        }

        public ContaModel Credito(double valorCredito)
        {
            return _conta;
        }

    }
}
