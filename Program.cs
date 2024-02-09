using HomeWorkGame.Services;
using HomeWorkGame.UserInterface.UserInterfaceImplementations;

namespace HomeWorkGame
{
    public static class Program
    {
        public static void Main()
        {
            var consoleUi = new ConsoleUserInterface();
            var game = new GameService(consoleUi);
            game.StartGame();
            Console.ReadKey();
        }

    }
}

