using System;

namespace bank.models
{
  public class Transaction
  {
    public double Amount { get; }
    public TransactionType Type { get; }
    public DateTime CompletedOn { get; }

    public Transaction(double amount, TransactionType type)
    {
      Amount = amount;
      Type = type;
      CompletedOn = DateTime.Now;
    }

    public override string ToString()
    {
      return Type + "\t" + Amount + "\t" + CompletedOn;
    }
  }
}