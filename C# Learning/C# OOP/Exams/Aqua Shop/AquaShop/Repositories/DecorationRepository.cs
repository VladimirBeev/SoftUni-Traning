using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private Dictionary<string, IDecoration> decorations;

        public DecorationRepository()
        {
            decorations = new Dictionary<string, IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this.decorations.Values;

        public void Add(IDecoration model)
        {
            this.decorations.Add(model.GetType().Name,model);
        }

        public IDecoration FindByType(string type)
        {
            if (this.decorations.ContainsKey(type))
            {
                return this.decorations[type];
            }
            return null;
        }

        public bool Remove(IDecoration model)
        {
            return this.decorations.Remove(model.GetType().Name);
        }
    }
}
