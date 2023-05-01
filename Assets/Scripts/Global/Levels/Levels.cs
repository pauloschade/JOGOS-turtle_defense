public class Levels : SingletonBase<Levels>
{
  public bool[] levelArray = new bool[10];

  protected override void Init() {
    levelArray[0] = true;
    for(int i = 1; i < levelArray.Length; i++)
    {
      levelArray[i] = false;
    }
    return;
  }
  public void UnlockLevel(int level)
  {
    levelArray[level] = true;
  }

}