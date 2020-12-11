using System;

namespace calculatorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "КАЛЬКУЛЯТОР";
            OutputConsole outputConsole = new OutputConsole();
            outputConsole.SetTimer();
            outputConsole.OutputConsoleText();
            outputConsole.ReadConsoleText();
        }
    }
}
