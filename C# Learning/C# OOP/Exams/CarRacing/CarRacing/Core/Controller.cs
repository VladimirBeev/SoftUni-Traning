﻿using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private IRepository<ICar> carsRepository;
        private IRepository<IRacer> racersRepository;
        private IMap map;

        public Controller()
        {
            this.carsRepository = new CarRepository();
            this.racersRepository = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = type switch
            {
                nameof(SuperCar) => new SuperCar(make, model, VIN, horsePower),
                nameof(TunedCar) => new TunedCar(make, model, VIN, horsePower),
                _ => throw new ArgumentException(String.Format(ExceptionMessages.InvalidCarType)),
            };
            this.carsRepository.Add(car);
            return String.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            var car = this.carsRepository.FindBy(carVIN);
            if (car == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CarCannotBeFound));
            }
            IRacer racer = type switch
            {
                nameof(ProfessionalRacer) => new ProfessionalRacer(username, car),
                nameof(StreetRacer) => new StreetRacer(username, car),
                _ => throw new ArgumentException(String.Format(ExceptionMessages.InvalidRacerType)),
            };
            this.racersRepository.Add(racer);
            return String.Format(OutputMessages.SuccessfullyAddedRacer,username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            var racerOne = this.racersRepository.FindBy(racerOneUsername);
            var racerTwo = this.racersRepository.FindBy(racerTwoUsername);
            if (racerOne == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RacerCannotBeFound,racerOneUsername));
            }
            if (racerTwo == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }
            return map.StartRace(racerOne,racerTwo);
        }

        public string Report()
        {
            var orderedRacers = this.racersRepository.Models.OrderByDescending(r => r.DrivingExperience)
                .ThenBy(r => r.Username);
            var sb = new StringBuilder();
            foreach (var racer in orderedRacers)
            {
                sb.Append(racer.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
