using System.Collections.Generic;
using System.Threading.Tasks;
using Topshelf;

namespace ProcessingService
{
    public class Program
    {
        public static void Main()
        {
            HostFactory.Run(x =>
            {
                x.Service<ProcessingService>(s =>
                {
                    s.ConstructUsing(name => new ProcessingService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.SetDescription("NotesProcessing");
                x.SetDisplayName("NotesProcessing");
                x.SetServiceName("NotesProcessing");
            });
        }
    }
}
