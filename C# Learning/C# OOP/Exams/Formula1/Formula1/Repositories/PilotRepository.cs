using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private Dictionary<string, IPilot> pilotRepository;

        public PilotRepository()
        {
            this.pilotRepository = new Dictionary<string, IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => this.pilotRepository.Values;

        public void Add(IPilot model)
        {
            this.pilotRepository.Add(model.FullName, model);
        }

        public IPilot FindByName(string name)
        {
            if (this.pilotRepository.ContainsKey(name))
            {
                return this.pilotRepository[name];
            }
            return null;
        }

        public bool Remove(IPilot model)
        {
            if (this.pilotRepository.ContainsKey(model.FullName))
            {
                this.pilotRepository.Remove(model.FullName);
                return true;
            }
            return false;
        }
    }
}
