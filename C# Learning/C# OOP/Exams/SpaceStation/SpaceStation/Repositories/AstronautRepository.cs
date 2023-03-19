using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private Dictionary<string, IAstronaut> astronautRepository;

        public AstronautRepository()
        {
            this.astronautRepository = new Dictionary<string, IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => this.astronautRepository.Values;

        public void Add(IAstronaut model)
        {
            this.astronautRepository.Add(model.Name,model);
        }

        public IAstronaut FindByName(string name)
        {
            if (this.astronautRepository.ContainsKey(name))
            {
                return this.astronautRepository[name];
            }
            return null;
        }

        public bool Remove(IAstronaut model)
        {
            return this.astronautRepository.Remove(model.Name);
        }
    }
}
