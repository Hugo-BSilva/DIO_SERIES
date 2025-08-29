using DIO.Series.Interfaces;

namespace DIO.Series.ConsoleUI;

internal class ConsoleWrapper: IConsole
{
    public string ReadLine()
    {
        return Console.ReadLine() ?? string.Empty;
    }

    public void WriteLine(string message) => Console.WriteLine(message);
    public void Clear() => Console.Clear();
}