using System.Text;
using HomeWorkGame.UserInterface.UserInterfaceAbstractions;
using HomeWorkGame.UserInterface.UserInterfaceContracts;

namespace HomeWorkGame.UserInterface.UserInterfaceImplementations;

public class ConsoleUserInterface : IUserInterface
{
    private ConsoleKeyInfo _ki;
    private (int, int) _pos;

    public void PrintMessage(string text)
    {
        Console.WriteLine(text);
    }

    private void PrintHeaderMenu(string text)
    {
        Console.WriteLine(text);
        _pos = Console.GetCursorPosition();
    }

    public int GetUserNumber()
    {
        bool isNum;
        int result;
        do
        {
            isNum = int.TryParse(Console.ReadLine(), out result);
            if (!isNum)
            {
                PrintMessage("Было введено не число, попробуйте снова..");
            }
        } while (!isNum);
        return result;
    }

    public void ClearUI()
    {
        Console.Clear();
    }
    public int GetIndexMenuPoint(Menu menu)
    {
        PrintHeaderMenu(menu.Header);
        _pos = Console.GetCursorPosition();
        var cursorPos = 0;
        do
        {
            var itemsText = GetMenuItems(menu.PointMenu, cursorPos);
            Console.SetCursorPosition(_pos.Item1, _pos.Item2);
            PrintMessage(itemsText);
            _ki = Console.ReadKey();
            switch (_ki.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.LeftArrow:
                    if (cursorPos > 0)
                    {
                        cursorPos--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.DownArrow:
                    if (cursorPos < menu.PointMenu.Count - 1)
                    {
                        cursorPos++;
                    }
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    PrintMessage($"Было выбрано \"{menu.PointMenu[cursorPos]}\"");
                    break;
                default:
                    PrintMessage("Нажимайте на стрелочки для выбора, когда выберите пункт меню нажмите Enter..");
                    break;
            }
        } while (_ki.Key != ConsoleKey.Enter);
        return cursorPos;
    }
    private string GetMenuItems(List<string> items, int cursorPos)
    {
        var sb = new StringBuilder();
        for (var i = 0; i <= items.Count - 1; i++)
        {
            if (i == items.Count - 1)
            {
                sb.Append(cursorPos == i ? '>' : ' ');
                sb.Append(items[i]);
            }
            else
            {
                sb.Append(cursorPos == i ? '>' : ' ');
                sb.AppendLine(items[i]);
            }
        }
        return sb.ToString();
    }
}