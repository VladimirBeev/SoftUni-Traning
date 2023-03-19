using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private Dictionary<string, IEgg> eggs;
        public EggRepository()
        {
            this.eggs = new Dictionary<string, IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models => this.eggs.Values;
        public void Add(IEgg model)
        {
            this.eggs.Add(model.Name, model);
        }

        public IEgg FindByName(string name)
        {
            var finde = this.eggs.First(b => b.Key == name);
            if (finde.Key == null)
            {
                return null;
            }
            return finde.Value;
        }

        public bool Remove(IEgg model)
        {
            return this.eggs.Remove(model.Name);
        }
    }
}
