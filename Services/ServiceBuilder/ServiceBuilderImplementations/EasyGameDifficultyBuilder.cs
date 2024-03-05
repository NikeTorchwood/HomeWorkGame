using HomeWorkGame.Models;
using HomeWorkGame.Services.ServiceBuilder.ServiceBuilderAbstractions;
using HomeWorkGame.Services.ServiceContracts;
using HomeWorkGame.Services.ServicesAbstractions;
using HomeWorkGame.UserInterface.UserInterfaceAbstractions;

namespace HomeWorkGame.Services.ServiceBuilder.ServiceBuilderImplementations;

public class EasyGameDifficultyBuilder(IUserInterface ui) : GameDifficultyBuilder
{
    private readonly IGameDifficulty _gameDifficulty = new GameDifficulty();

    public override IGameDifficulty GetResult()
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
        _gameDifficulty.CreateRandomNumber(rangeFrom, rangeTo);
    }

    public override void SetGameDifficulty()
    {
        ui.PrintMessage("Количество попыток неограничено..");
    }
}