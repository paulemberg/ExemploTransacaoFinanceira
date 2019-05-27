using Microsoft.Extensions.Configuration;
using MyAccount.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace MyAccount.DAL
{
    public class ContaDAL : IContaDAL
    {
        private readonly string connectionString = @"Data Source=DESKTOP-U9ML8TI;Initial Catalog=FinanceDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
  
        public IEnumerable<ContaModel> GetTodasAsContas()
        {
            List<ContaModel> contas = new List<ContaModel>();

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT ContaId, Saldo FROM CONTA", con);
                cmd.CommandType = CommandType.Text;

                con.Open();

                SqlDataReader result = cmd.ExecuteReader();

                while (result.Read())
                {
                    ContaModel conta = new ContaModel();

                    conta.Id =  (int)result["ContaId"];
                    conta.Saldo = (double)result["Saldo"];

                    contas.Add(conta);

                }

                con.Close();
            }

            return contas;


        }

        public ContaModel GetConta(int idConta)
        {
            var conta = new ContaModel();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT ContaId, Saldo FROM CONTA WHERE ContaId = @ContaId", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ContaId", idConta);

                con.Open();

                SqlDataReader result = cmd.ExecuteReader();

                while (result.Read())
                {
                    conta.Id = (int)result["ContaId"];
                    conta.Saldo = (double)result["Saldo"];

                }
                con.Close();
            }

            return conta;
        }

        public void AddConta(ContaModel conta)
        {
          
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO CONTA (CONTAID, SALDO ) VALUES (@ContaId, @Saldo)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ContaId", conta.Id);
                cmd.Parameters.AddWithValue("@Saldo", conta.Saldo);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }            
        }

        public void AtualizaSaldo(ContaModel conta)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE CONTA SET saldo = @Saldo WHERE ContaId = @ContaId", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ContaId", conta.Id);
                cmd.Parameters.AddWithValue("@Saldo", conta.Saldo);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        /*
         * 
         * Create table Conta(
         *	Id int identity(1,1) not null,
         *	ContaId int not null,
         *	Saldo float not null
         *	)
         */

    }
}
