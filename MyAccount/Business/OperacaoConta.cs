using MyAccount.DAL;
using MyAccount.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAccount.Business
{
    public class OperacaoConta: IContaDAL
    {
        private readonly ContaModel _conta;
        private readonly ContaDAL _contaDAL = new ContaDAL();
        

        public OperacaoConta(ContaModel conta)
        {
            this._conta = conta;
            
        }

        public bool CriaNovaConta(ContaModel conta)
        {
            try
            {
                AddConta(conta);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        
        public ContaModel ConsultarConta(int idConta)
        {
            return GetConta(idConta);
        }
        
        public bool DebitoEmConta(double valorDebito)
        {
            var conta = GetConta(_conta.Id);
            conta.Saldo  -= valorDebito;

            try
            {
                AtualizaSaldo(conta);
                return true;
            }
            catch (Exception)
            {
                throw;
                
            }
        }

        public bool CreditoEmConta(double valorCredito)
        {
            var conta = GetConta(_conta.Id);
            conta.Saldo += valorCredito;

            try
            {
                AtualizaSaldo(conta);
                return true;
            }
            catch (Exception)
            {            
                throw;
            }
            

            
        }

        public IEnumerable<ContaModel> GetTodasAsContas()
        {
            var todasContas = new ContaDAL().GetTodasAsContas();

            return todasContas;
        }

        public ContaModel GetConta(int idConta)
        {
            var contaDal = _contaDAL.GetConta(idConta);

            var conta = new ContaModel()
            {
                Id = contaDal.Id,
                Saldo = contaDal.Saldo
            };


            return conta;
        }

        public void AddConta(ContaModel conta)
        {
            _contaDAL.AddConta(conta);
        }

        public void AtualizaSaldo(ContaModel conta)
        {
            _contaDAL.AtualizaSaldo(conta);
        }
    }
}
