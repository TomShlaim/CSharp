using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    internal class MenuValidator
    {
        public static bool IsValidOption(string i_ChosenOption, int i_AmountOfMenuItems)
        {
            bool validOption = int.TryParse(i_ChosenOption, out int optionIndex);

            if (!validOption)
            {
                Console.WriteLine("Input must be an integer, try again.");
            }
            else
            {
                if (optionIndex < 0 || optionIndex > i_AmountOfMenuItems)
                {
                    validOption = false;
                    Console.WriteLine("Input must be an integer in the range 0-{0}, try again.", i_AmountOfMenuItems.ToString());
                }
            }

            return validOption;
        }
    }
}
