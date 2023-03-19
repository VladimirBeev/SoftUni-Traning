using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            var knights = new HashSet<Knight>();
            var barbarians = new HashSet<Barbarian>();

            foreach (var hero in players)
            {
                if (hero.IsAlive)
                {
                    if (hero is Knight)
                    {
                        knights.Add((Knight)hero);
                    }
                    else if (hero is Barbarian)
                    {
                        barbarians.Add((Barbarian)hero);
                    }
                }
            }

            while (true)
            {
                var aliveKnights = 0;
                var aliveBarbarians = 0;
                var allKnightsDead = true;
                var allBarbarianDead = true;
                foreach (var knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        allKnightsDead = false;
                        aliveKnights++;
                        foreach (var barbarian in barbarians)
                        {
                            if (barbarian.IsAlive)
                            {
                                barbarian.TakeDamage(knight.Weapon.DoDamage());
                            }
                        }
                    }
                }

                foreach (var barbarian in barbarians)
                {
                    if (barbarian.IsAlive)
                    {
                        allBarbarianDead = false;
                        aliveBarbarians++;
                        foreach (var knight in knights)
                        {
                            knight.TakeDamage(barbarian.Weapon.DoDamage());
                        }
                    }
                }
                if (allBarbarianDead)
                {
                    var killKnight = knights.Count - aliveKnights;
                    return $"The knights took {killKnight} casualties but won the battle.";
                    
                }
                else if (allKnightsDead)
                {
                    var killbarbarians = barbarians.Count - aliveBarbarians;
                    return $"The barbarians took {killbarbarians} casualties but won the battle.";
                    
                }
            }
            throw new InvalidOperationException();
        }
    }
}
