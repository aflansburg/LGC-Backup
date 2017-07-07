using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;


namespace LGC_Backup
{
    class JobFile
    {
        // variables
        public string JobName { get; set; }

        public List<string> SourceDirectories = new List<string>();
        public List<string> DestinationDirectories = new List<string>();
        public Dictionary<string, List<string>> JobParameters = new Dictionary<string, List<string>>();

        // methods to assign values to variables
        public void AddSource(string sourcePath)
        {
            SourceDirectories.Add(sourcePath);
        }

        public void AddDestination(string destinationPath)
        {
            DestinationDirectories.Add(destinationPath);
        }

        public void AddJobParameters(string itemType, List<string> item)
        {
            JobParameters.Add(itemType, item);
        }

        public static void WriteJobFile(JobFile jobFile)
        {
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Data\";

            jobFile.AddJobParameters("SourceDirectories", jobFile.SourceDirectories);
            jobFile.AddJobParameters("DestinationDirectories", jobFile.DestinationDirectories);

            // Serialize jobfile parameters into JSON
            string jobFileJSON = JsonConvert.SerializeObject(jobFile.JobParameters, Formatting.Indented);
            
            File.WriteAllText(savePath + @"\" + jobFile.JobName, jobFileJSON);
        }

        public static JobFile ReadJobFile(string jobFilename)
        {
            using (StreamReader file = File.OpenText(jobFilename))
            {
                JsonSerializer serializer = new JsonSerializer();
                JobFile jobfile = (JobFile) serializer.Deserialize(file, typeof(JobFile));
                return jobfile;
            }
        } 
    }
}
