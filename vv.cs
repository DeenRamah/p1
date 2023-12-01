//Code to Start and Stop Notepad:
using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        // Start Notepad
        Process notepadProcess = Process.Start("notepad.exe");

        Console.WriteLine("Notepad started. Press Enter to stop...");

        // Wait for user input to stop Notepad
        Console.ReadLine();

        // Stop Notepad
        if (notepadProcess != null && !notepadProcess.HasExited)
        {
            notepadProcess.CloseMainWindow(); // Attempt to gracefully close
            notepadProcess.WaitForExit(5000); // Wait up to 5 seconds for termination
        }

        Console.WriteLine("Notepad stopped.");
    }
}
