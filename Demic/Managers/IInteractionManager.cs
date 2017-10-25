using Demic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demic.Managers
{
    interface IInteractionManager
    {
        string ReadInput(string message);
        string ReadInput(string message, List<string> options);

        void OutputContent(string message, OutputLevel level = OutputLevel.Information);
    }
}
