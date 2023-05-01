public sealed class Treasury : SingletonBase<Treasury>
{
    public float GameBalance {get; private set; }= 100;
    public float BankBalance {get; private set; } = 100;
    private Bank bank;

    public void Deposit(float amount)
    {
      if(amount > GameBalance) return;
      GameBalance -= amount;
      BankBalance += amount;
    }

    public void Withdraw(float amount)
    {
      if(amount > BankBalance) return;
      BankBalance -= amount;
      GameBalance += amount;
    }

    public float StartGame()
    {
      float bal = GameBalance;
      GameBalance = 0;
      return bal;
    }
    public void EndGame(float amount)
    {
      AddFunds(amount);
      BankBalance = bank.GenerateReturn(BankBalance);
    }

    private void AddFunds(float amount)
    {
      GameBalance += amount;
    }
}