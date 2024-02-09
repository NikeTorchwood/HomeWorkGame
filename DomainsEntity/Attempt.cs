namespace HomeWorkGame.Models;

public class Attempt
{
    public int AmountToAttempt { get; }

    public Attempt(int amountToAttempt)
    {
        AmountToAttempt = amountToAttempt;
    }
}