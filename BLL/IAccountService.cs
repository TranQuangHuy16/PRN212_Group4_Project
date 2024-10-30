using BOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IAccountService
    {
        void CreateAccount(Account account);
        void UpdateAccount(Account account);
        void DeleteAccount(int id);
        List<Account> GetAccounts();
        Account GetAccountById(int id);
        Account GetAccountByEmail(string email);
    }
}
