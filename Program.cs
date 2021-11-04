using System;
using bank.models;

namespace bank
{
  static class Test
  {
    public static void AddAccountTestPositive()
    {
      Console.WriteLine("--- Add Account Test Positive ---");

      Bank bank = new Bank("Bank");
      string owner = "John Doe";
      AccountType type = AccountType.Checking;
      
      bank.AddAccount(owner, type);

      double balance = bank.GetBalance(owner, type);
      Console.WriteLine("✔ Was able to create a {0} account for {1} with a balance of ${2} at {3}", type, owner, balance, bank.Name);
    }
    public static void AddAccountTestNegative()
    {
      Console.WriteLine("--- Add Account Test Negative ---");
      
      Bank bank = new Bank("Bank");
      string owner = "John Doe";
      AccountType type = AccountType.Checking;
      
      bank.AddAccount(owner, type);

      double balance = bank.GetBalance(owner, type);
      Console.WriteLine("✔ Was able to create a {0} account for {1} with a balance of ${2} at {3}", type, owner, balance, bank.Name);

      try
      {
        bank.AddAccount(owner, type);
      }
      catch(AccountAlreadyExists e)
      {
        Console.WriteLine("✔ Was unable to create a duplicate account with exception - {0}", e.ToString());
      }
    }
    public static void DepositTestPosivite()
    {
      Console.WriteLine("--- Deposit Test Posivite ---");

      Bank bank = new Bank("Bank");
      string owner = "John Doe";
      AccountType type = AccountType.Checking;
      
      bank.AddAccount(owner, type);

      double balance = bank.GetBalance(owner, type);
      Console.WriteLine("✔ Was able to create a {0} account for {1} with a balance of ${2} at {3}", type, owner, balance, bank.Name);

      double amount = 300.00;
      bank.Deposit(owner, type, amount);

      balance = bank.GetBalance(owner, type);
      Console.WriteLine("✔ Was able to deposit ${0} into {1}'s {2} account with a new balance of ${3} at {4}", amount, owner, type, balance, bank.Name);
    }
    public static void DepositTestNegative()
    {
      Console.WriteLine("--- Deposit Test Negative ---");

      Bank bank = new Bank("Bank");
      string owner = "John Doe";
      AccountType type = AccountType.Checking;
      
      bank.AddAccount(owner, type);

      double balance = bank.GetBalance(owner, type);
      Console.WriteLine("✔ Was able to create a {0} account for {1} with a balance of ${2} at {3}", type, owner, balance, bank.Name);

      double amount = -50.00;

      try
      {
        bank.Deposit(owner, type, amount);
      }
      catch(ImproperAmount e)
      {
        Console.WriteLine("✔ Was unable to deposit an incorrect amount of ${0} with exception - {1}", amount, e.ToString());
      }

      owner = "Jane Smith";
      amount = 50.00;

      try
      {
        bank.Deposit(owner, type, amount);
      }
      catch(AccountNotFound e)
      {
        Console.WriteLine("✔ Was unable to deposit into a non-existent account with exception - {0}", e.ToString());
      }
    }
    public static void WithdrawTestPositive()
    {
      Console.WriteLine("--- Withdraw Test Positive ---");

      Bank bank = new Bank("Bank");
      string owner = "John Doe";
      AccountType type = AccountType.Checking;

      bank.AddAccount(owner, type);

      double balance = bank.GetBalance(owner, type);
      Console.WriteLine("✔ Was able to create a {0} account for {1} with a balance of ${2} at {3}", type, owner, balance, bank.Name);

      double amount = 300.00;
      bank.Deposit(owner, type, amount);

      balance = bank.GetBalance(owner, type);
      Console.WriteLine("✔ Was able to deposit ${0} into {1}'s {2} account with a new balance of ${3} at {4}", amount, owner, type, balance, bank.Name);

      amount = 250.00;
      bank.Withdraw(owner, type, amount);

      balance = bank.GetBalance(owner, type);
      Console.WriteLine("✔ Was able withdraw ${0} into {1}'s {2} account with a new balance of ${3} at {4}", amount, owner, type, balance, bank.Name);
    }
    public static void WithdrawTestNegative()
    {
      Console.WriteLine("--- Withdraw Test Negative ---");

      Bank bank = new Bank("Bank");
      string owner = "John Doe";
      AccountType type = AccountType.Checking;

      bank.AddAccount(owner, type);

      double balance = bank.GetBalance(owner, type);
      Console.WriteLine("✔ Was able to create a {0} account for {1} with a balance of ${2} at {3}", type, owner, balance, bank.Name);

      double amount = 300.00;
      bank.Deposit(owner, type, amount);

      balance = bank.GetBalance(owner, type);
      Console.WriteLine("✔ Was able to deposit ${0} into {1}'s {2} account with a new balance of ${3} at {4}", amount, owner, type, balance, bank.Name);

      amount = -10.00;
      try
      {
        bank.Withdraw(owner, type, amount);
      }
      catch(ImproperAmount e)
      {
        Console.WriteLine("✔ Was unable to withdraw an incorrect amount of ${0} with exception - {1}", amount, e.ToString());
      }

      amount = 501.00;
      try
      {
        bank.Withdraw(owner, type, amount);
      }
      catch(WithdrawLimit e)
      {
        Console.WriteLine("✔ Was unable to withdraw an amount greater than the withdraw limit of $500 with exception - {1}", amount, e.ToString());
      }

      amount = 350.00;
      try
      {
        bank.Withdraw(owner, type, amount);
      }
      catch(InsufficientFunds e)
      {
        Console.WriteLine("✔ Was unable to withdraw an amount ${0} greater than the current balance of ${1} with exception - {2}", amount, balance, e.ToString());
      }

      amount = 250.00;
      owner = "Jane Smith";
      try
      {
        bank.Withdraw(owner, type, amount);
      }
      catch(AccountNotFound e)
      {
        Console.WriteLine("✔ Was unable to withdraw from a non-existent account with exception - {0}", e.ToString());
      }
    }
    public static void TransferTestPositive()
    {
      Console.WriteLine("--- Transfer Test Positive ---");

      Bank bank = new Bank("Bank");
      string owner1 = "John Doe";
      AccountType type1 = AccountType.Checking;

      bank.AddAccount(owner1, type1);

      double balance1 = bank.GetBalance(owner1, type1);
      Console.WriteLine("✔ Was able to create a {0} account for {1} with a balance of ${2} at {3}", type1, owner1, balance1, bank.Name);

      double amount = 300.00;
      bank.Deposit(owner1, type1, amount);

      balance1 = bank.GetBalance(owner1, type1);
      Console.WriteLine("✔ Was able to deposit ${0} into {1}'s {2} account with a new balance of ${3} at {4}", amount, owner1, type1, balance1, bank.Name);

      string owner2 = "Jane Smith";
      AccountType type2 = AccountType.Checking;

      bank.AddAccount(owner2, type2);

      double balance2 = bank.GetBalance(owner1, type1);
      Console.WriteLine("✔ Was able to create a {0} account for {1} with a balance of ${2} at {3}", type2, owner2, balance2, bank.Name);

      amount = 150.00;
      bank.Transfer(owner1, type1, owner2, type2, amount);

      balance1 = bank.GetBalance(owner1, type1);
      balance2 = bank.GetBalance(owner1, type1);
      Console.WriteLine("✔ Was able to transfer a ${0} from {1} (New Balance ${2}) to {3} (New Balance ${4}) at {5}", amount, owner1, balance1, owner2, balance2, bank.Name);
    }
    public static void TransferTestNegative()
    {
      Console.WriteLine("--- Transfer Test Negative ---");

      Bank bank = new Bank("Bank");
      string owner1 = "John Doe";
      AccountType type1 = AccountType.Checking;

      bank.AddAccount(owner1, type1);

      double balance1 = bank.GetBalance(owner1, type1);
      Console.WriteLine("✔ Was able to create a {0} account for {1} with a balance of ${2} at {3}", type1, owner1, balance1, bank.Name);

      double amount = 300.00;
      bank.Deposit(owner1, type1, amount);

      balance1 = bank.GetBalance(owner1, type1);
      Console.WriteLine("✔ Was able to deposit ${0} into {1}'s {2} account with a new balance of ${3} at {4}", amount, owner1, type1, balance1, bank.Name);

      string owner2 = "Jane Smith";
      AccountType type2 = AccountType.Checking;

      bank.AddAccount(owner2, type2);

      double balance2 = bank.GetBalance(owner1, type1);
      Console.WriteLine("✔ Was able to create a {0} account for {1} with a balance of ${2} at {3}", type2, owner2, balance2, bank.Name);

      amount = -50.00;
      try
      {
        bank.Transfer(owner1, type1, owner2, type2, amount);
      }
      catch(ImproperAmount e)
      {
        Console.WriteLine("✔ Was unable to transfer an incorrect amount of ${0} with exception - {1}", amount, e.ToString());
      }

      amount = 50.00;
      owner1 = "Bob Bobson";
      try
      {
        bank.Transfer(owner1, type1, owner2, type2, amount);
      }
      catch(AccountNotFound e)
      {
        Console.WriteLine("✔ Was unable to transfer from non-existent account with exception - {0}", e.ToString());
      }

      owner1 = "John Doe";
      owner2 = "Autumn Aperson";
      try
      {
        bank.Transfer(owner1, type1, owner2, type2, amount);
      }
      catch(AccountNotFound e)
      {
        Console.WriteLine("✔ Was unable to transfer to non-existent account with exception - {0}", e.ToString());
      }

      amount = 501.00;
      owner2 = "Jane Smith";
      try
      {
        bank.Transfer(owner1, type1, owner2, type2, amount);
      }
      catch(WithdrawLimit e)
      {
        Console.WriteLine("✔ Was unable to transfer more than the withdraw limit with exception - {0}", e.ToString());
      }

      amount = 350.00;
      try
      {
        bank.Transfer(owner1, type1, owner2, type2, amount);
      }
      catch(InsufficientFunds e)
      {
        Console.WriteLine("✔ Was unable to transfer more than is currently in the from account ${0} with exception - {1}", balance1, e.ToString());
      }
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      Test.AddAccountTestPositive();
      Test.AddAccountTestNegative();
      Test.DepositTestPosivite();
      Test.DepositTestNegative();
      Test.WithdrawTestPositive();
      Test.WithdrawTestNegative();
      Test.TransferTestPositive();
      Test.TransferTestNegative();
    }
  }
}
