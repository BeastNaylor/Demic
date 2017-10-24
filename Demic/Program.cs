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
            var locationManager = new LocationManager();
            var gameManager = new GameManager(interactionManager, locationManager);
            gameManager.Start();
        }
    }
}
