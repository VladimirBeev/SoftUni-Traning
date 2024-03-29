﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        private const int ClaymoreDamage = 20;
        public Claymore(string name, int durability) 
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            if (this.Durability <= 0)
            {
                return this.Durability = 0;
            }
            this.Durability--;
            return ClaymoreDamage;
        }
    }
}
