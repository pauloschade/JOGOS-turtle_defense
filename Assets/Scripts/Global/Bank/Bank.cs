public class Bank : SingletonBase<Bank>
{
  public static float CumulativeIntrest { get; private set; }
  private static float interestRate = 1.05f;

  public float GenerateReturn(float amount)
  {
    float returnAmount = amount * interestRate;
    AccumulateInterest();
    return returnAmount;
  }

  private void AccumulateInterest()
  {
    CumulativeIntrest *= interestRate;
  }
}