using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private IRepository<IDecoration> decoractionRepository;
        private Dictionary<string, IAquarium> aquariumRepository;

        public Controller()
        {
            decoractionRepository = new DecorationRepository();
            aquariumRepository = new Dictionary<string, IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = aquariumType switch
            {
                nameof(FreshwaterAquarium) => new FreshwaterAquarium(aquariumName),
                nameof(SaltwaterAquarium) => new SaltwaterAquarium(aquariumName),
                _ => throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidAquariumType)),
            };
            aquariumRepository.Add(aquarium.Name, aquarium);
            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = decorationType switch
            {
                nameof(Ornament) => new Ornament(),
                nameof(Plant) => new Plant(),
                _ => throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidDecorationType)),
            };
            decoractionRepository.Add(decoration);
            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = fishType switch
            {
                nameof(FreshwaterFish) => new FreshwaterFish(fishName, fishSpecies, price),
                nameof(SaltwaterFish) => new SaltwaterFish(fishName, fishSpecies, price),
                _ => throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidFishType)),
            };
            var aquarium = aquariumRepository.Values.First(a => a.Name == aquariumName);
            if (aquarium.GetType().Name == "FreshwaterAquarium")
            {
                if (fish.GetType().Name == "FreshwaterFish")
                {
                    aquarium.AddFish(fish);
                }
                else
                {
                    return String.Format(OutputMessages.UnsuitableWater);
                }
            }
            if (aquarium.GetType().Name == "SaltwaterAquarium")
            {
                if (fish.GetType().Name == "SaltwaterFish")
                {
                    aquarium.AddFish(fish);
                }
                else
                {
                    return String.Format(OutputMessages.UnsuitableWater);
                }
            }
            return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = aquariumRepository.Values.First(a => a.Name == aquariumName);
            decimal value = 0;
            foreach (var item in aquarium.Fish)
            {
                value += item.Price;
            }
            foreach (var item in aquarium.Decorations)
            {
                value += item.Price;
            }

            return String.Format(OutputMessages.AquariumValue, aquariumName, value);
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariumRepository.Values.First(a => a.Name == aquariumName);
            aquarium.Feed();
            return String.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var aquarium = aquariumRepository.Values.First(a => a.Name == aquariumName);
            IDecoration decoration = decoractionRepository.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            aquarium.AddDecoration(decoration);
            decoractionRepository.Remove(decoration);
            return String.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var item in aquariumRepository)
            {
                sb.Append(item.Value.GetInfo());
            }
            return sb.ToString().Trim();
        }
    }
}
