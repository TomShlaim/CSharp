using System;
using System.Text;

namespace Ex01_05
{
    internal class Program
    {
        public static void Main()
        {
            numberStatisticsProgram();
        }

        private static void numberStatisticsProgram()
        {
            string inputString, statisticsMessage;
            int inputInteger, numOfDigitsBiggerThanLSD, smallestDigit, numOfMultiplesOfThree;
            float averageOfDigits;

            Console.WriteLine("Please enter a 6 digit integer.");
            setToValidInput(out inputString, out inputInteger);

            numOfDigitsBiggerThanLSD = getNumOfDigitsBiggerThanLSD(inputInteger);
            smallestDigit = getSmallestDigit(inputString);
            numOfMultiplesOfThree = getNumOfMultiplesOfThree(inputString);
            averageOfDigits = getAverageOfDigits(inputInteger);

            statisticsMessage = string.Format(
@"The integer you entered has {0} digits that are bigger than the least significant digit.
The smallest digit in the integer you entered is {1}.
The number of digits which are a multiple of three in the integer you entered is {2}.
The average of the digits in the number you entered is {3}."
               , numOfDigitsBiggerThanLSD
               , smallestDigit
               , numOfMultiplesOfThree
               , averageOfDigits);

            Console.WriteLine(statisticsMessage);
            Console.WriteLine("Please press 'Enter' to exit...");
            Console.ReadLine();
        }

        private static void setToValidInput(out string o_CurrentInput, out int o_VaildInteger)
        {
            o_CurrentInput = Console.ReadLine();
            while (!isValidInput(o_CurrentInput, out o_VaildInteger))
            {
                Console.WriteLine("The input you entered is invalid. Please try again.");
                o_CurrentInput = Console.ReadLine();
            }
        }

        private static bool isValidInput(string i_CurrentInput, out int o_ValidInteger)
        {
            bool isValid = false;
            if (int.TryParse(i_CurrentInput, out o_ValidInteger) && (i_CurrentInput.Length == 7 || i_CurrentInput.Length == 6))
            {
                isValid = true;    
            }

            return isValid;
        }

        private static int getNumOfLeadingZeros(string i_inputString)
        {
            int i = 0, numOfLeadingZeros = 0;
            if (!char.IsDigit(i_inputString[i]))
            {
                i++;
            }

            while (i < i_inputString.Length && i_inputString[i] == '0')
            {
                numOfLeadingZeros++;
                i++;
            }

            return numOfLeadingZeros;
        }

        private static int getNumOfDigitsBiggerThanLSD(int i_InputNumber)
        {
            int numOfDigitsBiggerThanLSD = 0;
            int inputNumberAbsVal = Math.Abs(i_InputNumber);
            int leastSignificantDigit = inputNumberAbsVal % 10;
            
            inputNumberAbsVal /= 10;
            while (inputNumberAbsVal > 0)
            {
                int currentDigit = inputNumberAbsVal % 10;

                if (currentDigit > leastSignificantDigit)
                {
                    numOfDigitsBiggerThanLSD++;
                }

                inputNumberAbsVal /= 10;
            }

            return numOfDigitsBiggerThanLSD;
        }

        private static int getSmallestDigit(string i_InputString)
        {
            int smallestDigit; 

            if(getNumOfLeadingZeros(i_InputString) > 0)
            {
                smallestDigit = 0;
            }
            else
            {   
                int inputNumberAbsVal = Math.Abs(int.Parse(i_InputString));

                smallestDigit = inputNumberAbsVal % 10;
                inputNumberAbsVal /= 10;
                while (inputNumberAbsVal > 0)
                {
                    int currentDigit = inputNumberAbsVal % 10;

                    if (currentDigit < smallestDigit)
                    {
                        smallestDigit = currentDigit;
                    }

                    inputNumberAbsVal /= 10;
                }
            }
            
            return smallestDigit;
        }

        private static int getNumOfMultiplesOfThree(string i_InputString)
        {
            int numOfMultiplesOfThree = 0;
            int numOfLeadingZeros = getNumOfLeadingZeros(i_InputString);
            int inputNumber = int.Parse(i_InputString);

                while (inputNumber != 0) 
                {
                    int currentDigit = inputNumber % 10;
                    if (currentDigit % 3 == 0)
                    {
                        numOfMultiplesOfThree++;
                    }

                    inputNumber /= 10;
                }
           
           return numOfMultiplesOfThree + numOfLeadingZeros;
        }

        private static float getAverageOfDigits(int i_InputNumber, int i_NumOfDigits = 6)
        {
            int sumOfDigits = 0;
            int inputNumberAbsVal = Math.Abs(i_InputNumber);

            while (inputNumberAbsVal > 0)
            {
                sumOfDigits += (inputNumberAbsVal % 10);
                inputNumberAbsVal /= 10;
            }

            return (float)sumOfDigits / i_NumOfDigits; 
        }
    }
}
