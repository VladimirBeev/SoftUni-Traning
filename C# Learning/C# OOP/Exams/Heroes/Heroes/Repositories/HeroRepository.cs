using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private Dictionary<string, IHero> heroesRepository;

        public HeroRepository()
        {
            this.heroesRepository = new Dictionary<string,IHero>();
        }
        public IReadOnlyCollection<IHero> Models => this.heroesRepository.Values;

        public void Add(IHero model)
        {
            this.heroesRepository.Add(model.Name,model);
        }

        public IHero FindByName(string name)
        {
            if (this.heroesRepository.ContainsKey(name))
            {
                var find = this.heroesRepository[name];
                return find;
            }
            
            return null;
        }

        public bool Remove(IHero model)
        {
            if (this.heroesRepository.ContainsKey(model.Name))
            {
                this.heroesRepository.Remove(model.Name);
                return true;
            }
            return false;
        }
    }
}
