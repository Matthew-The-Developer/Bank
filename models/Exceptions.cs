using System;

namespace bank.models
{
  public class AccountNotFound : Exception
  {
    public AccountNotFound(string message) {}
  }
  public class AccountAlreadyExists : Exception
  {
    public AccountAlreadyExists(string message) {}
  }
  public class ImproperAmount : Exception
  {
    public ImproperAmount(string message) {}
  }
  public class InsufficientFunds : Exception
  {
    public InsufficientFunds(string message) {}
  }
  public class WithdrawLimit : Exception
  {
    public WithdrawLimit(string message) {}
  }
}