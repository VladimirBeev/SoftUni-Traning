using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [Test]
        public void AthleteConstruktor()
        {
            var athleteName = "Vladimir";
            var athlet = new Athlete(athleteName);
            Assert.That(athleteName,Is.EqualTo(athlet.FullName));
        }
        [Test]
        public void AthleteConstruktor1()
        {
            var athleteName = "Vladimir";
            var athlet = new Athlete(athleteName);
            athlet.IsInjured = true;
            Assert.That(true, Is.EqualTo(athlet.IsInjured));
        }
        [Test]
        public void GymConstruktor()
        {
            var athleteNameOne = "Vladimir";
            var athleteNameTwo = "Vangel";
            var athleteOne = new Athlete(athleteNameOne);
            var athleteTwo = new Athlete(athleteNameTwo);
            var gymName = "Sports";
            var gymSize = 2;
            var gym = new Gym(gymName, gymSize);
            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);

            Assert.That(gymName, Is.EqualTo(gym.Name));
        }
        [Test]
        public void GymConstruktor1()
        {
            var athleteNameOne = "Vladimir";
            var athleteNameTwo = "Vangel";
            var athleteOne = new Athlete(athleteNameOne);
            var athleteTwo = new Athlete(athleteNameTwo);
            var gymName = "Sports";
            var gymSize = 2;
            var gym = new Gym(gymName, gymSize);
            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);

            Assert.That(gymSize, Is.EqualTo(gym.Capacity));
        }
        [Test]
        public void GymConstruktor2()
        {
            var athleteNameOne = "Vladimir";
            var athleteNameTwo = "Vangel";
            var athleteOne = new Athlete(athleteNameOne);
            var athleteTwo = new Athlete(athleteNameTwo);
            var gymName = "Sports";
            var gymSize = 2;
            var gym = new Gym(gymName, gymSize);
            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);

            Assert.That(gym.Count, Is.EqualTo(2));
        }
        [Test]
        public void GymNameExeption()
        {
            var athleteNameOne = "Vladimir";
            var athleteNameTwo = "Vangel";
            var athleteOne = new Athlete(athleteNameOne);
            var athleteTwo = new Athlete(athleteNameTwo);
            var gymName = "Sports";
            string falesGymName = null;

            var gymSize = 2;
            var gym = new Gym(gymName, gymSize);
            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);
            Assert.Throws<ArgumentNullException>(() =>
            {
                var newGym = new Gym(falesGymName, gymSize);
            }, "Invalid gym name.");
        }
        [Test]
        public void GymNameExeption1()
        {
            var athleteNameOne = "Vladimir";
            var athleteNameTwo = "Vangel";
            var athleteOne = new Athlete(athleteNameOne);
            var athleteTwo = new Athlete(athleteNameTwo);
            var gymName = "Sports";
            string falesGymName = String.Empty;

            var gymSize = 2;
            var gym = new Gym(gymName, gymSize);
            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);
            Assert.Throws<ArgumentNullException>(() =>
            {
                var newGym = new Gym(falesGymName, gymSize);
            }, "Invalid gym name.");
        }
        [Test]
        public void GymCapacityExeption()
        {
            var athleteNameOne = "Vladimir";
            var athleteNameTwo = "Vangel";
            var athleteOne = new Athlete(athleteNameOne);
            var athleteTwo = new Athlete(athleteNameTwo);
            var gymName = "Sports";
            string falesGymName = "Test";
            int sizeFalse = -1;
            var gymSize = 2;
            var gym = new Gym(gymName, gymSize);
            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);
            Assert.Throws<ArgumentException>(() =>
            {
                var newGym = new Gym(falesGymName, sizeFalse);
            }, "Invalid gym capacity.");
        }
        [Test]
        public void GymCapacityExeption1()
        {
            var athleteNameOne = "Vladimir";
            var athleteNameTwo = "Vangel";
            var athleteOne = new Athlete(athleteNameOne);
            var athleteTwo = new Athlete(athleteNameTwo);
            var gymName = "Sports";
            string falesGymName = "Test";
            int sizeFalse = -5;
            var gymSize = 2;
            var gym = new Gym(gymName, gymSize);
            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);
            Assert.Throws<ArgumentException>(() =>
            {
                var newGym = new Gym(falesGymName, sizeFalse);
            }, "Invalid gym capacity.");
        }
        [Test]
        public void GymCapacityWork()
        {
            var athleteNameOne = "Vladimir";
            var athleteNameTwo = "Vangel";
            var athleteOne = new Athlete(athleteNameOne);
            var athleteTwo = new Athlete(athleteNameTwo);
            var gymName = "Sports";
            string falesGymName = "Test";
            int sizeFalse = 0;
            var gymSize = 2;
            var gym = new Gym(gymName, gymSize);
            var gymFalse = new Gym(falesGymName,sizeFalse);
            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);
            Assert.That(sizeFalse,Is.EqualTo(gymFalse.Capacity));
        }
        [Test]
        public void AddAthleteExeption()
        {
            var falseAthlete = new Athlete("False");
            var athleteNameOne = "Vladimir";
            var athleteNameTwo = "Vangel";
            var athleteOne = new Athlete(athleteNameOne);
            var athleteTwo = new Athlete(athleteNameTwo);
            var gymName = "Sports";
            var gymSize = 2;
            var gym = new Gym(gymName, gymSize);
            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(falseAthlete);
            }, "The gym is full.");
        }
        [Test]
        public void RemoveAthleteExeption()
        {
            var falseAthleteName = "Hhaha";
            var athleteNameOne = "Vladimir";
            var athleteNameTwo = "Vangel";
            var athleteOne = new Athlete(athleteNameOne);
            var athleteTwo = new Athlete(athleteNameTwo);
            var gymName = "Sports";
            var gymSize = 2;
            var gym = new Gym(gymName, gymSize);
            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete(falseAthleteName);
            }, $"The athlete {falseAthleteName} doesn't exist.");
        }
        [Test]
        public void RemoveAthleteExeption1()
        {
            string falseAthleteName = null;
            var athleteNameOne = "Vladimir";
            var athleteNameTwo = "Vangel";
            var athleteOne = new Athlete(athleteNameOne);
            var athleteTwo = new Athlete(athleteNameTwo);
            var gymName = "Sports";
            var gymSize = 2;
            var gym = new Gym(gymName, gymSize);
            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete(falseAthleteName);
            }, $"The athlete {falseAthleteName} doesn't exist.");
        }
        [Test]
        public void RemoveAthleteWork()
        {
            string athleteToRemove = "Vladimir";
            var athleteNameOne = "Vladimir";
            var athleteNameTwo = "Vangel";
            var athleteOne = new Athlete(athleteNameOne);
            var athleteTwo = new Athlete(athleteNameTwo);
            var gymName = "Sports";
            var gymSize = 2;
            var gym = new Gym(gymName, gymSize);
            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);
            gym.RemoveAthlete(athleteToRemove);
            Assert.That(gym.Count,Is.EqualTo(1));
            
        }
        [Test]
        public void InjureAthleteExeption()
        {
            
            var athleteNameOne = "Vladimir";
            var name = "Test";
            //var athleteOne = new Athlete(athleteNameOne);

            var gymName = "Sports";
            var gymSize = 2;
            var gym = new Gym(gymName, gymSize);
            //gym.AddAthlete(athleteOne);


            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete(name);
            }, $"The athlete {name} doesn't exist.");

        }
        [Test]
        public void InjureAthleteWork()
        {

            var athleteNameOne = "Vladimir";
            var athleteOne = new Athlete(athleteNameOne);

            var gymName = "Sports";
            var gymSize = 2;
            var gym = new Gym(gymName, gymSize);
            gym.AddAthlete(athleteOne);
            var athletInjure = gym.InjureAthlete(athleteNameOne);
            Assert.That(athleteOne,Is.EqualTo(athletInjure));
        }
        [Test]
        public void ReportteWork()
        {

            var athleteNameOne = "Vladimir";
            var athleteOne = new Athlete(athleteNameOne);
            List<Athlete> ListAthlets = new List<Athlete>();
            ListAthlets.Add(athleteOne);
            var gymName = "Sports";
            var gymSize = 2;
            var gym = new Gym(gymName, gymSize);
            gym.AddAthlete(athleteOne);
            var athletInjure = gym.InjureAthlete(athleteNameOne);
            string athleteNames = string.Join(", ", ListAthlets.Where(x => !x.IsInjured).Select(f => f.FullName));
            string report = $"Active athletes at {gymName}: {athleteNames}";
            string reporttt = gym.Report();
            Assert.That(report, Is.EqualTo(reporttt));
        }
    }
}
