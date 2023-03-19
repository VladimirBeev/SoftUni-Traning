namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using Robots;
    using System.Linq;
    using System.Xml.Linq;
    using System.Collections.Generic;

    public class RobotsTests
    {
        [Test]
        public void RobotNameShoudWork()
        {
            var robotName = "Test";
            var maxBattery = 100;
            Robot robot = new Robot(robotName,maxBattery);
            Assert.That(robotName,Is.EqualTo(robot.Name));
        }
        [Test]
        public void RobotBatteryShoudWork()
        {
            var robotName = "Test";
            var maxBattery = 100;
            Robot robot = new Robot(robotName, maxBattery);
            Assert.That(maxBattery, Is.EqualTo(robot.Battery));
        }
        [Test]
        public void RobotMaxBatteryShoudWork()
        {
            var robotName = "Test";
            var maxBattery = 100;
            Robot robot = new Robot(robotName, maxBattery);
            Assert.That(maxBattery, Is.EqualTo(robot.MaximumBattery));
        }
        [Test]
        public void RobotManagerConstructorShoudWork()
        {
            Robot robotOne = new Robot("Test", 100);
            Robot robotTwo = new Robot("Test1", 50);
            var robotMangare = new RobotManager(2);
            robotMangare.Add(robotOne);
            Assert.That(robotMangare.Count,Is.EqualTo(1));
        }
        [Test]
        public void RobotManagerCapacytiShoudThrowExeption()
        {
            Robot robotOne = new Robot("Test", 100);
            Robot robotTwo = new Robot("Test1", 50);
            
            Assert.Throws<ArgumentException>(() =>
            {
                var robotMangare = new RobotManager(-1);
            }, "Invalid capacity!");
        }
        [Test]
        public void RobotManagerCapacytiShoudWork()
        {
            Robot robotOne = new Robot("Test", 100);
            Robot robotTwo = new Robot("Test1", 50);
            var robotMangare = new RobotManager(10);
            robotMangare.Add(robotOne);
            robotMangare.Add(robotTwo);
            Assert.That(10, Is.EqualTo(robotMangare.Capacity));
        }
        [Test]
        public void RobotManagerAddShoudThrowExeption()
        {
            Robot robotOne = new Robot("Test", 100);
            Robot robotTwo = new Robot("Test1", 50);
            var robotMangare = new RobotManager(10);
            robotMangare.Add(robotOne);
            robotMangare.Add(robotTwo);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotMangare.Add(robotOne);
            }, $"There is already a robot with name {robotOne.Name}!");
        }
        [Test]
        public void RobotManagerAddShoudThrowExeption1()
        {
            Robot robotOne = new Robot("Test", 100);
            Robot robotTwo = new Robot("Test1", 50);
            var robotMangare = new RobotManager(1);
            robotMangare.Add(robotOne);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotMangare.Add(robotTwo);
            }, "Not enough capacity!");
        }
        [Test]
        public void RobotManagerRemoveShoudThrowExeption1()
        {
            Robot robotOne = new Robot("Test", 100);
            Robot robotTwo = new Robot("Test1", 50);
            var robotMangare = new RobotManager(5);
            robotMangare.Add(robotOne);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotMangare.Remove(robotTwo.Name);
            }, $"Robot with the name {robotTwo.Name} doesn't exist!");
        }
        [Test]
        public void RobotManagerRemoveShoudWork()
        {
            Robot robotOne = new Robot("Test", 100);
            Robot robotTwo = new Robot("Test1", 50);
            var robotMangare = new RobotManager(5);
            robotMangare.Add(robotOne);
            robotMangare.Add(robotTwo);
            robotMangare.Remove(robotOne.Name);
            Assert.That(1,Is.EqualTo(robotMangare.Count));
        }
        [Test]
        public void RobotManagerWorkShoudWork()
        {
            Robot robotOne = new Robot("Test", 100);
            Robot robotTwo = new Robot("Test1", 50);
            var robotMangare = new RobotManager(5);
            robotMangare.Add(robotOne);
            robotMangare.Add(robotTwo);
            robotMangare.Remove(robotOne.Name);
            robotMangare.Work(robotTwo.Name,"Testing",10);
            Assert.That(40, Is.EqualTo(robotTwo.Battery));
        }
        [Test]
        public void RobotManagerWorkShoudThrowException()
        {
            Robot robotOne = new Robot("Test", 100);
            Robot robotTwo = new Robot("Test1", 50);
            //var listRobot = new List<Robot>();
            //listRobot.Add(robotOne);
            var robotMangare = new RobotManager(5);
            robotMangare.Add(robotTwo);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotMangare.Work(robotOne.Name, "Testing", 50);
            }, $"Robot with the name {robotOne.Name} doesn't exist!");
        }
        [Test]
        public void RobotManagerWorkShoudThrowException1()
        {
            Robot robotOne = new Robot("Test", 40);
            Robot robotTwo = new Robot("Test1", 50);
            //var listRobot = new List<Robot>();
            //listRobot.Add(robotOne);
            var robotMangare = new RobotManager(5);
            robotMangare.Add(robotOne);
            robotMangare.Add(robotTwo);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotMangare.Work(robotOne.Name, "Testing", 50);
            }, $"{robotOne.Name} doesn't have enough battery!");
        }
        [Test]
        public void RobotManagerChargeShoudThrowException1()
        {
            Robot robotOne = new Robot("Test", 40);
            Robot robotTwo = new Robot("Test1", 50);
            //var listRobot = new List<Robot>();
            //listRobot.Add(robotOne);
            var robotMangare = new RobotManager(5);
            robotMangare.Add(robotTwo);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotMangare.Charge(robotOne.Name);
            }, $"Robot with the name {robotOne.Name} doesn't exist!");
        }
        [Test]
        public void RobotManagerChargeShoudWork()
        {
            Robot robotOne = new Robot("Test", 100);
            Robot robotTwo = new Robot("Test1", 50);
            //var listRobot = new List<Robot>();
            //listRobot.Add(robotOne);
            var robotMangare = new RobotManager(5);
            robotMangare.Add(robotOne);
            robotMangare.Add(robotTwo);
            robotMangare.Work(robotOne.Name,"Testing",50);
            robotMangare.Charge(robotOne.Name);
            Assert.That(robotOne.Battery, Is.EqualTo(robotOne.MaximumBattery));
        }
    }
}
