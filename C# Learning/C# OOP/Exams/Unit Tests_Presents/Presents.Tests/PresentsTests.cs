namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Concurrent;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void CreatePresentShoudThrowException()
        {
            string namePresentOne = "Test";
            var magicPresentOne = 12.3;
            var namePresentTwo = "Test1";
            var magicPresentTwo = 15.5;
            var present = new Present(namePresentOne,magicPresentOne);
            var bag = new Bag();
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            }, "This present already exists!");
        }
        [Test]
        public void CreatePresentShoudThrowwork()
        {
            string namePresentOne = "Test";
            var magicPresentOne = 12.3;
            var namePresentTwo = "Test1";
            var magicPresentTwo = 15.5;
            var present = new Present(namePresentOne, magicPresentOne);
            var bag = new Bag();
            bag.Create(present);
            Present present2 = new Present(namePresentTwo,magicPresentTwo);
            var rezult = $"Successfully added present {present2.Name}.";
            Assert.That(rezult,Is.EqualTo(bag.Create(present2)));
        }
        [Test]
        public void RemovePresentShoudThrowwork()
        {
            string namePresentOne = "Test";
            var magicPresentOne = 12.3;
            var namePresentTwo = "Test1";
            var magicPresentTwo = 15.5;
            var present = new Present(namePresentOne, magicPresentOne);
            var bag = new Bag();
            bag.Create(present);
            Present present2 = new Present(namePresentTwo, magicPresentTwo);
            bag.Create(present2);
            Assert.That(true, Is.EqualTo(bag.Remove(present2)));
        }
        [Test]
        public void RemovePresentShoudThrowwork1()
        {
            string namePresentOne = "Test";
            var magicPresentOne = 12.3;
            var namePresentTwo = "Test1";
            var magicPresentTwo = 15.5;
            var present = new Present(namePresentOne, magicPresentOne);
            var bag = new Bag();
            bag.Create(present);
            Present present2 = new Present(namePresentTwo, magicPresentTwo);
            bag.Create(present2);
            bag.Remove(present);
            Assert.That(false, Is.EqualTo(bag.Remove(present)));
        }
        [Test]
        public void GetPresentWithLeastMagic()
        {
            string namePresentOne = "Test";
            var magicPresentOne = 12.3;
            var namePresentTwo = "Test1";
            var magicPresentTwo = 15.5;
            var present = new Present(namePresentOne, magicPresentOne);
            var bag = new Bag();
            bag.Create(present);
            Present present2 = new Present(namePresentTwo, magicPresentTwo);
            bag.Create(present2);
            bag.Remove(present);
            var pres = bag.GetPresentWithLeastMagic();
            Assert.That(present2, Is.EqualTo(pres));
        }
        [Test]
        public void GetPresent()
        {
            string namePresentOne = "Test";
            var magicPresentOne = 12.3;
            var namePresentTwo = "Test1";
            var magicPresentTwo = 15.5;
            var present = new Present(namePresentOne, magicPresentOne);
            var bag = new Bag();
            bag.Create(present);
            Present present2 = new Present(namePresentTwo, magicPresentTwo);
            bag.Create(present2);
            Assert.That(present, Is.EqualTo(bag.GetPresent("Test")));
        }
        [Test]
        public void IReadOnlyCollectionGetPresents()
        {
            string namePresentOne = "Test";
            var magicPresentOne = 12.3;
            var namePresentTwo = "Test1";
            var magicPresentTwo = 15.5;
            var present = new Present(namePresentOne, magicPresentOne);
            var bag = new Bag();
            bag.Create(present);
            Present present2 = new Present(namePresentTwo, magicPresentTwo);
            bag.Create(present2);
            var rezult = bag.GetPresents();
            Assert.That(rezult, Is.EqualTo(bag.GetPresents()));
        }
    }
}
