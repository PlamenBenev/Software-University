namespace Gyms.Tests
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class GymsTests
    {
        [Test]

        public void GymConstructorTest()
        {
            Gym gym = new Gym("Impact", 3);

            Assert.True(gym.Name == "Impact");
            Assert.True(gym.Capacity == 3);
        }
        [Test]

        public void GymNameException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(null, 3);
            });
        }
        [Test]
        public void GymCapacityException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("Impact", -1);
            });
        }
        [Test]
        public void GymCount()
        {
            Gym gym = new Gym("Impact", 3);

            Athlete athlete = new Athlete("Pesho");
            gym.AddAthlete(athlete);

            Assert.True(gym.Count == 1);
        }
        [Test]
        public void AddAthleteException()
        {
            Gym gym = new Gym("Impact", 1);

            Athlete athlete = new Athlete("Pesho");
            Athlete athlete2 = new Athlete("Gosho");
            gym.AddAthlete(athlete);

            Assert.That(() => gym.AddAthlete(athlete2),
                Throws.InvalidOperationException);
        }
        [Test]
        public void RemoveAthleteException()
        {
            Gym gym = new Gym("Impact", 1);

            Athlete athlete = new Athlete("Pesho");
            Athlete athlete2 = new Athlete("Gosho");
            gym.AddAthlete(athlete);

            Assert.That(() => gym.RemoveAthlete("Grisho"),
                Throws.InvalidOperationException);
        }
        [Test]
        public void GymRemoveFunctionality()
        {
            Gym gym = new Gym("Impact", 3);

            Athlete athlete = new Athlete("Pesho");
            gym.AddAthlete(athlete);
            gym.RemoveAthlete("Pesho");
            Assert.True(gym.Count == 0);
        }
        [Test]
        public void InjureAthleteException()
        {
            Gym gym = new Gym("Impact", 1);

            Athlete athlete = new Athlete("Pesho");
            Athlete athlete2 = new Athlete("Gosho");
            gym.AddAthlete(athlete);

            Assert.That(() => gym.InjureAthlete("Grisho"),
                Throws.InvalidOperationException);
        }
        [Test]
        public void GymInjureAthleteFunctionality()
        {
            Gym gym = new Gym("Impact", 3);

            Athlete athlete = new Athlete("Pesho");
            gym.AddAthlete(athlete);
            gym.InjureAthlete("Pesho");
            Assert.True(gym.InjureAthlete("Pesho") == athlete);
            Assert.True(athlete.IsInjured == true);
        }
        [Test]
        public void GymReportFunctionality()
        {
            Gym gym = new Gym("Impact", 3);

            Athlete athlete = new Athlete("Pesho");
            Athlete athlete2 = new Athlete("Grisho");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.True(gym.Report() == "Active athletes at Impact: Pesho, Grisho");
        }
        [Test]
        public void AthleteConstructor()
        {
            Athlete athlete = new Athlete("Pesho");
            Assert.True(athlete.FullName == "Pesho");
            Assert.True(athlete.IsInjured == false);
        }
    }
}
