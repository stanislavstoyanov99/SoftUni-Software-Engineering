using System;

namespace RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            // броячи
            int keyboardTrashedCount = 0;
            int displayTrashedCount = 0;
            int headsetTrashedCount = 0;
            int mouseTrashedCount = 0;

            for (int game = 1; game <= lostGames; game++)
            {
                if (game % 2 == 0)
                {
                    headsetTrashedCount++; // броя счупени headset
                }
                if (game % 3 == 0)
                {
                    mouseTrashedCount++; // броя счупени мишки
                }
                if (game % 2 == 0 && game % 3 == 0)
                {
                    keyboardTrashedCount++; // броя счупени клавиатури
                    if (keyboardTrashedCount % 2 == 0)
                    {
                        displayTrashedCount++; // ако са счупени 2 клавиатури, то е счупен и дисплей
                    }
                }
            }
            double totalPrice = headsetPrice * headsetTrashedCount + mousePrice * mouseTrashedCount + keyboardPrice * keyboardTrashedCount + displayPrice * displayTrashedCount;

            Console.WriteLine($"Rage expenses: {totalPrice:F2} lv.");
        }
    }
}
