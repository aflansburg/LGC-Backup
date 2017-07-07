using System;
using System.IO;
using System.Collections.Generic;
using System.Windows;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using NDesk.Options;

namespace LGC_Backup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string[] args = Environment.GetCommandLineArgs();


            if (args.Length > 1)
            {
                // hide application window
                Application.Current.MainWindow.Hide();

                string data = null;
                bool show_help = false;
                int quiet = 0;

                var p = new OptionSet()
                {
                    {"f|file=", "the path to the job file to execute", v => data = v},
                    {"q|quiet", "run in windowless mode", v => ++quiet},
                    {"h|?|help", "display help", v => show_help = v != null},
                };



                //extra arguments
                List<string> extra;
                try
                {
                    extra = p.Parse(args);
                    //could do something with arguments here
                }
                catch (OptionException e)
                {
                    ConsoleManager.Show();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try -help for more info.");
                }

                if (quiet == 0 && !show_help)
                {
                    ConsoleManager.Show();
                    Console.WriteLine("Opening interface.");
                }
                else if (quiet == 1 && data != null)
                {
                    try
                    {
                        ConsoleManager.Show();
                        Console.WriteLine($"Running headless and attempting to execute job {data}");
                        // execute backup job here

                        VssHelper.StartSnapshot(data);

                        // gets onley the job name from the path (i.e. minus the path)
                        Regex regex = new Regex(@"([^\\]*)\.json");
                        Match match = regex.Match(data);
                        string thisJobName = match.Groups[1].Value;
                        //Console.WriteLine("REGEX MATCH = " + thisJobName);

                        var loadedJob = JobFile.ReadJobFile(data);

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
                    catch (FileNotFoundException e)
                    {
                        MessageBox.Show($"Job file {data} was not found.\nCheck the file path " +
                                        $"and the name to see if it exists\nin the current " +
                                        $"working directory.");
                        Console.WriteLine("Job file not found");
                        Environment.Exit(2);
                    }
                }
                else if (show_help)
                {
                    ConsoleManager.Show();
                    Console.WriteLine("Showing help.");
                    ShowHelp(p);
                    Console.WriteLine("\nPress any key to exit.");
                    Console.Read();
                    Environment.Exit(0);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\r\nCheck your command line parameters -- use h|?|help for usage!");
                }
            }
            else
            {
                InitializeComponent();
            }
        }

        private void ShowHelp(OptionSet p)
        {
            Console.WriteLine("Usage: lgcbackup.exe -file=[path to job file]");
            Console.WriteLine("Run specified job file");
            Console.WriteLine("\nUsage: -q|quiet");
            Console.WriteLine("Run windowless - must specifiy job file");
            Console.WriteLine("\nUsage: -h|-help|-?");
            Console.WriteLine("Display this help information");
            Console.WriteLine();
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
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

                // gets the filename from the path
                Regex regex = new Regex(@"([^\\]*)\.json");
                Match match = regex.Match(jobFileName);
                string thisJobName = match.Groups[1].Value;
                //Console.WriteLine("REGEX MATCH = " + thisJobName);

                var loadedJob = JobFile.ReadJobFile(jobFileName);
                Console.Write(jobFileName);

                // START HERE -- append info to listview control in MainWindow -- need to make this a helper method
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
