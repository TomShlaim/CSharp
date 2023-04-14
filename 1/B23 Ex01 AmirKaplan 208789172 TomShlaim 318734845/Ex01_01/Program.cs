using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_01
{
    internal class Program
    {
        public static void Main()
        {
            getStatisticsAboutBinaryStrings();
        }
        
        private static void getStatisticsAboutBinaryStrings()
        {

        }

        private static void printSortedDecimalNumbers(float i_Decimal1, float i_Decimal2, float i_Decimal3)
        {

        }
        private static bool isValidBinaryNumber(string i_BinaryString)
        {
            for (int i = 0; i < i_BinaryString.Length; i++)
            {
                if (i_BinaryString[i] != '0' || i_BinaryString[i] != '1')
                {
                    return false;
                }
            }

            return true;
        }

        private static float convertBinaryToDecimal(string i_BinaryString)
        {
            double decimalNumber = 0;
            double powerCounter = 0;
            for (int i = i_BinaryString.Length - 1; i >= 0; i--)
            {
                double currentDigit = double.Parse(i_BinaryString[i].ToString());
                decimalNumber += Math.Pow(currentDigit, powerCounter);
                powerCounter++;
            }

            return (float)decimalNumber;
        }

        private static bool isPowerOfTwo(float i_DecimalNumber)
        {
            while (i_DecimalNumber % 2 == 0)
            {
                i_DecimalNumber /= 2;
            }

            return i_DecimalNumber == 1;
        }

        private static int sumOfOnesOrZeros(string i_BinaryString, bool i_CountZeros)
        {
            int zerosCounter = 0;
            int onesCounter = 0;
            
            for (int i = 0; i < i_BinaryString.Length; i++)
            {
                if (i_BinaryString[i] == '0')
                {
                    zerosCounter++;
                }
                else
                {
                    onesCounter++;
                }
            }

            return i_CountZeros ? zerosCounter : onesCounter;
        }

        private static float getAverageNumberOfOnesOrZeros(int i_SumOfOnesOrZeros, int i_NumberOfInputs, bool i_CountZeros)
        {
            float dummy = 1;
            return dummy;
        }

        private static bool isMultipleOfFour(float i_DecimalNumber)
        {
            return i_DecimalNumber % 4 == 0;
        }

        private static bool areDigitsOfNumberStrictlyDescending(float i_DecimalNumber)
        {
            float previousDigit = i_DecimalNumber % 10;

            i_DecimalNumber /= 10;
            while (i_DecimalNumber != 0)
            {
                float currentDigit = i_DecimalNumber % 10;

                if (currentDigit <= previousDigit)
                {
                    return false;
                }

                previousDigit = currentDigit;
                i_DecimalNumber /= 10;
            }

            return true;
        }

        private static bool isPalindrome(float i_DecimalNumber)
        {
            return true;
        }



    }
}
