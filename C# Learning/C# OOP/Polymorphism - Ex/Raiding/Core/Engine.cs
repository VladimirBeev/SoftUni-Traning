using Raiding.Core.Interfaces;
using Raiding.Factory.Interfaces;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly IHerosFactory herosFactory;
        public Engine(IHerosFactory herosFactory)
        {
            this.herosFactory = herosFactory;
        }
        public void Start()
        {
            List<BaseHero> hero = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                try
                {
                    hero.Add(herosFactory.CreateHero(name, type));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            int boss = int.Parse(Console.ReadLine());
            int powerHeros = 0;
            foreach (var item in hero)
            {
                Console.WriteLine(item.CastAbility());
                powerHeros += item.Power;
            }
            if (powerHeros >= boss)
            {
                Console.WriteLine("Victory!");
            }
            else
                Console.WriteLine("Defeat...");
        }
    }
}
