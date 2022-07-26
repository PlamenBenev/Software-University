using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]

        public void IfShopConstructorReturnCorrect()
        {
            Shop smartphoneShop = new Shop(2);

            Assert.True(smartphoneShop.Capacity == 2);
        }
        [Test]

        public void ShopCapacityExeption()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop smartphoneShop = new Shop(-1);
            });
        }
        [Test]
        public void IfShopCountIsCorrect()
        {
            Shop shop = new Shop(3);
            Smartphone phone1 = new Smartphone("Samsung",4);
            Smartphone phone2 = new Smartphone("Iphone", 4);

            shop.Add(phone1);
            shop.Add(phone2);

            Assert.True(shop.Count == 2);
        }
        [Test]
        public void IfAddThrowsExceptionOnSameModels()
        {
            Shop shop = new Shop(3);
            Smartphone phone1 = new Smartphone("Samsung", 4);
            Smartphone phone2 = new Smartphone("Samsung", 4);

            shop.Add(phone1);
            Assert.That(()=> shop.Add(phone2),
                Throws.InvalidOperationException);
        }
        [Test]
        public void IfAddThrowsExceptionOnCapacity()
        {
            Shop shop = new Shop(1);
            Smartphone phone1 = new Smartphone("Samsung", 4);
            Smartphone phone2 = new Smartphone("Iphone", 4);

            shop.Add(phone1);
            Assert.That(() => shop.Add(phone2),
                Throws.InvalidOperationException);
        }
        [Test]
        public void IfRemoveThrowsException()
        {
            Shop shop = new Shop(1);
            Smartphone phone1 = new Smartphone("Samsung", 4);
            Smartphone phone2 = new Smartphone("Iphone", 4);

            shop.Add(phone1);
            Assert.That(() => shop.Remove("Iphone"),
                Throws.InvalidOperationException);
        }
        [Test]
        public void AddAndRemoveFunctionality()
        {
            Shop shop = new Shop(1);
            Smartphone phone1 = new Smartphone("Samsung", 4);

            shop.Add(phone1);
            Assert.True(shop.Count == 1);
            shop.Remove("Samsung");
            Assert.True(shop.Count == 0);
        }
        [Test]
        public void IfTestPhoneThrowsExceptionIfTheNameIsWrong()
        {
            Shop shop = new Shop(1);
            Smartphone phone1 = new Smartphone("Samsung", 4);
            Smartphone phone2 = new Smartphone("Iphone", 4);

            shop.Add(phone1);
            Assert.That(() => shop.TestPhone("Iphone",4),
                Throws.InvalidOperationException);
        }
        [Test]
        public void IfTestPhoneThrowsExceptionIfUsageIsLower()
        {
            Shop shop = new Shop(1);
            Smartphone phone1 = new Smartphone("Samsung", 4);

            phone1.CurrentBateryCharge = 3;

            shop.Add(phone1);
            Assert.That(() => shop.TestPhone("Samsung", 4),
                Throws.InvalidOperationException);
        }
        [Test]
        public void PhoneTestFunctionality()
        {
            Shop shop = new Shop(1);
            Smartphone phone1 = new Smartphone("Samsung", 4);
            phone1.CurrentBateryCharge = 4;

            shop.Add(phone1);
            shop.TestPhone("Samsung", 4);
            Assert.True(phone1.CurrentBateryCharge == 0);
        }
        [Test]
        public void IfChargePhoneThrowsException()
        {
            Shop shop = new Shop(1);
            Smartphone phone1 = new Smartphone("Samsung", 4);

            shop.Add(phone1);
            Assert.That(() => shop.ChargePhone("Iphone"),
                Throws.InvalidOperationException);
        }
        [Test]
        public void ChargePhoneFunctionality()
        {
            Shop shop = new Shop(1);
            Smartphone phone1 = new Smartphone("Samsung", 4);
            phone1.CurrentBateryCharge = 3;
            shop.Add(phone1);
            shop.ChargePhone("Samsung");

            Assert.True(phone1.CurrentBateryCharge == phone1.MaximumBatteryCharge); ;
        }
        [Test]
        public void SmartphoneConstructorCheck()
        {
            Smartphone phone = new Smartphone("Samsung",4);
            Assert.True(phone.ModelName == "Samsung");
            Assert.True(phone.CurrentBateryCharge == phone.MaximumBatteryCharge);
            Assert.True(phone.MaximumBatteryCharge == 4);
        }
    }
}