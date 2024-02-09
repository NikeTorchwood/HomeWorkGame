using HomeWorkGame.Services.ServiceBuilder.ServiceBuilderAbstractions;

namespace HomeWorkGame.Services.ServiceBuilder.ServiceBuilderInfrastructure;

public class GameCreator(GameDifficultyBuilder builder)
{
    public void Construct()
    {
        builder.SetRandomNumber();
        builder.SetGameDifficulty();
    }
}