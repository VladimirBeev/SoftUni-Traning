using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private Dictionary<string, ICar> cars;

        public CarRepository()
        {
            this.cars = new Dictionary<string, ICar>();
        }

        public IReadOnlyCollection<ICar> Models => this.cars.Values;

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidAddCarRepository));
            }
            this.cars.Add(model.VIN,model);
        }

        public ICar FindBy(string property)
        {
            
            if (!this.cars.ContainsKey(property))
            {
                return null;
            }
            var car = this.cars[property];
            return car;
        }

        public bool Remove(ICar model)
        {
            return this.cars.Remove(model.VIN);
        }
    }
}
