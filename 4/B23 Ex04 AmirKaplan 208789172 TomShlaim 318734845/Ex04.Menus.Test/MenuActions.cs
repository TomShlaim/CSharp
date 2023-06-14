using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    internal class MenuActions
    {
        public static void ShowDate()
        {
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));
        }
        public static void ShowTime()
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
        }
        public static void ShowVersion()
        {
            Console.WriteLine("App Version: 23.2.4.9805");
        }
        public static void CountCapitals()
        {
            string sentence = getSentenceFromUser();

            Console.WriteLine(getSentenceCapitalLettersMessage(sentence));
        }
        private static string getSentenceFromUser()
        {
            Console.WriteLine("Please write a sentence...");
            string sentence = Console.ReadLine();

            return sentence;
        }
        private static string getSentenceCapitalLettersMessage(string i_Sentence)
        {
            int capitalsCount = i_Sentence.Count(letter => char.IsUpper(letter));
            string sentenceCapitalLettersMessage = string.Format("There are {0} capital letters in the sentence you've inserted", capitalsCount);

            return sentenceCapitalLettersMessage;
        }
    }
}
