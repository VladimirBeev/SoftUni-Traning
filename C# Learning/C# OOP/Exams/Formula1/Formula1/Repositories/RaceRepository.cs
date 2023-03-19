using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly Dictionary<string, IRace> raceRepository;

        public RaceRepository()
        {
            this.raceRepository = new Dictionary<string, IRace>();
        }

        public IReadOnlyCollection<IRace> Models => this.raceRepository.Values;

        public void Add(IRace model)
        {
            this.raceRepository.Add(model.RaceName,model);
        }

        public IRace FindByName(string name)
        {
            if (this.raceRepository.ContainsKey(name))
            {
                return this.raceRepository[name];
            }
            return null;
        }

        public bool Remove(IRace model)
        {
            if (this.raceRepository.ContainsKey(model.RaceName))
            {
                this.raceRepository.Remove(model.RaceName);
                return true;
            }
            return false;
        }
    }
}
