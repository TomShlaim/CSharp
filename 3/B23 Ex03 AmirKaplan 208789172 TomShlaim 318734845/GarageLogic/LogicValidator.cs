using System;

namespace GarageLogic
{
    public class LogicValidator
    {
        public static int ValidateAndParseStringToInteger(string i_StringToParse) 
        {
            if(!int.TryParse(i_StringToParse, out int intToParse))
            {
                throw new FormatException("Invalid value! Value is not an integer!");
            }

            return intToParse;
        }
        public static float ValidateAndParseStringToPositiveFloat(string i_StringToParse)
        {
            if (!float.TryParse(i_StringToParse, out float floatToParse))
            {
                throw new FormatException("Invalid value! Value is not a float!");
            }
            else if(floatToParse < 0.0f)
            {
                throw new ArgumentException("Invalid value! Value most be positive!");
            }

            return floatToParse;
        }
        public static bool ValidateAndParseStringToBoolean(string i_StringToParse)
        {
            if (!bool.TryParse(i_StringToParse, out bool boolToParse))
            {
                throw new FormatException("Invalid value! Value is not a boolean!");
            }

            return boolToParse;
        }
        public static eCarColor ValidateAndParseStringToCarColor(string i_StringToParse)
        {
            if (!Enum.TryParse(i_StringToParse, out eCarColor carColor))
            {
                throw new FormatException("Invalid car color! Value is not a car color!");
            }

            return carColor;
        }
        public static eNumOfDoors ValidateAndParseStringToNumOfDoors(string i_StringToParse)
        {
            if (!Enum.TryParse(i_StringToParse, out eNumOfDoors numOfDoors))
            {
                throw new FormatException("Invalid num of doors! Value is not a num of doors!");
            }

            return numOfDoors;
        }
        public static eVehicleType ValidateAndParseStringToVehicleType(string i_StringToParse)
        {
            if (!Enum.TryParse(i_StringToParse, out eVehicleType vehicleType))
            {
                throw new FormatException("Invalid vehicle type! Value is not a vehicle type!");
            }

            return vehicleType;
        }
        public static eVehicleStatus ValidateAndParseStringToVehicleStatus(string i_StringToParse)
        {
            if (!Enum.TryParse(i_StringToParse, out eVehicleStatus vehicleStatus))
            {
                throw new FormatException("Invalid vehicle status! Value is not a vehicle status!");
            }

            return vehicleStatus;
        }
        public static eFuelType ValidateAndParseStringToFuelType(string i_StringToParse)
        {
            if (!Enum.TryParse(i_StringToParse, out eFuelType vehicleStatus))
            {
                throw new FormatException("Invalid fuel type! Value is not a fuel type!");
            }

            return vehicleStatus;
        }
        public static eLicenseType ValidateAndParseLicenseType(string i_StringToParse)
        {
            if (!Enum.TryParse(i_StringToParse, out eLicenseType licenseType))
            {
                throw new FormatException("Invalid fuel type! Value is not a fuel type!");
            }

            return licenseType;
        }
        public static bool IsValidRegisterationNumber(string i_RegisterationNumber)
        {
            return isPositiveInteger(i_RegisterationNumber);
        }
        public static bool IsValidPhoneNumber(string i_PhoneNumber)
        {
            return isPositiveInteger(i_PhoneNumber);
        }
        private static bool isPositiveInteger(string i_String)
        {
            return ValidateAndParseStringToInteger(i_String) > 0;
        }
    }
}
