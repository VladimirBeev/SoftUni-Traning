using System;
using Raiding.Models;
using System.Collections.Generic;
using Raiding.Factory.Interfaces;
using Raiding.Factory;
using Raiding.Core.Interfaces;
using Raiding.Core;

namespace Raiding
{
    public class StartUp
    {
        static void Main()
        {
            IHerosFactory herosFactory = new HerosFactory();
            IEngine engine = new Engine(herosFactory);
            engine.Start();
        }
    }
}
