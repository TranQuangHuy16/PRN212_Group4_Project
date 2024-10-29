// See https://aka.ms/new-console-template for more information
using BOs;

Console.WriteLine("Hello, World!");

var db = new MyDbContext();
List<Account> list = db.Accounts.ToList();
foreach (var account in list)
{
    Console.WriteLine(account.AccountId);
}