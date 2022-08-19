using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void PlanetConstructorF()
            {
                Planet planet = new Planet("Mars", 3.1);

                Assert.True(planet.Name == "Mars");
                Assert.True(planet.Budget == 3.1);
            }
            [Test]
            public void IfPlanetNameIsNull()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(null, 3.1);
                });
            }
            [Test]
            public void IfPlanetBudgetIsLessThenZero()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("Mars", -1);
                });
            }

            [Test]
            public void PlanetWeaponsCount()
            {
                Planet planet = new Planet("Mars", 3.1);

                Weapon weapon = new Weapon("ak47", 2.3, 3);

                planet.AddWeapon(weapon);
                Assert.True(planet.Weapons.Count == 1);
            }
            [Test]
            public void PlanetWeaponsPowerRatio()
            {
                Planet planet = new Planet("Mars", 3.1);

                Weapon weapon = new Weapon("ak47", 2.3, 3);
                Weapon weapon2 = new Weapon("ak478", 2.3, 3);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);
                Assert.True(planet.MilitaryPowerRatio == 6);
            }
            [Test]
            public void PlanetProfitMethod()
            {
                Planet planet = new Planet("Mars", 3.1);

                planet.Profit(3);

                Assert.True(planet.Budget == 6.1);
            }
            [Test]
            public void PlanetSpendFundsException()
            {
                Planet planet = new Planet("Mars", 3.1);

                Assert.That(() => planet.SpendFunds(4),
                    Throws.InvalidOperationException);
            }
            [Test]
            public void PlanetSpendFundsFunctionality()
            {
                Planet planet = new Planet("Mars", 3.1);

                planet.SpendFunds(2);
                Assert.True(planet.Budget == 1.1);
            }
            [Test]
            public void PlanetAddWeaponException()
            {
                Planet planet = new Planet("Mars", 3.1);
                Weapon weapon = new Weapon("hammer", 3, 3);
                Weapon weapon2 = new Weapon("hammer", 3, 3);

                planet.AddWeapon(weapon);
                Assert.That(() => planet.AddWeapon(weapon2),
                    Throws.InvalidOperationException);
            }
            [Test]
            public void PlanetRemoveWeaponFunctionality()
            {
                Planet planet = new Planet("Mars", 3.1);
                Weapon weapon = new Weapon("hammer", 3, 3);

                planet.AddWeapon(weapon);
                planet.RemoveWeapon("hammer");

                Assert.True(planet.Weapons.Count == 0);
            }
            [Test]
            public void PlanetUpgradeWeaponException()
            {
                Planet planet = new Planet("Mars", 3.1);
                Weapon weapon = new Weapon("hammer", 3, 3);

                planet.AddWeapon(weapon);

                Assert.That(() => planet.UpgradeWeapon("knife"),
                    Throws.InvalidOperationException);
            }
            [Test]
            public void PlanetUpgradeWeaponFunctionality()
            {
                Planet planet = new Planet("Mars", 3.1);
                Weapon weapon = new Weapon("hammer", 3, 3);

                planet.AddWeapon(weapon);

                planet.UpgradeWeapon("hammer");
                Assert.True(weapon.DestructionLevel == 4);
            }
            [Test]
            public void PlanetDestructionOpponentException()
            {
                Planet planet = new Planet("Mars", 3.1);
                Planet planet2 = new Planet("Earth", 3.1);
                Weapon weapon = new Weapon("hammer", 3, 3);
                Weapon weapon2 = new Weapon("knife", 3, 4);

                planet.AddWeapon(weapon);
                planet2.AddWeapon(weapon2);

                Assert.That(() => planet.DestructOpponent(planet2),
                    Throws.InvalidOperationException);
            }
            [Test]
            public void PlanetDestructionOpponentReturnsTheString()
            {
                Planet planet = new Planet("Mars", 3.1);
                Planet planet2 = new Planet("Earth", 3.1);
                Weapon weapon = new Weapon("hammer", 3, 3);
                Weapon weapon2 = new Weapon("knife", 3, 2);

                planet.AddWeapon(weapon);
                planet2.AddWeapon(weapon2);

                Assert.True(planet.DestructOpponent(planet2) == "Earth is destructed!");
            }
            [Test]
            public void WeaponConstructorTest()
            {
                Weapon weapon = new Weapon("hammer", 2, 3);

                Assert.True(weapon.Name == "hammer");
                Assert.True(weapon.Price == 2);
                Assert.True(weapon.DestructionLevel == 3);
            }
            [Test]
            public void WeaponPriceException()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weapon = new Weapon("hammer", -2, 3);
                });
            }
            [Test]
            public void WeaponIncreaseDestructionLevel()
            {
                Weapon weapon = new Weapon("hammer", 2, 3);

                weapon.IncreaseDestructionLevel();

                Assert.True(weapon.DestructionLevel == 4);
            }
            [Test]
            public void WeaponIsNuclear()
            {
                Weapon weapon = new Weapon("hammer", 2, 11);

                Assert.True(weapon.IsNuclear == true);
            }
        }

    }
}
