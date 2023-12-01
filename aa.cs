//program using Windows Forms that lists all files with the ".MUX" extension in a ListBox and provides a button to delete the selected file on a click.

using System;
using System.IO;
using System.Windows.Forms;

namespace FileListDeleterApp
{
    public partial class FileListDeleterForm : Form
    {
        private ListBox fileListBox;
        private Button deleteButton;

        public FileListDeleterForm()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Initialize and configure ListBox
            fileListBox = new ListBox
            {
                Dock = DockStyle.Fill
            };

            // Initialize and configure Delete button
            deleteButton = new Button
            {
                Dock = DockStyle.Bottom,
                Text = "Delete Selected File(s)",
                Enabled = false
            };
            deleteButton.Click += DeleteButton_Click;

            // Add controls to the form
            Controls.Add(fileListBox);
            Controls.Add(deleteButton);

            // Load files with ".MUX" extension into the ListBox
            LoadFiles();

            // Enable the Delete button only if there are files in the ListBox
            deleteButton.Enabled = fileListBox.Items.Count > 0;
        }

        private void LoadFiles()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.MUX");
            fileListBox.Items.AddRange(files);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // Delete selected files
            foreach (var selectedItem in fileListBox.SelectedItems)
            {
                File.Delete(selectedItem.ToString());
            }

            // Refresh the list
            fileListBox.Items.Clear();
            LoadFiles();

            // Disable the Delete button if there are no files in the ListBox
            deleteButton.Enabled = fileListBox.Items.Count > 0;
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FileListDeleterForm());
        }
    }
}
