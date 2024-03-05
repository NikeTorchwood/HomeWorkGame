namespace HomeWorkGame.Models;

public class RandomNumber
{
    public readonly int Value;

    public RandomNumber()
    {
        Value = new Random().Next();
    }

    public RandomNumber(int rangeFrom, int rangeTo)
    {
        
    }
}