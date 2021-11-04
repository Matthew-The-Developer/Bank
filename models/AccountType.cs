namespace bank.models
{
  public enum AccountType
  {
    Checking,
    Individual,
    Corporate,
    Investment = Individual | Corporate
  }
}