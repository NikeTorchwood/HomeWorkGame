using HomeWorkGame.Services.ServiceContracts;
using HomeWorkGame.Services.ServicesAbstractions;

namespace HomeWorkGame.Services.ServiceBuilder.ServiceBuilderAbstractions;

public abstract class GameDifficultyBuilder
{
    public GameDifficultyBuilder()
    {
    }
    public abstract IGameDifficulty GetResult();
    public abstract void SetRandomNumber();
    public abstract void SetGameDifficulty();
}