using HomeWorkGame.UserInterface.UserInterfaceContracts;

namespace HomeWorkGame.UserInterface.UserInterfaceAbstractions;

public interface IUserInterface
{
    void PrintMessage(string text);
    int GetUserNumber();
    int GetIndexMenuPoint(Menu menu);
    void ClearUI();
}