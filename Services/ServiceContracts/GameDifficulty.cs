using HomeWorkGame.Models;

namespace HomeWorkGame.Services.ServiceContracts;

public class GameDifficulty
{
    public RandomNumber RandomNumber { get; set; }
    public Attempt Attempt { get; set; }
}