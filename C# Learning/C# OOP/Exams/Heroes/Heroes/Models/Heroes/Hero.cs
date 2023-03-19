using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Health
        {
            get => this.health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                this.health = value;
            }
        }

        public int Armour
        {
            get => this.armour;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                this.armour = value;
            }
        }

        public IWeapon Weapon
        {
            get => this.weapon;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }
                this.weapon = value;
            }
        }

        public bool IsAlive => this.Health > 0;
        public void AddWeapon(IWeapon weapon) => this.Weapon = weapon;

        public void TakeDamage(int points)
        {
            var arm = this.Armour - points;
            if (arm < 0)
            {
                this.Armour = 0;
                var hel = this.Health + arm;
                if (hel <= 0)
                {
                    this.Health = 0;
                }
                else
                {
                    this.Health = hel;
                }
            }
            else
            {
                this.Armour -= points;
            }
        }
        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"{this.GetType().Name}: {this.Name}");
            result.AppendLine($"--Health: {this.Health}");
            result.AppendLine($"--Armour: {this.Armour}");
            result.Append($"--Weapon: {(this.Weapon == null ? "Unarmed" : this.Weapon.Name)}");

            return result.ToString();
        }
    }
}
