using System;

namespace Ex01_01
{
    internal class Program
    {
        public static void Main()
        {
            binaryStringsStatisticsProgram();
        }
        
        private static void binaryStringsStatisticsProgram()
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
            setToValidInput(out binaryNumber1);
            setToValidInput(out binaryNumber2);
            setToValidInput(out binaryNumber3);

            decimalNumber1 = convertBinaryToDecimal(binaryNumber1);
            decimalNumber2 = convertBinaryToDecimal(binaryNumber2);
            decimalNumber3 = convertBinaryToDecimal(binaryNumber3);

            setDecimalNumbersInDescendingOrder(decimalNumber1, decimalNumber2, decimalNumber3, out decimalNumbersInDescendingOrder);
            setNumberOfPowersOfTwo(decimalNumber1, decimalNumber2, decimalNumber3, out numberOfPowersOfTwo);
            setNumberOfMultiplesOfFour(decimalNumber1, decimalNumber2, decimalNumber3, out numberOfMultiplesOfFour);
            setNumberOfStrictlyDescendingByDigit(decimalNumber1, decimalNumber2, decimalNumber3, out numberOfStrictlyDescendingByDigit);
            setNumberOfPalindromes(decimalNumber1, decimalNumber2, decimalNumber3, out numberOfPalindromes);
            sumOfZeros = sumOfOnesOrZeros(binaryNumber1, v_CountZeros) +
                         sumOfOnesOrZeros(binaryNumber2, v_CountZeros) + 
                         sumOfOnesOrZeros(binaryNumber3, v_CountZeros);
            sumOfOnes = sumOfOnesOrZeros(binaryNumber1, !v_CountZeros) +
                         sumOfOnesOrZeros(binaryNumber2, !v_CountZeros) +
                         sumOfOnesOrZeros(binaryNumber3, !v_CountZeros);
            setAverageNumberOfOnesOrZeros(sumOfZeros, out averageNumberOfZeros);
            setAverageNumberOfOnesOrZeros(sumOfOnes, out averageNumberOfOnes);

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

        private static void setToValidInput(out string o_CurrentUserInput)
        {
            o_CurrentUserInput = Console.ReadLine();
            while (!isValidBinaryNumber(o_CurrentUserInput))
            {
                Console.WriteLine("The input you entered is invalid. Please try again.");
                o_CurrentUserInput = Console.ReadLine();
            }
        }

        private static void setDecimalNumbersInDescendingOrder(float i_Decimal1, float i_Decimal2, float i_Decimal3, out string o_DecimalNumbersInDescendingOrder)
        {
            float smallestNumber = i_Decimal1, middleNumber = i_Decimal2, biggestNumber = i_Decimal3;

            if (middleNumber < smallestNumber)
            {
                swap(ref middleNumber, ref smallestNumber);
            }

            if (biggestNumber < middleNumber)
            {
                swap(ref biggestNumber, ref middleNumber);

                if (middleNumber < smallestNumber)
                {
                    swap(ref middleNumber, ref smallestNumber);
                } 
            }

            o_DecimalNumbersInDescendingOrder = string.Format("{0}, {1}, {2}", biggestNumber, middleNumber, smallestNumber);
        }

        private static void swap(ref float io_Num1, ref float io_Num2)
        {
            float temp = io_Num2;
            io_Num2 = io_Num1;
            io_Num1 = temp;
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

        private static void setNumberOfPowersOfTwo(float i_Decimal1, float i_Decimal2, float i_Decimal3, out int o_NumberOfPowersOfTwo)
        {
            o_NumberOfPowersOfTwo = 0;

            if (isPowerOfTwo(i_Decimal1))
            {
                o_NumberOfPowersOfTwo++;
            }

            if (isPowerOfTwo(i_Decimal2))
            {
                o_NumberOfPowersOfTwo++;
            }

            if (isPowerOfTwo(i_Decimal3))
            {
                o_NumberOfPowersOfTwo++;
            }
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

        private static void setAverageNumberOfOnesOrZeros(int i_SumOfOnesOrZeros, out float o_AverageNumberOfOnesOrZeros, int i_NumberOfInputs = 3)
        {
            o_AverageNumberOfOnesOrZeros = (float)i_SumOfOnesOrZeros / i_NumberOfInputs;
        }

        private static bool isMultipleOfFour(float i_DecimalNumber)
        {
            return i_DecimalNumber % 4 == 0;
        }

        private static void setNumberOfMultiplesOfFour(float i_Decimal1, float i_Decimal2, float i_Decimal3, out int o_NumberOfMultiplesOfFour)
        {
            o_NumberOfMultiplesOfFour = 0;

            if(isMultipleOfFour(i_Decimal1))
            {
                o_NumberOfMultiplesOfFour++;
            }

            if (isMultipleOfFour(i_Decimal2))
            {
                o_NumberOfMultiplesOfFour++;
            }

            if (isMultipleOfFour(i_Decimal3))
            {
                o_NumberOfMultiplesOfFour++;
            }
        }

        private static bool areDigitsOfNumberStrictlyDescending(float i_DecimalNumber)
        {
            bool digitsOfNumberStrictlyDescending = true;
            int copyOfDecimal = (int)i_DecimalNumber; 
            int previousDigit = -1;   // Start with a value smaller than any digit

            while (copyOfDecimal > 0)
            {
                int currentDigit = copyOfDecimal % 10;

                if (currentDigit <= previousDigit)
                {
                    digitsOfNumberStrictlyDescending = false;
                    break;
                }

                previousDigit = currentDigit;
                copyOfDecimal /= 10;
            }

            return digitsOfNumberStrictlyDescending;
        }

        private static void setNumberOfStrictlyDescendingByDigit(float i_Decimal1, float i_Decimal2, float i_Decimal3, out int o_NumberOfStrictlyDescendingByDigit)
        {
            o_NumberOfStrictlyDescendingByDigit = 0;

            if (areDigitsOfNumberStrictlyDescending(i_Decimal1))
            {
                o_NumberOfStrictlyDescendingByDigit++;
            }

            if (areDigitsOfNumberStrictlyDescending(i_Decimal2))
            {
                o_NumberOfStrictlyDescendingByDigit++;
            }

            if (areDigitsOfNumberStrictlyDescending(i_Decimal3))
            {
                o_NumberOfStrictlyDescendingByDigit++;
            }
        }

        private static bool isPalindrome(float i_DecimalNumber)
        {
            int reversedNumber = 0, copyOfDecimal = (int)i_DecimalNumber;

            while (copyOfDecimal > 0)
            {
                reversedNumber = (reversedNumber * 10) + (copyOfDecimal % 10);
                copyOfDecimal /= 10;
            }

            return reversedNumber == i_DecimalNumber;

        }

        private static void setNumberOfPalindromes(float i_Decimal1, float i_Decimal2, float i_Decimal3, out int o_NumberOfPalindromes)
        {
            o_NumberOfPalindromes = 0;

            if (isPalindrome(i_Decimal1))
            {
                o_NumberOfPalindromes++;
            }

            if (isPalindrome(i_Decimal2))
            {
                o_NumberOfPalindromes++;
            }

            if (isPalindrome(i_Decimal3))
            {
                o_NumberOfPalindromes++;
            }
        }

    }
}
