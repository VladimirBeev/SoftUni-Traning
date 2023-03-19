using System;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void CreateHeroShoudThrowExeption()
    {
        var heroOneName = "Name1";
        var herOneLevel = 1;
        var heroTowName = "Name2";
        var heroTowLevel = 1;
        var heroOne = new Hero(heroOneName,herOneLevel);
        var heroTwo = new Hero(heroTowName,heroTowLevel);
        var heroRepository = new HeroRepository();
        heroRepository.Create(heroOne);
        heroRepository.Create(heroTwo);
        Assert.Throws<InvalidOperationException>(() =>
        {
            heroRepository.Create(heroOne);
        }, $"Hero with name {heroOneName} already exists");
    }

    [Test]
    public void CreateHeroShoudEWork()
    {
        var heroOneName = "Name1";
        var herOneLevel = 1;
        var heroTowName = "Name2";
        var heroTowLevel = 1;
        var heroOne = new Hero(heroOneName, herOneLevel);
        var heroTwo = new Hero(heroTowName, heroTowLevel);
        var heroRepository = new HeroRepository();
        heroRepository.Create(heroTwo);
        var result = $"Successfully added hero {heroOneName} with level {herOneLevel}";
        Assert.That(result, Is.EqualTo(heroRepository.Create(heroOne)));
    }
    [Test]
    public void RemoveHeroShoudThrowExeption()
    {
        string falseHeroName = null;
        var heroOneName = "Name1";
        var herOneLevel = 1;
        var heroTowName = "Name2";
        var heroTowLevel = 1;
        var heroOne = new Hero(heroOneName, herOneLevel);
        var heroTwo = new Hero(heroTowName, heroTowLevel);
        var heroRepository = new HeroRepository();
        heroRepository.Create(heroOne);
        heroRepository.Create(heroTwo);
        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Remove(falseHeroName);
        }, "Name cannot be null");
    }
    [Test]
    public void RemoveHeroShoudThrowExeption2()
    {
        string falseHeroName = "";
        var heroOneName = "Name1";
        var herOneLevel = 1;
        var heroTowName = "Name2";
        var heroTowLevel = 1;
        var heroOne = new Hero(heroOneName, herOneLevel);
        var heroTwo = new Hero(heroTowName, heroTowLevel);
        var heroRepository = new HeroRepository();
        heroRepository.Create(heroOne);
        heroRepository.Create(heroTwo);
        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Remove(falseHeroName);
        }, "Name cannot be null");
    }
    [Test]
    public void RemoveHeroShoudWork()
    {
        var heroOneName = "Name1";
        var herOneLevel = 1;
        var heroTowName = "Name2";
        var heroTowLevel = 1;
        var heroOne = new Hero(heroOneName, herOneLevel);
        var heroTwo = new Hero(heroTowName, heroTowLevel);
        var heroRepository = new HeroRepository();
        heroRepository.Create(heroOne);
        heroRepository.Create(heroTwo);
        Assert.That(true,Is.EqualTo(heroRepository.Remove(heroOneName)));
    }
    [Test]
    public void GetHeroWithHighestLevel()
    {
        var heroOneName = "Name1";
        var herOneLevel = 1;
        var heroTowName = "Name2";
        var heroTowLevel = 5;
        var heroOne = new Hero(heroOneName, herOneLevel);
        var heroTwo = new Hero(heroTowName, heroTowLevel);
        var heroRepository = new HeroRepository();
        heroRepository.Create(heroOne);
        heroRepository.Create(heroTwo);
        Hero hero = heroRepository.Heroes.OrderByDescending(h => h.Level).ToArray()[0];
        Assert.That(hero, Is.EqualTo(heroRepository.GetHeroWithHighestLevel()));
    }
    [Test]
    public void GetHer()
    {
        var heroOneName = "Name1";
        var herOneLevel = 1;
        var heroTowName = "Name2";
        var heroTowLevel = 5;
        var heroOne = new Hero(heroOneName, herOneLevel);
        var heroTwo = new Hero(heroTowName, heroTowLevel);
        var heroRepository = new HeroRepository();
        heroRepository.Create(heroOne);
        heroRepository.Create(heroTwo);
        Hero hero = heroRepository.Heroes.FirstOrDefault(h => h.Name == heroOneName);
        Assert.That(hero, Is.EqualTo(heroRepository.GetHero(heroOneName)));
    }
}