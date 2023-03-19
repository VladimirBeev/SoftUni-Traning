using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using Formula1.Utilities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private IRepository<IPilot> pilotRepository;
        private IRepository<IRace> raceRepository;
        private IRepository<IFormulaOneCar> formulaOneRepository;

        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.formulaOneRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilotFind = this.pilotRepository.FindByName(pilotName);
            var carFind = this.formulaOneRepository.FindByName(carModel);
            if (pilotFind == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage,pilotName));
            }
            if (pilotFind.CanRace)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            if (carFind == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }
            pilotFind.AddCar(carFind);
            this.formulaOneRepository.Remove(carFind);
            return String.Format(OutputMessages.SuccessfullyPilotToCar,pilotName,carFind.GetType().Name,carFind.Model);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var raceFind = this.raceRepository.FindByName(raceName);
            var pilotFind = this.pilotRepository.FindByName(pilotFullName);
            if (raceFind == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage,raceName));
            }
            if (pilotFind == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            if (!pilotFind.CanRace)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            if (raceFind.Pilots.Contains(pilotFind))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            raceFind.AddPilot(pilotFind);
            return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            var car = this.formulaOneRepository.FindByName(model);
            if (car != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage,model));
            }
            //if (type == "Ferrari")
            //{
            //    var carModel = new Ferrari(model,horsepower,engineDisplacement);
            //    this.formulaOneRepository.Add(carModel);
            //}
            //else if (type == "Williams")
            //{
            //    var carModel = new Williams(model,horsepower,engineDisplacement);
            //    this.formulaOneRepository.Add(carModel);
            //}
            //else if (type != "Ferrari")
            //{
            //    throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type));
            //}
            //else if (type != "Williams")
            //{
            //    throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type));
            //}
            IFormulaOneCar carss = type switch
            {
                nameof(Ferrari) => new Ferrari(model, horsepower, engineDisplacement),
                nameof(Williams) => new Williams(model, horsepower, engineDisplacement),
                _ => throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type)),
            };
            this.formulaOneRepository.Add(carss);
            return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            var pilotfind = this.pilotRepository.FindByName(fullName);
            if (pilotfind != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage,fullName));
            }
            var pilot = new Pilot(fullName);
            this.pilotRepository.Add(pilot);
            return String.Format(OutputMessages.SuccessfullyCreatePilot,fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            var raceFind = this.raceRepository.FindByName(raceName);
            if (raceFind != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage,raceName));
            }
            var race = new Race(raceName,numberOfLaps);
            this.raceRepository.Add(race);
            return String.Format(OutputMessages.SuccessfullyCreateRace,raceName);
        }

        public string PilotReport()
        {
            var orderedPilots = this.pilotRepository.Models.OrderByDescending(p=>p.NumberOfWins);
            var sb = new StringBuilder();
            foreach (var item in orderedPilots)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }

        public string RaceReport()
        {
            var sb = new StringBuilder();
            foreach (var race in this.raceRepository.Models)
            {
                if (race.TookPlace == true)
                {
                    sb.Append(race.RaceInfo());
                }
                
            }
            return sb.ToString();
        }

        public string StartRace(string raceName)
        {
            var raceFind = this.raceRepository.FindByName(raceName);
            var pilots = raceFind.Pilots;
            if (raceFind == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage,raceName));
            }
            if (raceFind.Pilots.Count <= 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants,raceName));
            }
            if (raceFind.TookPlace)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            
            List<IPilot> orderedPilots = pilots.OrderByDescending(p=>p.Car.RaceScoreCalculator(raceFind.NumberOfLaps)).ToList();
            raceFind.TookPlace = true;
            orderedPilots.First().WinRace();
            var firstPlase = orderedPilots[0];
            var secondPlase = orderedPilots[1];
            var thirdPlace = orderedPilots[2];


            var sb = new StringBuilder();
            sb.AppendLine(String.Format(OutputMessages.PilotFirstPlace, firstPlase.FullName,raceName));
            sb.AppendLine(String.Format(OutputMessages.PilotSecondPlace, secondPlase.FullName, raceName));
            sb.Append(String.Format(OutputMessages.PilotThirdPlace, thirdPlace.FullName, raceName));
            return sb.ToString();
        }
    }
}
