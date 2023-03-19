using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private Dictionary<string,IVessel> vessels;

        public VesselRepository()
        {
            this.vessels = new Dictionary<string, IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models => this.vessels.Values;

        public void Add(IVessel model)
        {
            
            this.vessels.Add(model.Name,model);
        }

        public IVessel FindByName(string name)
        {
            if (this.vessels.ContainsKey(name))
            {
                return this.vessels[name];
            }
            return null;
        }

        public bool Remove(IVessel model)
        {
            return this.vessels.Remove(model.Name);
        }
    }
}
