using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private Dictionary<string, IRacer> racers;

        public RacerRepository()
        {
            this.racers = new Dictionary<string, IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => this.racers.Values;

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidAddRacerRepository));
            }
            this.racers.Add(model.Username, model);
        }

        public IRacer FindBy(string property)
        {
            
            if (!this.racers.ContainsKey(property))
            {
                return null;
            }
            var racer = this.racers[property];
            return racer;
        }

        public bool Remove(IRacer model)
        {
            return this.racers.Remove(model.Username);
        }
    }
    
}
