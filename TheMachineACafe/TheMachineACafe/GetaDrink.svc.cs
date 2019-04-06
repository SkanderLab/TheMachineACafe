using System;
using System.Collections.Concurrent;
using System.Web.Script.Serialization;

namespace TheMachineACafe
{
    public class GetADrink : IGetADrink
    {
        private static ConcurrentDictionary<int, Drink> coffeeOrders = new ConcurrentDictionary<int, Drink>();
        private JavaScriptSerializer _serialiser = new JavaScriptSerializer();

        public Drink GetMeADrink(int UserID, DrinkType requestedDrinkType, SugarLevel requestedSugarLevel, bool havingACup)
        {
            if (requestedDrinkType == DrinkType.None)
            {
                throw new ArgumentNullException("No Proper Drink Selected. Please make your choise !");
            }
            var oderedDrink = new Drink(requestedDrinkType, requestedSugarLevel, havingACup);
            coffeeOrders.AddOrUpdate(UserID, oderedDrink, (key, oldvalue) => oldvalue = oderedDrink);
            PersistOrder(UserID, oderedDrink);
            return oderedDrink;
        }

        public Drink GetMyFavouriteDrink(int UserID)
        {
            Drink LastDrink;

            if(coffeeOrders.TryGetValue(UserID, out LastDrink))
                return LastDrink;
            throw new ArgumentNullException("No Older drink saved. Please make your choise and make it favourite!");
        }

        public void PersistOrder(int UserID, Drink givenDrink)
        {
            using (MachineCafeDBEntities db = new MachineCafeDBEntities())
            {
                ClientDrinkOrders order = new ClientDrinkOrders();
                order.UserID = UserID;
                order.Drink = _serialiser.Serialize(givenDrink);
                db.ClientDrinkOrders.Add(order);
            }
        }
    }
}
