using HomeWorkGame.Models.Enums;
using HomeWorkGame.Services.ServiceContracts;
using HomeWorkGame.Services.ServiceContracts.Enums;
using HomeWorkGame.Services.ServicesAbstractions;
using HomeWorkGame.UserInterface.UserInterfaceAbstractions;

namespace HomeWorkGame.Services.ServiceImplementation;

public class RandomGame : IRandomGame
{
    private readonly IUserInterface _ui;
    private readonly IGameDifficulty _gameDifficulty;
    private int _currentAttempt;
    public RandomGame(IUserInterface ui, IGameDifficulty gameDifficulty)
    {
        _ui = ui;
        _gameDifficulty = gameDifficulty;
    }
    public void StartLevel()
    {
        var isGameOver = false;
        while (!isGameOver)
        {
            isGameOver = GetUserTry() switch
            {
                GameStates.GameOver => true,
                GameStates.GameContinues => false,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

    private AttemptStates CheckIsAttemptsLeft()
    {
        if (_gameDifficulty.CheckAttemptIsNull())
        {
            return AttemptStates.HaveAttempts;
        }

        var remainingAttempt = _gameDifficulty.CalculateRemainingAttempts(_currentAttempt);
        if (remainingAttempt>0)
        {
            _ui.PrintMessage($"Осталось {remainingAttempt} попыток..");
            return AttemptStates.HaveAttempts;
        }
        _ui.ClearUI();
        _ui.PrintMessage("Увы, но попыток не осталось..");
        return AttemptStates.AttemptsOver;
    }

    private GameStates GetUserTry()
    {
        _ui.PrintMessage("Укажите ваше число и нажмите Enter..");
        switch (CheckIsAttemptsLeft())
        {
            case AttemptStates.AttemptsOver:
                _ui.PrintMessage($"Конец игры.. Загаданное число было {_gameDifficulty.GetHiddenNumber()}..");
                return GameStates.GameOver;
            case AttemptStates.HaveAttempts:
                _currentAttempt++;
                var userNumber = _ui.GetUserNumber();
                var hiddenNumber = _gameDifficulty.GetHiddenNumber();
                if (hiddenNumber < userNumber)
                {
                    _ui.PrintMessage("Загаданное число меньше, вашего..");
                    return GameStates.GameContinues;
                }

                if (hiddenNumber > userNumber)
                {
                    _ui.PrintMessage("Загаданное число больше, вашего..");
                    return GameStates.GameContinues;
                }

                if (hiddenNumber != userNumber) return GameStates.GameContinues;
                _ui.ClearUI();
                _ui.PrintMessage("Поздравляем! Вы угадали число!!!");
                return GameStates.GameOver;
            default:
                return GameStates.GameContinues;
        }
    }
}
