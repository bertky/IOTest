    using System;
    using System.Management.Automation;

    namespace IOTest
    {
        [Cmdlet( VerbsDiagnostic.Resolve , "IOTest")]
        public class ResolveMyCmdletCommand : PSCmdlet
        {
            [Parameter(Position=0)]
            public Object InputObject { get; set; }

            protected override void EndProcessing()
            {
                this.WriteObject(this.InputObject);
                base.EndProcessing();
            }
        }
    }