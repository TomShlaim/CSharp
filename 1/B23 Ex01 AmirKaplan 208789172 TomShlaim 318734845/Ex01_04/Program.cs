using System;
using System.Text;

namespace Ex01_04
{
	public class Program
	{
        public static void Main()
        {
            diagnoseString();
            Console.WriteLine("Please press 'Enter' to exit...");
            Console.ReadLine();
        }
        private static void diagnoseString()
        {
            bool isGoodInput = false;

            while (!isGoodInput)
            {
                Console.WriteLine("Please enter a 6 characters string:");
                string inputString = Console.ReadLine();

                isGoodInput = validateInputString(inputString, 6);

                if (isGoodInput)
                {
                    string isPalindromeMessage = isPalindrome(inputString) ?
                        "The input string is a palindrome!" :
                        "The input string is not a palindrome!";

                    Console.WriteLine(isPalindromeMessage);

                    if (isStringConsistedOfEnglishLetters(inputString))
                    {
                        int numberOfUpperCaseLettersInString = getNumberOfUpperCaseLettersInString(inputString);

                        Console.WriteLine(string.Format("The input string consisted of {0} upper case english letters!", numberOfUpperCaseLettersInString));
                    }
                    else
                    {
                        int inputNumber = int.Parse(inputString);
                        string isMultipleOfThreeMessage = isMultipleOfThree(inputNumber) ?
                            "The input number is a multiple of 3!" :
                            "The input number is not a multiple of 3!";

                        Console.WriteLine(isMultipleOfThreeMessage);
                    }
                }
                else
                {
                    Console.WriteLine("Please try again!");
                }
            }
        }
        private static bool validateInputString(string i_InputString, int i_ValidStringLength)
        {
            bool isValidString = true;
            StringBuilder inputErrors = new StringBuilder();

            if (i_InputString.Length != i_ValidStringLength)
            {
                isValidString = false;
                inputErrors.AppendLine("Input string should be of size 6!");
            }
            else {
                if(!isStringConsistedOfEnglishLetters(i_InputString) && !isStringANumber(i_InputString))
                {
                    isValidString = false;
                    inputErrors.AppendLine("Input string must be consisted of digits only or english letters only!");
                }
            }

            if (!isValidString)
            {
                Console.Write(inputErrors);
            }

            return isValidString;
        }
        private static bool isStringConsistedOfEnglishLetters (string i_InputString)
        {
            bool isStringConsistedOfEnglishLettersOnly = true;

            for (int i = 0; i < i_InputString.Length; i++)
            {
                char inputStringCharacter = i_InputString[i];

                if (!isCharAnEnglishLetter(inputStringCharacter))
                {
                    isStringConsistedOfEnglishLettersOnly = false;
                    break;
                }
            }

            return isStringConsistedOfEnglishLettersOnly;

        }
        private static bool isStringANumber(string i_InputString)
        {
            int inputNumber = 0;
            return int.TryParse(i_InputString, out inputNumber);

        }
        private static bool isCharAnEnglishLetter(char i_Character)
        {
            bool isEnglishLetter = true;

            if (!((i_Character >= 'A' && i_Character <= 'Z') || (i_Character >= 'a' && i_Character <= 'z')))
            {
                isEnglishLetter = false;
            }

            return isEnglishLetter;
        }
       
        private static bool isPalindrome(string i_InputString)
        {
            bool inputIsPalindrome = true;

            if (!string.IsNullOrEmpty(i_InputString) && i_InputString.Length > 1)
            {
                if (i_InputString[0] != i_InputString[i_InputString.Length - 1])
                {
                    inputIsPalindrome = false;
                }
                else
                {
                    inputIsPalindrome = isPalindrome(i_InputString.Substring(1, i_InputString.Length - 2));
                }
            }

            return inputIsPalindrome;
        }

        private static bool isMultipleOfThree(int i_DecimalNumber)
        {
            return i_DecimalNumber % 3 == 0;
        }
        private static int getNumberOfUpperCaseLettersInString(string i_InputString)
        {
            int numberOfUpperCaseLettersInString = 0;

            for (int i = 0; i < i_InputString.Length; i++)
            {
                char letter = i_InputString[i];
                if (char.IsUpper(letter))
                {
                    numberOfUpperCaseLettersInString++;
                }
            }

            return numberOfUpperCaseLettersInString;
        }
    }
}

