using System;
using System.Collections.Generic;

namespace bank.models
{
  public class Account
  {
    public string Owner { get; }
    private double _Balance { get; set; }
    public AccountType Type { get; }
    public List<Transaction> Transactions { get; }

    public Account(string owner, AccountType type)
    {
      Owner = owner;
      Type = type;
      _Balance = 0.00;
      Transactions = new List<Transaction>();
    }

    public double GetBalance()
    {
      return _Balance;
    }

    public void Deposit(double amount)
    {
      if (amount < 0.01)
      {
        throw new ImproperAmount("Unable to deposite an amount less than $0.01");
      }

      _Balance += amount;
      Transactions.Add(new Transaction(amount, TransactionType.Deposit));
    }

    public void Withdraw(double amount)
    {
      if (amount < 0.01)
      {
        throw new ImproperAmount("Unable to withdraw an amount less than $0.01");
      }
      if (amount > 500)
      {
        throw new WithdrawLimit("Unable to withdraw an amount greater than $500.00");
      }
      if (amount > _Balance)
      {
        throw new InsufficientFunds("Insufficient Funds to make the requested withdraw");
      }

      _Balance -= amount;
      Transactions.Add(new Transaction(amount, TransactionType.Withdraw));
    }

    public override string ToString()
    {
      return String.Format("{0}\t{1}\t${2}\tTransactions: {3}", Owner, Type, _Balance, Transactions.Count);
    }
  }
}