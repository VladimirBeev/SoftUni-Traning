﻿using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete 
    {
        private const int InitStamina = 60;
        
        public Boxer(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, InitStamina, numberOfMedals)
        {
        }

        public override void Exercise()
        {
            this.Stamina += 15;
            if (this.Stamina > 100)
            {
                this.Stamina = 100;
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidStamina));
            }
        }
    }
}
