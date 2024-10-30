using BOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountDAO : IAccountRepository
    {
        public void CreateAccount (Account account)
        {
            try
            {
                using var db = new MyDbContext();
                db.Accounts.Add(account);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }

        }

        public void UpdateAccount(Account account)
        {
            try
            {
                using var db = new MyDbContext();
                db.Entry<Account>(account).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteAccount(int id)
        {
            try
            {
                using var db = new MyDbContext();
                Account account = db.Accounts.SingleOrDefault(a => a.AccountId == id);
                if (account != null)
                {
                    account.Status = (byte)0;
                    UpdateAccount(account);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();
            List<Schedule> schedules = new List<Schedule>();
            try
            {
                using var db = new MyDbContext();
                accounts = db.Accounts
                             .Include(a => a.Schedules)
                             .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return accounts;
        }

        public Account GetAccountById(int id)
        {
            Account account = null;
             
            try
            {
                using var db = new MyDbContext();

                account = db.Accounts
                    .Where(a => a.Status == 1)
                    .Include(a => a.Schedules)
                    .SingleOrDefault(a => a.AccountId == id);

                if (account == null)
                {
                    throw new Exception("Not found Account");
                }
                List<Schedule> schedules = db.Schedules.Where(s => s.AccountId == id).ToList();
                account.Schedules = schedules;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }

        public Account GetAccountByEmail(string email)
        {
            Account account = null;
            try
            {
                using var db = new MyDbContext();
                account = db.Accounts
                    .Where(a => a.Status == 1)
                    .Include(a => a.Schedules)
                    .SingleOrDefault(a => a.Email == email);

                if (account == null)
                {
                    throw new Exception("Not found Account");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }

    }
}
