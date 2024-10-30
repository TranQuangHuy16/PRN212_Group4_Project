using BOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AccountService : IAccountService
    {
        IAccountRepository repo;

        public AccountService()
        {
            repo = new AccountDAO();
        }
        public void CreateAccount(Account account)
        {
            repo.CreateAccount(account);
        }

        public void DeleteAccount(int id)
        {
            repo.DeleteAccount(id);
        }

        public Account GetAccountByEmail(string email)
        {
            return repo.GetAccountByEmail(email);
        }

        public Account GetAccountById(int id)
        {
            return repo.GetAccountById(id);
        }

        public List<Account> GetAccounts()
        {
            return repo.GetAccounts();
        }

        public void UpdateAccount(Account account)
        {
            repo.UpdateAccount(account);
        }
    }
}
