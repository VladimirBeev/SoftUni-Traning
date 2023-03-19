using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private List<IEquipment> equipments;
        private Dictionary<string,IGym> gyms;

        public Controller()
        {
            this.equipments = new List<IEquipment>();
            this.gyms = new Dictionary<string, IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete = athleteType switch
            {
                nameof(Boxer) => new Boxer(athleteName, motivation, numberOfMedals),
                nameof(Weightlifter) => new Weightlifter(athleteName, motivation, numberOfMedals),
                _ => throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidAthleteType)),
            };
            var gym = this.gyms[gymName];
            if (gym.GetType().Name == "BoxingGym")
            {
                if (athlete.GetType().Name == "Boxer")
                {
                    gym.Athletes.Add(athlete);
                }
                else
                {
                    return String.Format(OutputMessages.InappropriateGym);
                }
            }
            else if (gym.GetType().Name == "WeightliftingGym")
            {
                if (athlete.GetType().Name == "Weightlifter")
                {
                    gym.Athletes.Add(athlete);
                }
                else
                {
                    return String.Format(OutputMessages.InappropriateGym);
                }
            }
            return String.Format(OutputMessages.EntityAddedToGym,athleteType,gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment = equipmentType switch
            {
                nameof(BoxingGloves) => new BoxingGloves(),
                nameof(Kettlebell) => new Kettlebell(),
                _ => throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidEquipmentType)),
            };
            this.equipments.Add(equipment);
            return String.Format(OutputMessages.SuccessfullyAdded,equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym = gymType switch
            {
                nameof(BoxingGym) => new BoxingGym(gymName),
                nameof(WeightliftingGym) => new WeightliftingGym(gymName),
                _ => throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidGymType))
            };
            this.gyms.Add(gym.Name,gym);
            return String.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            var gym = this.gyms[gymName];
            var values = 0.0;
            foreach (var item in gym.Equipment)
            {
                values += item.Weight;
            }
            return String.Format(OutputMessages.EquipmentTotalWeight,gymName,values);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            
            var equipment = this.equipments.Find(e=>e.GetType().Name == equipmentType);
            if (equipment == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
            var gym = this.gyms[gymName];
            gym.AddEquipment(equipment);
            this.equipments.Remove(equipment);
            return String.Format(OutputMessages.EntityAddedToGym,equipmentType,gymName);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach(var item in this.gyms)
            {
                sb.AppendLine($"{item.Value.GymInfo()}");
            }
            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            var gym = this.gyms[gymName];
            gym.Exercise();
            return String.Format(OutputMessages.AthleteExercise,gym.Athletes.Count);
        }
    }
}
