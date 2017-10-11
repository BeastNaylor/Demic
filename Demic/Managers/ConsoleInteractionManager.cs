﻿using Demic.Enums;
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

        public string ReadInput(string message, List<string> options)
        {
            bool inputValid = false;
            string input;
            do
            {
                this.OutputContent(message);
                this.OutputContent("[Options are: " + String.Join(", ", options.ToArray()) + "]");
                input = Console.ReadLine().ToUpper();
                this.OutputContent(input, OutputLevel.Debug);
                if (options.Contains(input))
                {
                    inputValid = true;
                }
                else
                {
                    this.OutputContent("Invalid selection. Please try again.");
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

        internal void Pause()
        {
            Console.ReadKey();
        }
    }
}
