using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheMachineACafe;

namespace MachineCafeUnitTest
{
    [TestClass]
    public class UnitTestSet
    {
        public static GetADrinkClient client = new GetADrinkClient();
        private static readonly Random getrandom = new Random();

        [TestInitialize]
        public void Initialize()
        {
            ; //Nothing to do for now
        }


        [TestMethod]
        public void GetCoffee()
        {
            int iClientId = GetRandomID(1,10);
            SugarLevel iSugarLevel = GetRandomSugar();
            var responseDrink = client.GetMeADrink(iClientId, TheMachineACafe.DrinkType.COFFEE, iSugarLevel, false);
            Assert.AreEqual(responseDrink.MyDrinkType, TheMachineACafe.DrinkType.COFFEE);
            Assert.AreEqual(responseDrink.MySugarLevel, iSugarLevel);
        }

        [TestMethod]
        public void GetTea()
        {
            int iClientId = GetRandomID(1, 10);
            SugarLevel iSugarLevel = GetRandomSugar();
            var responseDrink = client.GetMeADrink(iClientId, TheMachineACafe.DrinkType.TEA, iSugarLevel, false);
            Assert.AreEqual(responseDrink.MyDrinkType, TheMachineACafe.DrinkType.TEA);
            Assert.AreEqual(responseDrink.MySugarLevel, iSugarLevel);
        }

        [TestMethod]
        public void GetChocolate()
        {
            int iClientId = GetRandomID(1, 10);
            SugarLevel iSugarLevel = GetRandomSugar();
            var responseDrink = client.GetMeADrink(iClientId, TheMachineACafe.DrinkType.CHOCOLATE, iSugarLevel, false);
            Assert.AreEqual(responseDrink.MyDrinkType, TheMachineACafe.DrinkType.CHOCOLATE);
            Assert.AreEqual(responseDrink.MySugarLevel, iSugarLevel);
        }

        private static int GetRandomID(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        private static SugarLevel GetRandomSugar()
        {
            lock (getrandom) // synchronize
            {
                return RandomEnumValue<SugarLevel>();
            }
        }

        private static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(new Random().Next(v.Length));
        }
    }
}
