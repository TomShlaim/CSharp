using GarageLogic;
using System;
using System.Text;
using static GarageLogic.VehicleGenerator;

namespace ConsoleUI
{
    internal class MessageGenerator
    {
        public static void DisplayWelcomeMessage()
        {
            string quitMessage = string.Format(
@"Welcome to our garage!
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

Please choose a function by typing the function number out of the functions list below : 
(For example, if you wish to add a new vehicle to the garage, just press '1')

"
);

            Console.WriteLine(menu);
        }
        public static void DisplayInvalidFieldMessage(string i_ErrorMessage, string i_AdditionalInformation = "")
        {
            string invalidFieldMessage = string.Format(
@"
{0} {1}
Please try again!
"
, i_ErrorMessage, i_AdditionalInformation);

            Console.WriteLine(invalidFieldMessage);
        }
        public static void DisplayInsertFieldMessage(string i_FieldName, string i_AdditionalInformation = "")
        {
            string insertFieldMessage = string.Format(
@"
Please insert the {0} {1}:"
, i_FieldName, i_AdditionalInformation);

            Console.WriteLine(insertFieldMessage);
        }
        public static void DisplayInsertFieldWithValidEnumValuesMessage(string i_FieldName, Type i_EnumType)
        {
            DisplayInsertFieldMessage(i_FieldName, string.Format("({0})", getFieldValidValuesMessage(getEnumValueValues(i_EnumType))));
        }
        public static void DisplayCloseMessage()
        {
            string quitMessage = string.Format(
@"
Thanks for using our garage!
Quitting...");

            Console.WriteLine(quitMessage);
        }
        public static void DisplayChangeVehicleStatusMessage(eVehicleStatus i_NewVehicleStatus, string i_AdditionalInformation = "")
        {
            string quitMessage = string.Format(
@"
{0} Vehicle new status is :{1}.
", i_AdditionalInformation, i_NewVehicleStatus);

            Console.WriteLine(quitMessage);
        }
        public static void DisplayFieldMessage(eVehicleAdditionalFields field)
        {
            switch (field)
            {
                case eVehicleAdditionalFields.LicenseType:
                    DisplayInsertFieldWithValidEnumValuesMessage("license type", typeof(eLicenseType));
                    break;
                case eVehicleAdditionalFields.Color:
                    DisplayInsertFieldWithValidEnumValuesMessage("car color", typeof(eCarColor));
                    break;
                case eVehicleAdditionalFields.NumOfDoors:
                    DisplayInsertFieldWithValidEnumValuesMessage("number of doors", typeof(eNumOfDoors));
                    break;
                case eVehicleAdditionalFields.IsCarryingDangerousMaterial:
                case eVehicleAdditionalFields.IsRefrigeratedTransport:
                    DisplayInsertFieldMessage(getLowerCasedAndSpacedString(field.ToString()), getFieldValidValuesMessage("true, false")); 
                    break;
                default:
                    DisplayInsertFieldMessage(getLowerCasedAndSpacedString(field.ToString()));
                    break;
            }
        }
        public static void DisplayFunctionExecutionMessage(eGarageFunctions i_GarageFunction, bool i_isSuccess)
        {
            string functionExecutionResult = i_isSuccess ? "succeeded" : "failed";

            string quitMessage = string.Format(
@"
The garage function {0} {1}!
Please choose function out of the list below.
", getLowerCasedAndSpacedString(i_GarageFunction.ToString()), functionExecutionResult);

            Console.WriteLine(quitMessage);
        }
        private static string getEnumValueValues(Type i_EnumType)
        {
            return string.Join(", ", Enum.GetNames(i_EnumType));
        }
        private static string getFieldValidValuesMessage(string i_ValidValues)
        {
            return string.Format("The valid values are : {0}", i_ValidValues);
        }
        private static string getLowerCasedAndSpacedString(string i_String)
        {
            StringBuilder lowerCasedAndSpacedString = new StringBuilder();

            for (int i = 0; i < i_String.Length; i++)
            {
                char currentChar = i_String[i];

                if (i > 0 && Char.IsUpper(currentChar))
                {
                    lowerCasedAndSpacedString.Append(' ');
                }

                lowerCasedAndSpacedString.Append(Char.ToLower(currentChar));
            }

            return lowerCasedAndSpacedString.ToString();
        }
    }
}
