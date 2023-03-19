using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Models.Vessel;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private IRepository<IVessel> vesselReposiroty;
        private Dictionary<string, ICaptain> captainRepository;

        public Controller()
        {
            this.vesselReposiroty = new VesselRepository();
            this.captainRepository = new Dictionary<string, ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            if (this.captainRepository.ContainsKey(fullName))
            {
                return String.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }
            var captain = new Captain(fullName);
            this.captainRepository.Add(captain.FullName, captain);
            return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }
        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            var vessel = this.vesselReposiroty.FindByName(name);
            if (vessel != null)
            {
                return String.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }
            if (vesselType == "Battleship")
            {
                var ve = new Battleship(name, mainWeaponCaliber, speed);
                this.vesselReposiroty.Add(ve);
            }
            else if (vesselType == "Submarine")
            {
                var ve = new Submarine(name, mainWeaponCaliber, speed);
                this.vesselReposiroty.Add(ve);
            }
            else
            {
                return OutputMessages.InvalidVesselType;
            }
            return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);

        }
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            var captain = this.captainRepository[selectedCaptainName];
            var vessel = this.vesselReposiroty.FindByName(selectedVesselName);
            if (captain == null)
            {
                return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            if (vessel.Captain != null)
            {
                return String.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }
            vessel.Captain = captain;
            captain.AddVessel(vessel);
            captain.Vessels.Add(vessel);
            return String.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string CaptainReport(string captainFullName)
        {
            var captian = this.captainRepository[captainFullName];
            return captian.Report();
        }
        public string VesselReport(string vesselName)
        {
            var vessel = this.vesselReposiroty.FindByName(vesselName);
            return vessel.ToString();
        }
        public string ToggleSpecialMode(string vesselName)
        {
            var vessel = this.vesselReposiroty.FindByName(vesselName);
            if (vessel != null)
            {
                if (vessel is Battleship ves)
                {
                    ves.ToggleSonarMode();
                    return String.Format(OutputMessages.ToggleBattleshipSonarMode, ves.Name);
                }
                if (vessel is Submarine su)
                {
                    
                    su.ToggleSubmergeMode();
                    return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, su.Name);
                }
            }
            return String.Format(OutputMessages.VesselNotFound, vesselName);
        }
        public string ServiceVessel(string vesselName)
        {
            var vessel = this.vesselReposiroty.FindByName(vesselName);
            if (vessel != null)
            {
                vessel.RepairVessel();
                return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
            }
            return String.Format(OutputMessages.VesselNotFound, vesselName);
        }
        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attackVessel = this.vesselReposiroty.FindByName(attackingVesselName);
            var defendVessel = this.vesselReposiroty.FindByName(defendingVesselName);
            if (attackVessel == null)
            {
                String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            if (defendVessel == null)
            {
                String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            if (attackVessel.ArmorThickness == 0)
            {
                String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            if (defendVessel.ArmorThickness == 0)
            {
                String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }

            attackVessel.Attack(defendVessel);
            attackVessel.Captain.IncreaseCombatExperience();
            defendVessel.Captain.IncreaseCombatExperience();
            return String.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defendVessel.ArmorThickness);
        }
    }
}
