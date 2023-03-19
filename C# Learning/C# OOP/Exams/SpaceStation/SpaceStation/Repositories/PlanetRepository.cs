using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private Dictionary<string, IPlanet> planetRepository;

        public PlanetRepository()
        {
            this.planetRepository = new Dictionary<string, IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => this.planetRepository.Values;

        public void Add(IPlanet model)
        {
            this.planetRepository.Add(model.Name,model);
        }

        public IPlanet FindByName(string name)
        {
            if (this.planetRepository.ContainsKey(name))
            {
                return this.planetRepository[name];
            }
            return null;
        }

        public bool Remove(IPlanet model)
        {
            return this.planetRepository.Remove(model.Name);
        }
    }
}
