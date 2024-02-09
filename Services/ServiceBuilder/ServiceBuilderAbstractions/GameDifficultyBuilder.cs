using HomeWorkGame.Services.ServiceContracts;

namespace HomeWorkGame.Services.ServiceBuilder.ServiceBuilderAbstractions;

public abstract class GameDifficultyBuilder
{
    public GameDifficultyBuilder()
    {
    }
    public abstract GameDifficulty GetResult();
    public abstract void SetRandomNumber();
    public abstract void SetGameDifficulty();
}