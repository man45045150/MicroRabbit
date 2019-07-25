using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace MicroRabbit.Banking.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDbConnection _con;
        public AccountRepository(IDbConnection con)
        {
            _con = con;
        }       
        public IEnumerable<Account> GetAccounts()
        {
            using (IDbConnection conn = _con)
            {
                string sQuery = "SELECT Id, AccountType, AccountBalance FROM Account";
                conn.Open();
                return conn.Query<Account>(sQuery);                
            }
        }
    }
}
