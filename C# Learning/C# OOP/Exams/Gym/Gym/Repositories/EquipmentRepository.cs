using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private Dictionary<string,IEquipment> equipmentRepository;

        public EquipmentRepository()
        {
            this.equipmentRepository = new Dictionary<string, IEquipment>();
        }



        public IReadOnlyCollection<IEquipment> Models => this.equipmentRepository.Values;

        public void Add(IEquipment model)
        {
            this.equipmentRepository.Add(model.GetType().Name,model);
        }

        public IEquipment FindByType(string type)
        {
            var findeq = this.equipmentRepository[type];
            if (findeq == null)
            {
                return null;
            }
            return findeq;
        }

        public bool Remove(IEquipment model)
        {
            return this.equipmentRepository.Remove(model.GetType().Name);
        }
    }
}
