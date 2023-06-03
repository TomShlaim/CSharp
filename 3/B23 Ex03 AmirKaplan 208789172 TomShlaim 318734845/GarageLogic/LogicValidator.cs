using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class LogicValidator
    {
        public static int ValidateAndParseStringToInteger(string stringToParse) 
        {
            if(!int.TryParse(stringToParse, out int intToParse))
            {
                throw new ArgumentException("String is not an integer!");
            }

            return intToParse;
        }
        public static float ValidateAndParseStringToFloat(string stringToParse)
        {
            if (!float.TryParse(stringToParse, out float floatToParse))
            {
                throw new ArgumentException("String is not a float!");
            }

            return floatToParse;
        }
        public static bool ValidateAndParseStringToBoolean(string stringToParse)
        {
            if (!bool.TryParse(stringToParse, out bool boolToParse))
            {
                throw new ArgumentException("String is not a boolean!");
            }

            return boolToParse;
        }
        public static eCarColor ValidateAndParseStringToCarColor(string stringToParse)
        {
            if (!Enum.TryParse(stringToParse, out eCarColor carColor))
            {
                throw new ArgumentException("String is not a car color!");
            }

            return carColor;
        }
        public static eNumOfDoors ValidateAndParseStringToNumOfDoors(string stringToParse)
        {
            if (!Enum.TryParse(stringToParse, out eNumOfDoors numOfDoors))
            {
                throw new ArgumentException("String is not a num of doors!");
            }

            return numOfDoors;
        }
    }
}
