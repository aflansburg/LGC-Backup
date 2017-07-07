using System;
using System.Windows;
using System.IO;
using System.Windows.Forms;

namespace LGC_Backup
{
    /// <summary>
    /// Interaction logic for NewBackupWindow.xaml
    /// </summary>
    public partial class NewBackupWindow : Window
    {
        public NewBackupWindow()
        {
            InitializeComponent();
        }

        private JobFile _newJobFile = new JobFile();

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void saveJobBtn_Click(object sender, RoutedEventArgs e)
        {
            string jobFileName = jobNameTxtBox.Text + ".json";
            if (String.IsNullOrWhiteSpace(jobFileName))
            {
                // display error
            }
            else if (File.Exists(jobFileName))
            {
                // display File exists, overwrite?
            }
            else
            {
                _newJobFile.JobName = jobFileName;

                foreach (string src in sourcesListBox.Items)
                {
                    _newJobFile.AddSource(src);
                }
                foreach (string dest in destListBox.Items)
                {
                    _newJobFile.AddDestination(dest);
                }

                JobFile.WriteJobFile(_newJobFile);
                string jobFileDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                    @"\Data\";
                string msgCaption = "LGC Backup: New Job File";
                string msgText = $"New job {jobFileName} created and saved to {jobFileDir}.";
                MessageBoxButton msgButton = MessageBoxButton.OK;
                
                MessageBoxImage msgIcon = MessageBoxImage.Information;

                System.Windows.MessageBox.Show(msgText, msgCaption, msgButton, msgIcon);
            }
        }

        private void addSrcBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    string chosenPath = dialog.SelectedPath;
                    sourcesListBox.Items.Add(chosenPath);
                }
            }
        }

        private void addDestBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    string chosenPath = dialog.SelectedPath;
                    destListBox.Items.Add(chosenPath);
                }
            }
        }
    }
}
