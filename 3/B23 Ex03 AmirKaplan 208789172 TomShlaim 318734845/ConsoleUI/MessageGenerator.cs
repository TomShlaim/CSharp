using GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    internal class MessageGenerator
    {
        public static void DisplayWelcomeMessage()
        {
            string quitMessage = string.Format(
@"Welcome to our garage!
Please choose a function by typing the function number out of the functions list below.
");

            Console.WriteLine(quitMessage);
        }
        public static void DisplayMenu()
        {
            string menu = string.Format(
@"Garage Functions : 
=====================
1. Add a new vehicle to the garage.
2. Get all vehicles' registeration numbers by vehicle status, if supplied.
3. Change the status of a vehicle in the garage.
4. Inflate vehicle's wheels to maximum.
5. Fuel vehicle.
6. Charge vehicle
7. Get specific vehicle data.
8. Quit.
"
);

            Console.WriteLine(menu);
        }
        public static void DisplayInvalidFieldMessage(string i_FieldName, string i_AdditionalInformation = "")
        {
            string invalidFieldMessage = string.Format(
@"Invalid {0}! {1}
Please try again.
"
, i_FieldName, i_AdditionalInformation);

            Console.WriteLine(invalidFieldMessage);
        }
        public static void DisplayQuitMessage()
        {
            string quitMessage = string.Format(
@"Thanks for using our garage!
Quiting...
");

            Console.WriteLine(quitMessage);
        }

    }
}
