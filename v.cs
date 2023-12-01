//Process Control using Signals (Windows API):
using System;
using System.Runtime.InteropServices;

class Program
{
    const int CTRL_C_EVENT = 0;

    [DllImport("kernel32.dll")]
    static extern bool SetConsoleCtrlHandler(ConsoleCtrlHandlerDelegate handler, bool add);

    delegate bool ConsoleCtrlHandlerDelegate(int eventType);

    static bool ConsoleCtrlHandler(int eventType)
    {
        if (eventType == CTRL_C_EVENT)
        {
            Console.WriteLine("Ctrl+C received. Performing cleanup.");
        }
        return false;
    }

    static void Main()
    {
        SetConsoleCtrlHandler(new ConsoleCtrlHandlerDelegate(ConsoleCtrlHandler), true);

        Console.WriteLine("Press Ctrl+C to simulate a signal.");
        Console.ReadLine();
    }
}
