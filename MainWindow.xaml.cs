using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using CommandLine;

namespace LGC_Backup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            string[] args = Environment.GetCommandLineArgs();

            // start here - reading command line arguments
            

            if (args.Length > 1)
            {
                // testing statements
                //Console.WriteLine($"Command line args: {string.Join(Environment.NewLine, args.Select(s => s))}");
                //System.Windows.MessageBox.Show($"Command line args: {string.Join(Environment.NewLine, args.Select(s => s))}");
                
                //parse arguments to dictionary using LINQ (totally unecessary)
                //var argDict = args.Select((index, value) => new {index, value})
                //                 .ToDictionary(pair => pair.value, pair => pair.index);
                // for testing
                // System.Windows.MessageBox.Show($"Command line args: {argDict[1]}");
            }

            InitializeComponent();
        }

        private void newJobBtn_Click(object sender, RoutedEventArgs e)
        {
            NewBackupWindow newBackupWindow = new NewBackupWindow();
            newBackupWindow.Show();
        }

        private void loadJobBtn_Click(object sender, RoutedEventArgs e)
        {
            string jobFileName;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                          @"\Data\";
            openFileDialog.Filter = "json files ($.json)|*.json| All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                jobFileName = openFileDialog.FileName;
                JobFile loadedJob = new JobFile();

                // gets the filename from the path
                Regex regex = new Regex(@"([^\\]*)\.json");
                Match match = regex.Match(jobFileName);
                string thisJobName = match.Groups[1].Value;
                //Console.WriteLine("REGEX MATCH = " + thisJobName);

                loadedJob = JobFile.ReadJobFile(jobFileName);
                Console.Write(jobFileName);

                // START HERE -- append info to listview control in MainWindow
                listView.Items.Clear();
                listView.Items.Add($"Backup Job: {thisJobName}");
                listView.Items.Add("Source directories:");
                foreach (string src in loadedJob.SourceDirectories)
                {
                    listView.Items.Add(src);
                }
                listView.Items.Add("Destination directories:");
                foreach (string dst in loadedJob.DestinationDirectories)
                {
                    listView.Items.Add(dst);
                }
            }
        }
    }
}
