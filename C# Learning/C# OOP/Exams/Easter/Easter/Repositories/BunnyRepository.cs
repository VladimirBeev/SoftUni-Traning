using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        public Dictionary<string, IBunny> bynnies;

        public BunnyRepository()
        {
            this.bynnies = new Dictionary<string, IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models => this.bynnies.Values;
        public void Add(IBunny model)
        {
            this.bynnies.Add(model.Name,model);
        }

        public IBunny FindByName(string name)
        {
            var finde = this.bynnies.First(b=>b.Key == name);
            if (finde.Key == null)
            {
                return null;
            }
            return finde.Value;
        }

        public bool Remove(IBunny model)
        {
            return this.bynnies.Remove(model.Name);
        }
    }
}
