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
                ValidateAccount(account);
                using var db = new MyDbContext();
                if (db.Accounts.Any(a => a.Email == account.Email && a.Status == 0))
                {
                    throw new ArgumentException("Email is already in use.");
                }
                db.Accounts.Add(account);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw ;
            }

        }

        public void UpdateAccount(Account account)
        {
            try
            {
                ValidateAccount(account);
                using var db = new MyDbContext();
                db.Entry<Account>(account).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw ;
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
                    account.Status = (byte)1;
                    UpdateAccount(account);
                }

            }
            catch (Exception)
            {
                throw ;
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
                    .Where(a => a.Status == 0)
                    .Include(a => a.Schedules)
                    .ToList();
            }
            catch (Exception)
            {
                throw ;
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
                    .Where(a => a.Status == 0)
                    .Include(a => a.Schedules)
                    .SingleOrDefault(a => a.AccountId == id);

                if (account == null)
                {
                    throw new Exception("Not found Account");
                }
                List<Schedule> schedules = db.Schedules.Where(s => s.AccountId == id).ToList();
                account.Schedules = schedules;
            }
            catch (Exception)
            {
                throw ;
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
                    .Where(a => a.Status == 0)
                    .Include(a => a.Schedules)
                    .SingleOrDefault(a => a.Email == email);

                if (account == null)
                {
                    throw new Exception("Not found Account");
                }
            }
            catch (Exception)
            {
                throw ;
            }
            return account;
        }

        private void ValidateAccount(Account account)
        {
            if (string.IsNullOrWhiteSpace(account.Name) || account.Name.Length < 5)
            {
                throw new ArgumentException("Name is required and must be more than 5 characters.");
            }

            if (string.IsNullOrWhiteSpace(account.Email) || !IsValidEmail(account.Email))
            {
                throw new ArgumentException("Invalid Email");
            }

            if ((account.Password == null) || (account.Password.Length < 2))
            {
                throw new ArgumentException("Password is required and must be more than 2 characters.");
            }

            if (string.IsNullOrEmpty(account.Telephone) || !IsValidPhoneNumber(account.Telephone))
            {
                throw new ArgumentException("Invalid Telephone");
            }
        }

        private bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            var phoneRegex = new Regex(@"(84|0[3|5|7|8|9])+(\d{8})");
            return phoneRegex.IsMatch(phoneNumber);
        }

    }
}
