using HomeWorkGame.Models;
using HomeWorkGame.Services.ServicesAbstractions;

namespace HomeWorkGame.Services.ServiceContracts;

public class GameDifficulty : IGameDifficulty
{
    private int _randomNumber;
    private int _attempt;
   
    public void CreateRandomNumber(int rangeFrom, int rangeTo)
    {
        _randomNumber = new Random().Next(rangeFrom, rangeTo);
    }

    public void CreateRandomNumber()
    {
        _randomNumber = new Random().Next();
    }

    public void CreateAmountToAttempt(int amountToAttempt)
    {
        _attempt = amountToAttempt;
    }

    public bool CheckAttemptIsNull()
    {
        return _attempt == 0;
    }

    public int CalculateRemainingAttempts(int currentAttempt)
    {
        return _attempt - currentAttempt;
    }

    public int GetHiddenNumber()
    {
        return _randomNumber;
    }
}