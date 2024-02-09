using HomeWorkGame.Models;
using HomeWorkGame.Services.ServiceBuilder.ServiceBuilderAbstractions;
using HomeWorkGame.Services.ServiceContracts;
using HomeWorkGame.UserInterface.UserInterfaceAbstractions;

namespace HomeWorkGame.Services.ServiceBuilder.ServiceBuilderImplementations;

public class HardGameDifficultyBuilder(IUserInterface ui) : GameDifficultyBuilder
{
    private readonly GameDifficulty _gameDifficulty = new();

    public override GameDifficulty GetResult()
    {
        return _gameDifficulty;
    }

    public override void SetRandomNumber()
    {
        ui.PrintMessage("Ограничения на загадываемое число не будет..");
        _gameDifficulty.RandomNumber = new RandomNumber();
    }

    public override void SetGameDifficulty()
    {
        ui.PrintMessage("Устанавливаем ограничение на количество попыток..");
        ui.PrintMessage("Введите число попыток, за которое вы готовы угадать число..");
        var amountToAttempt = ui.GetUserNumber();
        _gameDifficulty.Attempt = new Attempt(amountToAttempt);
    }
}