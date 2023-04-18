using System.Text;

namespace Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            printDiamond(9);
            System.Console.ReadLine();
        }
        public static void printDiamond(int i_DiamondHeight)
        {
            int initialNumberOfSpaces = 0;

            if(i_DiamondHeight % 2 == 0)
            {
                i_DiamondHeight += 1;
            }

            printUpperDiamond(i_DiamondHeight, initialNumberOfSpaces);
            if (i_DiamondHeight > 1)
            {
                printLowerDiamond(i_DiamondHeight - 2, initialNumberOfSpaces + 1);
            }
        }

        private static void printUpperDiamond(int i_DiamondHeight, int i_NumberOfSpaces)
        {
            StringBuilder diamondRow = getDiamondRow(i_DiamondHeight, i_NumberOfSpaces);

            if (i_DiamondHeight == 1)
            {
                System.Console.WriteLine(diamondRow);
                return;
            }

            printUpperDiamond(i_DiamondHeight - 2, i_NumberOfSpaces + 1);
            System.Console.WriteLine(diamondRow);
        }
        private static void printLowerDiamond(int i_DiamondHeight, int i_NumberOfSpaces)
        {
            StringBuilder diamondRow = getDiamondRow(i_DiamondHeight, i_NumberOfSpaces);

            System.Console.WriteLine(diamondRow);
            if (i_DiamondHeight == 1)
            {
                return;
            }

            printLowerDiamond(i_DiamondHeight - 2, i_NumberOfSpaces + 1);
        }
        private static StringBuilder getDiamondRow(int i_StarsCount, int i_NumberOfSpaces)
        {
            StringBuilder diamondRow = new StringBuilder();
            diamondRow.Append(new string(' ', i_NumberOfSpaces));
            diamondRow.Append(new string('*', i_StarsCount));
            diamondRow.Append(new string(' ', i_NumberOfSpaces));

            return diamondRow;
        }
    }
}
