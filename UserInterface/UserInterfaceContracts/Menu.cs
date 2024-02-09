namespace HomeWorkGame.UserInterface.UserInterfaceContracts;

public class Menu(string header, List<string> pointMenu)
{
    public string Header { get; } = header;
    public List<string> PointMenu { get; } = pointMenu;
}