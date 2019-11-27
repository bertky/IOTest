using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;

namespace IOTest
{
    [Cmdlet( VerbsDiagnostic.Resolve , "IOTest")]
    public class ResolveIOTestCommand : PSCmdlet
    {
        [Parameter(Position=0)]
        [ValidateNotNullOrEmpty]
        public string InputFileName { get; set; }

        [Parameter(Position=1)]
        [ValidateNotNullOrEmpty]
        public string OutputFileName { get; set; }

        protected override void EndProcessing()
        {
        	try
        	{
        		using (StreamReader sr = new StreamReader(InputFileName))
        		{
        			try
        			{
	        			using (StreamWriter sw = new StreamWriter(OutputFileName))
	        			{
		        			string line;
		        			while ((line = sr.ReadLine()) != null)
		        			{
		        				sw.WriteLine(line);
		        			}
		        		}
		        	}
		        	catch (Exception e)
		        	{
		        		Console.WriteLine("Couldn't Write File");
		        		Console.WriteLine(e.Message);
		        	}
		        }
        	}
        	catch (Exception e)
        	{
        		Console.WriteLine("Couldn't Read File");
        		Console.WriteLine(e.Message);
        	}

            this.WriteObject(this.InputFileName);
            this.WriteObject(this.OutputFileName);
            base.EndProcessing();
        }
    }
}