public sealed class Treasury : SingletonBase<Treasury>
{
    private static float gameBalance = 100;
    private static float bankBalance = 100;
    private static Bank bank;

    public void Deposit(float amount)
    {
      if(amount > gameBalance) return;
      gameBalance -= amount;
      bankBalance += amount;
    }

    public void Withdraw(float amount)
    {
      if(amount > bankBalance) return;
      bankBalance -= amount;
      gameBalance += amount;
    }

    public float StartGame()
    {
      float bal = gameBalance;
      gameBalance = 0;
      return bal;
    }
    public void EndGame(float amount)
    {
      AddFunds(amount);
      bankBalance = bank.GenerateReturn(bankBalance);
    }

    private void AddFunds(float amount)
    {
      gameBalance += amount;
    }
}