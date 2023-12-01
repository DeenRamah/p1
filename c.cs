//Code to Shutdown Local Machine on Attempt to Delete System File:
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePathToDelete = "C:\\Windows\\System32\\someSystemFile.dll"; // Replace with the actual system file path

        try
        {
            // Check if the file is a system file
            if (IsSystemFile(filePathToDelete))
            {
                Console.WriteLine("Attempting to delete a system file. Shutting down the local machine...");
                System.Diagnostics.Process.Start("shutdown", "/s /t 0"); // Shutdown the machine immediately
            }
            else
            {
                File.Delete(filePathToDelete);
                Console.WriteLine("File deleted successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static bool IsSystemFile(string filePath)
    {
        // You may implement more sophisticated checks here to determine if the file is a system file
        // For simplicity, this example assumes any file in the System32 directory is a system file.
        return filePath.ToLower().Contains("system32");
    }
}
