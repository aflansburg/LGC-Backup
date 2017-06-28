using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace LGC_Backup
{
    class CLI
    {

    }

    class Options
    {
        [Verb("runjob", HelpText = "Job file to read")]
        class RunJob
        {
            
        }

        [Verb("quiet", HelpText = "Run quietly, no interface")]
        class Quiet
        {
            
        }

        [Verb("autoclose", HelpText = "Autoclose the application when job finishes")]
        class AutoClose
        {
            
        }
    }
}
