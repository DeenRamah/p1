//Program to Create a File, Write a Marketing Message, and Copy Content to Folders Starting with "SALE":
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string marketingMessage = "Special Sale Offer! Limited Time Only.";

        // Create a file and write marketing message
        string filePath = "marketing_message.txt";
        File.WriteAllText(filePath, marketingMessage);

        // Get directories starting with "SALE" in the current directory
        string[] saleDirectories = Directory.GetDirectories(Directory.GetCurrentDirectory(), "SALE*");

        // Copy the marketing message to each SALE folder
        foreach (string saleDirectory in saleDirectories)
        {
            string destinationPath = Path.Combine(saleDirectory, "marketing_message.txt");

            try
            {
                File.Copy(filePath, destinationPath, true); // Overwrite if file already exists
                Console.WriteLine($"Marketing message copied to {saleDirectory}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error copying to {saleDirectory}: {ex.Message}");
            }
        }
    }
}
