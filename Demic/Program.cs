using Demic.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demic
{
    class Program
    {
        static void Main(string[] args)
        {
            var interactionManager = new ConsoleInteractionManager(Demic.Enums.OutputLevel.Information);
            interactionManager.OutputContent("Hello");
            var input = interactionManager.ReadInput("Select a Letter", new List<string>() { "A", "B" });
            interactionManager.OutputContent(String.Format("Selected {0}", input));
            interactionManager.Pause();
        }
    }
}
