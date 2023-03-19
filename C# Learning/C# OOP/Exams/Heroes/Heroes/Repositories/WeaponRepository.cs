using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private Dictionary<string,IWeapon> weaponRepository;
        public WeaponRepository()
        {
            this.weaponRepository = new Dictionary<string, IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => this.weaponRepository.Values;

        public void Add(IWeapon model)
        {
            this.weaponRepository.Add(model.Name,model);
        }

        public IWeapon FindByName(string name)
        {
            if (this.weaponRepository.ContainsKey(name))
            {
                var find = this.weaponRepository[name];
                return find;
            }

            return null;
        }

        public bool Remove(IWeapon model)
        {
            if (this.weaponRepository.ContainsKey(model.Name))
            {
                this.weaponRepository.Remove(model.Name);
                return true;
            }
            return false;
        }
    }
}
