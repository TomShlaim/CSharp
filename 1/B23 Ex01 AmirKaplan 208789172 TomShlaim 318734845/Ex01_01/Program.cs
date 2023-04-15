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
            string binaryNumber1, binaryNumber2, binaryNumber3,
                decimalNumbersInDescendingOrder, statisticsMessage;
            float decimalNumber1, decimalNumber2, decimalNumber3,
                averageNumberOfZeros, averageNumberOfOnes;
            int sumOfZeros, sumOfOnes,
                numberOfPowersOfTwo, numberOfMultiplesOfFour,
                numberOfStrictlyDescendingByDigit, numberOfPalindromes;
            const bool v_CountZeros = true;

            Console.WriteLine("Please enter 3 binary numbers with 8 digits each:");
            binaryNumber1 = setToValidInput(Console.ReadLine());
            binaryNumber2 = setToValidInput(Console.ReadLine());
            binaryNumber3 = setToValidInput(Console.ReadLine());

            decimalNumber1 = convertBinaryToDecimal(binaryNumber1);
            decimalNumber2 = convertBinaryToDecimal(binaryNumber2);
            decimalNumber3 = convertBinaryToDecimal(binaryNumber3);

            decimalNumbersInDescendingOrder = getDecimalNumbersInDescendingOrder(decimalNumber1, decimalNumber2, decimalNumber3);
            numberOfPowersOfTwo = getNumberOfPowersOfTwo(decimalNumber1, decimalNumber2, decimalNumber3);
            numberOfMultiplesOfFour = getNumberOfMultiplesOfFour(decimalNumber1, decimalNumber2, decimalNumber3);
            numberOfStrictlyDescendingByDigit = getNumberOfStrictlyDescendingByDigit(decimalNumber1, decimalNumber2, decimalNumber3);
            numberOfPalindromes = getNumberOfPalindromes(decimalNumber1, decimalNumber2, decimalNumber3);
            sumOfZeros = sumOfOnesOrZeros(binaryNumber1, v_CountZeros) +
                         sumOfOnesOrZeros(binaryNumber2, v_CountZeros) + 
                         sumOfOnesOrZeros(binaryNumber3, v_CountZeros);
            sumOfOnes = sumOfOnesOrZeros(binaryNumber1, !v_CountZeros) +
                         sumOfOnesOrZeros(binaryNumber2, !v_CountZeros) +
                         sumOfOnesOrZeros(binaryNumber3, !v_CountZeros);
            averageNumberOfZeros = getAverageNumberOfOnesOrZeros(sumOfZeros, 3);
            averageNumberOfOnes = getAverageNumberOfOnesOrZeros(sumOfOnes, 3);

            statisticsMessage = string.Format(
                  @"The decimal numbers in descending order corresponding to the binary numbers entered are: {0}
                  There are {1} numbers that are a power of two.
                  The average number of zeros in the entered numbers are: {2} 
                  The average number of ones in the entered numbers are: {3}
                  There are {4} numbers that are a multiple of four.
                  There are {5} numbers that their digits form a strictly descending series.
                  There are {6} numbers that are palindromes."
                , decimalNumbersInDescendingOrder
                , numberOfPowersOfTwo
                , averageNumberOfZeros
                , averageNumberOfOnes
                , numberOfMultiplesOfFour
                , numberOfStrictlyDescendingByDigit
                , numberOfPalindromes);

            Console.WriteLine(statisticsMessage);
            Console.WriteLine("Please press 'Enter' to exit...");
            Console.ReadLine();
        }

        private static string getDecimalNumbersInDescendingOrder(float i_Decimal1, float i_Decimal2, float i_Decimal3)
        {
            float smallestNumber = i_Decimal1, middleNumber = i_Decimal2, biggestNumber = i_Decimal3, temporaryNumber = 0;

            if (middleNumber < smallestNumber)
            {
                temporaryNumber = smallestNumber;
                smallestNumber = middleNumber;
                middleNumber = temporaryNumber;
            }

            if (biggestNumber < middleNumber)
            {
                temporaryNumber = middleNumber;
                middleNumber = biggestNumber;
                biggestNumber = temporaryNumber;

                if (middleNumber < smallestNumber)
                {
                    temporaryNumber = smallestNumber;
                    smallestNumber = middleNumber;
                    middleNumber = temporaryNumber;
                } 
            }
            
            return string.Format("{0}, {1}, {2}", biggestNumber, middleNumber, smallestNumber);
        }

        private static bool isValidBinaryNumber(string i_BinaryString)
        {
            bool validBinaryNumber = true;
            if (i_BinaryString.Length != 8)
            {
                validBinaryNumber = false;
            }
            else
            {
                for (int i = 0; i < i_BinaryString.Length; i++)
                {
                    if (i_BinaryString[i] != '0' && i_BinaryString[i] != '1')
                    {
                        validBinaryNumber = false;
                        break;
                    }
                }
            }

            return validBinaryNumber;
        }

        private static string setToValidInput(string io_CurrentInput)
        {
            while (!isValidBinaryNumber(io_CurrentInput))
            {
                Console.WriteLine("The input you entered is invalid. Please try again.");
                io_CurrentInput = Console.ReadLine();
            }

            return io_CurrentInput;
        }

        private static float convertBinaryToDecimal(string i_BinaryString)
        {
            double decimalNumber = 0;
            double powerCounter = 0;
            for (int i = i_BinaryString.Length - 1; i >= 0; i--)
            {
                double currentDigit = double.Parse(i_BinaryString[i].ToString());
                if (powerCounter == 0 && currentDigit == 0)
                {
                    powerCounter++;
                    continue;
                }
                decimalNumber += Math.Pow(currentDigit*2, powerCounter);
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

        private static int getNumberOfPowersOfTwo(float i_Decimal1, float i_Decimal2, float i_Decimal3)
        {
            int numberOfPowersOfTwo = 0;

            if (isPowerOfTwo(i_Decimal1))
            {
                numberOfPowersOfTwo++;
            }

            if (isPowerOfTwo(i_Decimal2))
            {
                numberOfPowersOfTwo++;
            }

            if (isPowerOfTwo(i_Decimal3))
            {
                numberOfPowersOfTwo++;
            }

            return numberOfPowersOfTwo;
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

        private static float getAverageNumberOfOnesOrZeros(int i_SumOfOnesOrZeros, int i_NumberOfInputs)
        {
            return (float)(i_SumOfOnesOrZeros / i_NumberOfInputs);
        }

        private static bool isMultipleOfFour(float i_DecimalNumber)
        {
            return i_DecimalNumber % 4 == 0;
        }

        private static int getNumberOfMultiplesOfFour(float i_Decimal1, float i_Decimal2, float i_Decimal3)
        {
            int numberOfMultiplesOfFour = 0;

            if(isMultipleOfFour(i_Decimal1))
            {
                numberOfMultiplesOfFour++;
            }

            if (isMultipleOfFour(i_Decimal2))
            {
                numberOfMultiplesOfFour++;
            }

            if (isMultipleOfFour(i_Decimal3))
            {
                numberOfMultiplesOfFour++;
            }

            return numberOfMultiplesOfFour;
        }

        private static bool areDigitsOfNumberStrictlyDescending(float i_DecimalNumber)
        {
            bool digitsOfNumberStrictlyDescending = true;
            float previousDigit = i_DecimalNumber % 10;

            i_DecimalNumber /= 10;
            while (i_DecimalNumber != 0)
            {
                float currentDigit = i_DecimalNumber % 10;

                if (currentDigit <= previousDigit)
                {
                    digitsOfNumberStrictlyDescending = false;
                    break;
                }

                previousDigit = currentDigit;
                i_DecimalNumber /= 10;
            }

            return digitsOfNumberStrictlyDescending;
        }

        private static int getNumberOfStrictlyDescendingByDigit(float i_Decimal1, float i_Decimal2, float i_Decimal3)
        {
            int numberOfStrictlyDescendingByDigit = 0;

            if (areDigitsOfNumberStrictlyDescending(i_Decimal1))
            {
                numberOfStrictlyDescendingByDigit++;
            }

            if (areDigitsOfNumberStrictlyDescending(i_Decimal1))
            {
                numberOfStrictlyDescendingByDigit++;
            }

            if (areDigitsOfNumberStrictlyDescending(i_Decimal1))
            {
                numberOfStrictlyDescendingByDigit++;
            }

            return numberOfStrictlyDescendingByDigit;
        }

        private static bool isPalindrome(float i_DecimalNumber)
        {
            bool palindrome = true;
            string decimalString = ((int)i_DecimalNumber).ToString();
            int currentLeftDigitIdx = 0;
            int currentRightDigitIdx = decimalString.Length - 1;

            while (currentLeftDigitIdx <= currentRightDigitIdx && decimalString[currentLeftDigitIdx] == decimalString[currentRightDigitIdx]) 
            {
                currentLeftDigitIdx++;
                currentRightDigitIdx--;
            }

            if (currentLeftDigitIdx <= currentRightDigitIdx)
            {
                palindrome = false;
            }

            return palindrome;
            /*
            while (i_DecimalNumber / 100 != 0)
            {
                int leastSignificantDigit = (int)(i_DecimalNumber % 10);
                int mostSignificantDigit = (int)(i_DecimalNumber /)
            }*/
        }

        private static int getNumberOfPalindromes(float i_Decimal1, float i_Decimal2, float i_Decimal3)
        {
            int numberOfPalindromes = 0;

            if (isPalindrome(i_Decimal1))
            {
                numberOfPalindromes++;
            }

            if (isPalindrome(i_Decimal2))
            {
                numberOfPalindromes++;
            }

            if (isPalindrome(i_Decimal3))
            {
                numberOfPalindromes++;
            }

            return numberOfPalindromes;
        }

    }
}
