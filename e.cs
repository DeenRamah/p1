//Program to List and Delete Files:

using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

class FileListDeleter : Form
{
    private ListBox listBox;
    private Button deleteButton;

    public FileListDeleter()
    {
        // Initialize UI components
        listBox = new ListBox();
        deleteButton = new Button();

        // Set properties
        listBox.Dock = DockStyle.Fill;
        deleteButton.Dock = DockStyle.Bottom;
        deleteButton.Text = "Delete Selected Files";
        deleteButton.Click += DeleteButton_Click;

        // Add UI components to the form
        Controls.Add(listBox);
        Controls.Add(deleteButton);

        // Populate list with files having .MUX extension
        string[] files = Directory.GetFiles(".", "*.MUX");
        listBox.Items.AddRange(files.Select(Path.GetFileName).ToArray());
    }

    private void DeleteButton_Click(object sender, EventArgs e)
    {
        // Delete selected files
        foreach (var selectedFile in listBox.SelectedItems)
        {
            File.Delete(selectedFile.ToString());
        }

        // Refresh the list
        string[] updatedFiles = Directory.GetFiles(".", "*.MUX");
        listBox.Items.Clear();
        listBox.Items.AddRange(updatedFiles.Select(Path.GetFileName).ToArray());
    }

    static void Main()
    {
        Application.Run(new FileListDeleter());
    }
}
