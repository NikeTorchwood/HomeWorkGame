using HomeWorkGame.Services.ServiceBuilder;
using HomeWorkGame.Services.ServiceBuilder.ServiceBuilderAbstractions;
using HomeWorkGame.Services.ServiceBuilder.ServiceBuilderImplementations;
using HomeWorkGame.Services.ServiceBuilder.ServiceBuilderInfrastructure;
using HomeWorkGame.UserInterface.UserInterfaceAbstractions;
using HomeWorkGame.UserInterface.UserInterfaceContracts;

namespace HomeWorkGame.Services.ServiceImplementation;

public class GameService(IUserInterface ui)
{
    private readonly Menu _startMenu = new(
        "Для запуска нажмите Enter..",
        [
            "Старт игры",
            "Выход"
        ]);

    private readonly Menu _restartMenu = new(
        "Хотите повторить?",
        [
            "Да, начать заного",
            "Нет, закончить игру"
        ]);

    private readonly Menu _chooseDifficultyMenu = new(
        "Выберите сложность..",
        [
            "Легкая.. Ограничение диапазона случаного числа, неограниченное количество попыток",
            "Средняя.. Ограничение диапазона случаного числа, ограниченное количество попыток",
            "Сложная.. Неограниченный диапазон случанойго числа, ограниченное количество попыток"
        ]);

    public void StartGame()
    {
        StarScreen();
        do
        {
            var difficultyBuilder = ChooseDifficulty();
            var creator = new GameCreator(difficultyBuilder);
            creator.Construct();
            var difficulty = difficultyBuilder.GetResult();
            var randomGame = new RandomGame(ui, difficulty);
            randomGame.StartLevel();
        } while (RestartScreen());
    }

    private bool RestartScreen()
    {
        var userIndex = ui.GetIndexMenuPoint(_restartMenu);
        return userIndex switch
        {
            0 => true,
            1 => false,
            _ => throw new ArgumentException()
        };
    }

    private GameDifficultyBuilder ChooseDifficulty()
    {
        var userIndex = ui.GetIndexMenuPoint(_chooseDifficultyMenu);
        GameDifficultyBuilder result = userIndex switch
        {
            0 => new EasyGameDifficultyBuilder(ui),
            1 => new MediumGameDifficultyBuilder(ui),
            2 => new HardGameDifficultyBuilder(ui),
            _ => throw new ArgumentException()
        };
        return result;
    }

    private void StarScreen()
    {
        ui.PrintMessage("Приветствуем! Вы запустили игру \"Угадай число\"!");
        var userIndex = ui.GetIndexMenuPoint(_startMenu);
        switch (userIndex)
        {
            case 0:
                return;
            case 1:
                CloseApp();
                break;
        }
    }

    private static void CloseApp()
    {
        Environment.Exit(0);
    }
}