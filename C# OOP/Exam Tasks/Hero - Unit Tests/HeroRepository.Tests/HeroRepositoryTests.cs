using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    [Test]
    public void HeroConstructorCheck()
    {
        Hero hero = new Hero("Gosho",3);

        Assert.True(hero.Name == "Gosho");
        Assert.True(hero.Level == 3);
    }
    [Test]
    public void CreateHeroNullException()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = null;

        Assert.That(() => heroRepository.Create(hero),
            Throws.ArgumentNullException);
    }
    [Test]
    public void CreateHeroExistException()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Gosho", 3);
        heroRepository.Create(hero);

        Assert.That(() => heroRepository.Create(hero),
            Throws.InvalidOperationException);
    }
    [Test]
    public void CreateHeroAddedToData()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Gosho", 3);
        heroRepository.Create(hero);

        Assert.True(heroRepository.Heroes.Count == 1);
    }
    [Test]
    public void CreateHeroReturnMassege()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Gosho", 3);

        Assert.True(heroRepository.Create(hero) == "Successfully added hero Gosho with level 3");
    }
    [Test]
    public void RemoveException()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Gosho", 3);
        heroRepository.Create(hero);

        Assert.That(() => heroRepository.Remove(null),
            Throws.ArgumentNullException);
    }
    [Test]
    public void IsItRemoved()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Gosho", 3);
        heroRepository.Create(hero);
        heroRepository.Remove("Gosho");

        Assert.True(heroRepository.Heroes.Count == 0);
    }
    [Test]
    public void RemovedReturnsBool()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Gosho", 3);
        heroRepository.Create(hero);

        Assert.True(heroRepository.Remove("Gosho") == true);
    }
    [Test]
    public void GetHighestLevel()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Gosho", 3);
        Hero hero2 = new Hero("Pesho", 4);
        heroRepository.Create(hero);
        heroRepository.Create(hero2);

        Assert.True(heroRepository.GetHeroWithHighestLevel() == hero2);
    }
    [Test]
    public void GetHeroFunc()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Gosho", 3);
        Hero hero2 = new Hero("Pesho", 4);
        heroRepository.Create(hero);
        heroRepository.Create(hero2);

        Assert.True(heroRepository.GetHero("Pesho") == hero2);
    }
}