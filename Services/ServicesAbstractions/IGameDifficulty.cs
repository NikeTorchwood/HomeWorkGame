namespace HomeWorkGame.Services.ServicesAbstractions;

public interface IGameDifficulty
{
    public void CreateRandomNumber(int rangeFrom, int rangeTo);
    public void CreateRandomNumber();
    public void CreateAmountToAttempt(int amountToAttempt);
    public bool CheckAttemptIsNull();
    int CalculateRemainingAttempts(int currentAttempt);
    int GetHiddenNumber();
}