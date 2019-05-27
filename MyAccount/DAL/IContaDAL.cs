using MyAccount.Models;
using System.Collections.Generic;

namespace MyAccount.DAL
{
    public interface IContaDAL
    {
        IEnumerable<ContaModel> GetTodasAsContas();
        ContaModel GetConta(int idConta);
        void AddConta(ContaModel conta);
        void AtualizaSaldo(ContaModel conta);

    }
}