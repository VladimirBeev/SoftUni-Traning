using NUnit.Framework;
using System;
using System.Linq;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void CapacityPrppertyShoudThrowExeptionIfLowerOfZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var shoud = new Shop(-1);
            }, "Invalid capacity.");
        }
        [Test]
        public void CapacityPropertyShoudWorkCorectly()
        {
            var capacity = 2;
            var test = new Shop(2);

            Assert.That(test.Capacity, Is.EqualTo(capacity));
        }
        [Test]
        public void AddSmartphoneShoudThrowExeptionNoPhone()
        {
            var testphonenamemodel = "Test";
            var testphonebattery = 10;
            var testshop = new Shop(2);
            var testphoneone = new Smartphone("Test", 10);
            var testphonetwo = new Smartphone(testphonenamemodel, testphonebattery);
            testshop.Add(testphoneone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                testshop.Add(testphonetwo);
            }, $"The phone model {testphonenamemodel} already exist.");
        }
        [Test]
        public void AddSmartphoneShoudThrowExeptionNoCapacity()
        {
            var testshop = new Shop(2);
            var testphoneone = new Smartphone("Test1", 20);
            var testphonetwo = new Smartphone("Test2", 10);
            var testphonethree = new Smartphone("Test3", 10);
            testshop.Add(testphoneone);
            testshop.Add(testphonetwo);

            Assert.Throws<InvalidOperationException>(() =>
            {
                testshop.Add(testphonethree);
            }, "The shop is full.");
        }
        [Test]
        public void AddSmartphoneShoudWorkCorrectly()
        {
            var testshop = new Shop(2);
            var testphoneone = new Smartphone("Test1", 20);
            var testphonetwo = new Smartphone("Test2", 10);
            var testphonethree = new Smartphone("Test3", 10);
            testshop.Add(testphoneone);
            testshop.Add(testphonetwo);

            Assert.That(testshop.Count, Is.EqualTo(2));
        }
        [Test]
        public void RemoveMethodShoudThrowExeptionNoExistPhone()
        {
            var testremovemodel = "Nokia";
            var testshop = new Shop(2);
            var testphoneone = new Smartphone("Test1", 20);
            var testphonetwo = new Smartphone("Test2", 10);
            testshop.Add(testphoneone);
            testshop.Add(testphonetwo);
            Assert.Throws<InvalidOperationException>(() =>
            {
                testshop.Remove(testremovemodel);
            }, $"The phone model {testremovemodel} doesn't exist.");
        }
        [Test]
        public void RemoveMethodShoudWorkCorrectly()
        {
            var testremovemodel = "Test1";
            var testshop = new Shop(2);
            var testphoneone = new Smartphone("Test1", 20);
            var testphonetwo = new Smartphone("Test2", 10);
            testshop.Add(testphoneone);
            testshop.Add(testphonetwo);
            testshop.Remove(testphoneone.ModelName);
            Assert.That(testshop.Count, Is.EqualTo(1));
        }
        [Test]
        public void TestPhoneMethodShoudThrowExeptionNoExistPhone()
        {
            var testremovemodel = "Nokia";
            var testshop = new Shop(2);
            var testphoneone = new Smartphone("Test1", 20);
            var testphonetwo = new Smartphone("Test2", 10);
            testshop.Add(testphoneone);
            testshop.Add(testphonetwo);
            Assert.Throws<InvalidOperationException>(() =>
            {
                testshop.TestPhone(testremovemodel,10);
            }, $"The phone model {testremovemodel} doesn't exist.");
        }
        [Test]
        public void TestPhoneMethodShoudThrowExeptionLowBattery()
        {
            var testshop = new Shop(2);
            var testphoneone = new Smartphone("Test1", 20);
            var testphonetwo = new Smartphone("Test2", 10);
            testshop.Add(testphoneone);
            testshop.Add(testphonetwo);
            Assert.Throws<InvalidOperationException>(() =>
            {
                testshop.TestPhone(testphoneone.ModelName, 21);
            }, $"The phone model {testphoneone.ModelName} is low on batery.");
        }
        [Test]
        public void TestPhoneMethodShoudWork()
        {
            var testshop = new Shop(2);
            var batteryUseg = 10;
            var testphoneone = new Smartphone("Test1", 20);
            var testphonetwo = new Smartphone("Test2", 10);
            testshop.Add(testphoneone);
            testshop.Add(testphonetwo);
            testshop.TestPhone("Test1",batteryUseg);
            Assert.That(10,Is.EqualTo(testphoneone.CurrentBateryCharge));
        }
        [Test]
        public void ChargePhoneMethodShoudThrowExeptionNoExistPhone()
        {
            var testremovemodel = "Nokia";
            var testshop = new Shop(2);
            var testphoneone = new Smartphone("Test1", 20);
            var testphonetwo = new Smartphone("Test2", 10);
            testshop.Add(testphoneone);
            testshop.Add(testphonetwo);
            Assert.Throws<InvalidOperationException>(() =>
            {
                testshop.ChargePhone(testremovemodel);
            }, $"The phone model {testremovemodel} doesn't exist.");
        }
        [Test]
        public void ChargePhoneMethodShoudWorkCorrectly()
        {
            var testshop = new Shop(2);
            var testphoneone = new Smartphone("Test1", 20);
            var testphonetwo = new Smartphone("Test2", 10);
            testshop.Add(testphoneone);
            testshop.Add(testphonetwo);
            testshop.TestPhone("Test1", 20);
            testshop.ChargePhone("Test1");
            Assert.That(testphoneone.CurrentBateryCharge, Is.EqualTo(testphoneone.MaximumBatteryCharge));
        }
    }
}