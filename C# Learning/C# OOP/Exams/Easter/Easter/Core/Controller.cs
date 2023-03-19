using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private IRepository<IBunny> bunnyRepository;
        private IRepository<IEgg> eggRepository;
        private IWorkshop workshop;
        private int count;

        public Controller()
        {
            this.bunnyRepository = new BunnyRepository();
            this.eggRepository = new EggRepository();
            this.workshop = new Workshop();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = bunnyType switch
            {
                nameof(HappyBunny) => new HappyBunny(bunnyName),
                nameof(SleepyBunny) => new SleepyBunny(bunnyName),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType)
            };
            this.bunnyRepository.Add(bunny);
            return String.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            var bunny = this.bunnyRepository.FindByName(bunnyName);
            var dye = new Dye(power);
            if (bunny == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentBunny));
            }
            bunny.AddDye(dye);
            return String.Format(OutputMessages.DyeAdded,power,bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            var egg = new Egg(eggName,energyRequired);
            this.eggRepository.Add(egg);
            return String.Format(OutputMessages.EggAdded,eggName);
        }

        public string ColorEgg(string eggName)
        {
            var egg = this.eggRepository.FindByName(eggName);
            var selectedBunny = new List<IBunny>();
            foreach(var bunny in this.bunnyRepository.Models)
            {
                if (bunny.Energy >= 50)
                {
                    selectedBunny.Add(bunny);
                }
            }
            if (selectedBunny.Count<=0)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.BunniesNotReady));
            }
            foreach(var bunny in selectedBunny)
            {
                this.workshop.Color(egg,bunny);
                if (bunny.Energy == 0)
                {
                    this.bunnyRepository.Remove(bunny);
                }
            }
            count++;
            return (egg.IsDone() == true ? $"{(String.Format(OutputMessages.EggIsDone, eggName))}" : $"{(String.Format(OutputMessages.EggIsNotDone, eggName))}");
        }

        public string Report()
        {
            
            Console.WriteLine($"{count} eggs are done!");
            Console.WriteLine("Bunnies info:");
            var sb = new StringBuilder();
            foreach (var bunny in this.bunnyRepository.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                var countDye = bunny.Dyes.Where(d => d.IsFinished() == false).ToList();
                sb.AppendLine($"Dyes: {countDye.Count} not finished");
            }
            return sb.ToString().Trim();
        }
    }
}
