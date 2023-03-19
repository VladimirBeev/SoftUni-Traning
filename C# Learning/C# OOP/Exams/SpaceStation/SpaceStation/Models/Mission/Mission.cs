using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public Mission()
        {

        }
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (IAstronaut astronaut in astronauts)
            {
                if (astronaut.Oxygen != 0)
                {
                    var coutItem = planet.Items.Count;
                    for (int i = 0; i < coutItem; i++)
                    {
                        if (astronaut.Oxygen != 0)
                        {
                            
                            var item = planet.Items.First();
                            astronaut.Bag.Items.Add(item);
                            astronaut.Breath();
                            planet.Items.Remove(item);
                        }
                        else
                        {
                            break;
                        }
                    }
                    //foreach(string item in planet.Items)
                    //{
                    //    if (astronaut.Oxygen != 0)
                    //    {
                    //        astronaut.Breath();
                    //        astronaut.Bag.Items.Add(item);
                    //    }
                    //    else
                    //    {
                    //        break;
                    //    }
                    //}
                }
            }
        }
    }
}
