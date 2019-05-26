using MyAccount.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAccount.Business
{
    public class Conta
    {
        private readonly ContaModel _conta;

        public Conta(ContaModel conta)
        {
            this._conta = conta;
        }
        public bool CriaNovaConta(ContaModel conta)
        {
            return true;
        }
        
        public ContaModel ConsultarConta(int idConta)
        {
            return new ContaModel();
        }
        
        public ContaModel DebitoEmConta(double valor)
        {
            var transacao = new TransacaoConta(_conta).Debito(valor);

            return transacao;
        }

        public ContaModel CreditoEmConta(double valor)
        {
            var transacao = new TransacaoConta(_conta).Credito(valor);

            return transacao;
        }

    }
}
