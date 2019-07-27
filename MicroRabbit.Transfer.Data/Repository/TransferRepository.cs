using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace MicroRabbit.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private readonly IDbConnection _con;
        public TransferRepository(IDbConnection con)
        {
            _con = con;
        }       

        public void Add(TransferLog transferLog)
        {
            using (IDbConnection conn = _con)
            {
                string sQuery = @"INSERT INTO TransferLogs (FromAccount,ToAccount,TransferAmount) 
                                VALUES
                                (@FromAccount,@ToAccount,@TransferAmount)";
                conn.Open();
                conn.Execute(sQuery,new {
                    FromAccount = transferLog.FromAccount,
                    ToAccount = transferLog.ToAccount,
                    TransferAmount = transferLog.TransferAmount
                });                
            }
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            using (IDbConnection conn = _con)
            {
                string sQuery = "SELECT Id, FromAccount, ToAccount, TransferAmount FROM TransferLog";
                conn.Open();
                return conn.Query<TransferLog>(sQuery);                
            }
        }
    }
}
