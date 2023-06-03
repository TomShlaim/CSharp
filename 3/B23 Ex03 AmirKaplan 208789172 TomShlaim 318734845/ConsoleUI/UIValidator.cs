using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    internal class UIValidator
    {
        public static bool IsValidGarageFunction(string i_GarageFunctionNumber)
        {
            int garageFunctionNumber;
            bool isValidNumber = int.TryParse(i_GarageFunctionNumber, out garageFunctionNumber);
            bool isValidGarageFunctionNumber = false;

            if (isValidNumber)
            {
                isValidGarageFunctionNumber = Enum.IsDefined(typeof(eGarageFunctions), garageFunctionNumber);
            }

            return isValidGarageFunctionNumber;
        }
    }
}
