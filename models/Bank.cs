using System;
using System.Collections.Generic;
using System.Linq;

namespace bank.models
{
  public class Bank
  {
    public string Name { get; set; }
    public Dictionary<(string, AccountType), Account> Accounts { get; set; }

    public Bank(string name)
    {
      Name = name;
      Accounts = new Dictionary<(string, AccountType), Account>();
    }

    public void AddAccount(string owner, AccountType type)
    {
      if (Accounts.ContainsKey((owner, type)))
      {
        throw new AccountAlreadyExists("This account already exist");
      }

      Accounts.Add((owner, type), new Account(owner, type));
    }

    public double GetBalance(string owner, AccountType type)
    {
      if (!Accounts.ContainsKey((owner, type)))
      {
        throw new AccountNotFound("Unable to find account");
      }

      return Accounts[(owner, type)].GetBalance();
    }

    public void Deposit(string owner, AccountType type, double amount)
    {
      if (!Accounts.ContainsKey((owner, type)))
      {
        throw new AccountNotFound("Unable to find account to deposit into");
      }

      Accounts[(owner, type)].Deposit(amount);
    }

    public void Withdraw(string owner, AccountType type, double amount)
    {
      if (!Accounts.ContainsKey((owner, type)))
      {
        throw new AccountNotFound("Unable to find account to withdraw from");
      }

      Accounts[(owner, type)].Withdraw(amount);     
    }

    public void Transfer(string fromOwner, AccountType fromType, string toOwner, AccountType toType, double amount)
    {
      if (!Accounts.ContainsKey((fromOwner, fromType)))
      {
        throw new AccountNotFound("Unable to find account to transfer from");
      }
      if (!Accounts.ContainsKey((toOwner, toType)))
      {
        throw new AccountNotFound("Unable to find account to transfer to");
      }

      Accounts[(fromOwner, fromType)].Withdraw(amount);
      Accounts[(toOwner, toType)].Deposit(amount);
    }
  }
}