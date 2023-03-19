using Raiding.Factory.Interfaces;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factory
{
    public class HerosFactory : IHerosFactory
    {
        public BaseHero CreateHero(string name, string type)
        {
            BaseHero hero;
            if (type == "Druid")
            {
                hero = new Druid(name, 80);
            }
            else if (type == "Paladin")
            {
                hero = new Paladin(name, 100);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name, 80);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name, 100);
            }
            else
            {
                throw new Exception("Invalid hero!");
            }

            return hero;
        }
    }
}
