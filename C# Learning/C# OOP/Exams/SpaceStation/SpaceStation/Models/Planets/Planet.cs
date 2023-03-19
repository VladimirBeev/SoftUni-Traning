﻿using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private List<string> planetItems;

        public Planet(string name)
        {
            this.Name = name;
            this.planetItems = new List<string>();
        }

        public ICollection<string> Items => this.planetItems;

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(String.Format(ExceptionMessages.InvalidPlanetName));
                }
                this.name = value;
            }
        }
    }
}
