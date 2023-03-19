using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
       
        public Rogue(string name,int power)
            : base(name,power)
        {
        }
        public override string CastAbility()
        {
            return $"{base.GetType().Name} - {base.Name} hit for {base.Power} damage";
        }
    }
}
