using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class LogicValidator
    {
        public static int ValidateAndParseStringToInteger(string i_StringToParse) 
        {
            if(!int.TryParse(i_StringToParse, out int intToParse))
            {
                throw new ArgumentException("Invalid string! String is not an integer!");
            }

            return intToParse;
        }
        public static float ValidateAndParseStringToFloat(string i_StringToParse)
        {
            if (!float.TryParse(i_StringToParse, out float floatToParse))
            {
                throw new ArgumentException("Invalid string! String is not a float!");
            }

            return floatToParse;
        }
        public static bool ValidateAndParseStringToBoolean(string i_StringToParse)
        {
            if (!bool.TryParse(i_StringToParse, out bool boolToParse))
            {
                throw new ArgumentException("Invalid string! String is not a boolean!");
            }

            return boolToParse;
        }
        public static eCarColor ValidateAndParseStringToCarColor(string i_StringToParse)
        {
            if (!Enum.TryParse(i_StringToParse, out eCarColor carColor))
            {
                throw new ArgumentException("Invalid car color! String is not a car color!");
            }

            return carColor;
        }
        public static eNumOfDoors ValidateAndParseStringToNumOfDoors(string i_StringToParse)
        {
            if (!Enum.TryParse(i_StringToParse, out eNumOfDoors numOfDoors))
            {
                throw new ArgumentException("Invalid num of doors! String is not a num of doors!");
            }

            return numOfDoors;
        }
        public static eVehicleType ValidateAndParseStringToVehicleType(string i_StringToParse)
        {
            if (!Enum.TryParse(i_StringToParse, out eVehicleType vehicleType))
            {
                throw new ArgumentException("Invalid vehicle type! String is not a vehicle type!");
            }

            return vehicleType;
        }
        public static eVehicleStatus ValidateAndParseStringToVehicleStatus(string i_StringToParse)
        {
            if (!Enum.TryParse(i_StringToParse, out eVehicleStatus vehicleStatus))
            {
                throw new ArgumentException("Invalid vehicle status! String is not a vehicle status!");
            }

            return vehicleStatus;
        }
        public static eFuelType ValidateAndParseStringToFuelType(string i_StringToParse)
        {
            if (!Enum.TryParse(i_StringToParse, out eFuelType vehicleStatus))
            {
                throw new ArgumentException("Invalid fuel type! String is not a fuel type!");
            }

            return vehicleStatus;
        }
        public static bool IsValidRegisterationNumber(string i_RegisterationNumber)
        {
            return ValidateAndParseStringToInteger(i_RegisterationNumber) > 0;
        }
    }
}
