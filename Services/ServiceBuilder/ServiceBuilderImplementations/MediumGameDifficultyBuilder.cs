using HomeWorkGame.Models;
using HomeWorkGame.Services.ServiceBuilder.ServiceBuilderAbstractions;
using HomeWorkGame.Services.ServiceContracts;
using HomeWorkGame.UserInterface.UserInterfaceAbstractions;

namespace HomeWorkGame.Services.ServiceBuilder.ServiceBuilderImplementations;

public class MediumGameDifficultyBuilder(IUserInterface ui) : GameDifficultyBuilder
{
    private readonly GameDifficulty _gameDifficulty = new();

    public override GameDifficulty GetResult()
    {
        return _gameDifficulty;
    }

    public override void SetRandomNumber()
    {
        ui.PrintMessage("Устанавливаем ограничение на загадываемое число..");
        ui.PrintMessage("Введите число, с которого начинается ограничение числа..");
        var rangeFrom = ui.GetUserNumber();
        ui.PrintMessage("Введите число, на котором заканчивается ограничение числа..");
        var rangeTo = ui.GetUserNumber();
        _gameDifficulty.RandomNumber = new RandomNumber(rangeFrom, rangeTo);
    }

    public override void SetGameDifficulty()
    {
        ui.PrintMessage("Устанавливаем ограничение на количество попыток..");
        ui.PrintMessage("Введите число попыток, за которое вы готовы угадать число..");
        var amountToAttempt = ui.GetUserNumber();
        _gameDifficulty.Attempt = new Attempt(amountToAttempt);
    }
}