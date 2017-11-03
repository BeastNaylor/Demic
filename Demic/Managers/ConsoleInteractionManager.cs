using Demic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demic.Managers
{
    class ConsoleInteractionManager : IInteractionManager
    {
        private OutputLevel _minimumLevel;

        public ConsoleInteractionManager(OutputLevel level)
        {
            _minimumLevel = level;
        }

        public string ReadInput(string message, List<string> options = null)
        {
            bool inputValid = false;
            bool restrictedInput = (options != null);
            string input;
            do
            {
                this.OutputContent(message);
                if (restrictedInput)
                {
                    this.OutputContent("[Options are: " + String.Join(", ", options.ToArray()) + "]");    
                }
                else
                {
                    this.OutputContent("[Max Length: " + Properties.Settings.Default.MAX_INPUT_LENGTH + "]");
                }
                input = Console.ReadLine().ToUpper();
                this.OutputContent("---" + System.Environment.NewLine);
                if ((options.Contains(input) && restrictedInput) || (!restrictedInput && input.Length <= Properties.Settings.Default.MAX_INPUT_LENGTH))
                {
                    inputValid = true;
                }
                else
                {
                    if (restrictedInput)
                    {
                        this.OutputContent("Invalid selection. Please try again.");
                    }
                    else
                    {
                        this.OutputContent("Input too long. Please try again.");
                    }
                }
            } while (!inputValid);
            return input;
        }

        public void OutputContent(string message, OutputLevel level = OutputLevel.Information)
        {
            if (_minimumLevel <= level)
            {
                Console.WriteLine(message);
            }
        }

        public void Pause()
        {
            Console.ReadKey();
        }

        public void ClearOutput()
        {
            Console.Clear();
        }
    }
}
