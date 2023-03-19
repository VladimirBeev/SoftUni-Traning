using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factory.Interfaces
{
    public interface IHerosFactory
    {
        BaseHero CreateHero(string name,string type);
    }
}
