using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private IRepository<IAstronaut> astronautRepository;
        private IRepository<IPlanet> planetRepository;
        private IMission mission;
        private int countExplorePlanet = 0;

        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
            this.mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = type switch
            {
                nameof(Biologist) => new Biologist(astronautName),
                nameof(Geodesist) => new Geodesist(astronautName),
                nameof(Meteorologist) => new Meteorologist(astronautName),
                _ => throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidAstronautType)),
            };

            this.astronautRepository.Add(astronaut);
            return String.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            this.planetRepository.Add(planet);
            return String.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            var planet = this.planetRepository.FindByName(planetName);
            var suitableAstronaut = new List<IAstronaut>();
            foreach (var astronaut in this.astronautRepository.Models)
            {
                if (astronaut.Oxygen >= 60)
                {
                    suitableAstronaut.Add(astronaut);
                }
            }
            if (suitableAstronaut.Count <= 0)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidAstronautCount));
            }
            mission.Explore(planet, suitableAstronaut);
            countExplorePlanet++;
            int coutDead = suitableAstronaut.Count(a => a.CanBreath == false);
            return String.Format(OutputMessages.PlanetExplored, planetName, coutDead);
        }

        public string Report()
        {
            Console.WriteLine($"{countExplorePlanet} planets were explored!");
            Console.WriteLine("Astronauts info:");
            var sb = new StringBuilder();
            foreach (var astronaut in this.astronautRepository.Models)
            {

                //sb.AppendLine($"{countExplorePlanet} planets were explored!");
                //sb.AppendLine("Astronauts info:");
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                sb.AppendLine($"Bag items: {(astronaut.Bag.Items.Count == 0 ? "none" : (string.Join(", ", astronaut.Bag.Items)))}");
            }
            return sb.ToString().Trim();
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = this.astronautRepository.FindByName(astronautName);
            if (astronaut == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }
            this.astronautRepository.Remove(astronaut);
            return String.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
