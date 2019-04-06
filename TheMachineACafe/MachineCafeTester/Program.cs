using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineCafeTester
{
    class Program
    {
        static void Main(string[] args)
        {
            GetADrinkClient client = new GetADrinkClient();
            //Client call for the client.GetMeADrink method
            client.Close();
        }
    }
}
