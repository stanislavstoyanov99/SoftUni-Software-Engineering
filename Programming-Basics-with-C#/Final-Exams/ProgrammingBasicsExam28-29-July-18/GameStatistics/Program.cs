using System;

namespace GameStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutes = int.Parse(Console.ReadLine()); //Минути
            string playerName = Console.ReadLine(); //Име на играча

            if (minutes == 0) //Проста проверка, ако минутите са 0
            {
                Console.WriteLine("Match has just began!");
            }

            else if (minutes < 45) //Сложна проверка, ако минутите са по-малки от 45
            {
                Console.WriteLine("First half time."); //Изходен резултат на първия ред

                if (minutes > 1 && minutes <= 10) //Вписана проверка, ако минутите са по-малки от 1 и по-малки или равни от 10
                {
                    Console.WriteLine($"{playerName} missed a penalty."); //Изходен резултат от проверката

                    if (minutes % 2 == 0) //Отново вписана проверка, ако е изпълнена горната и минутите са четни
                    {
                        Console.WriteLine($"{playerName} was injured after the penalty."); //Изходен резултат
                    }
                }

                else if (minutes > 10 && minutes <= 35) //Втора вписана проверка, ако минутите са по-малки от 10 и по-малки или равни от 35
                {
                    Console.WriteLine($"{playerName} received yellow card."); //Изходен резултат от проверката

                    if (minutes % 2 != 0) //Отново вписана проверка, ако е изпълнена горната и минутите са нечетни
                    {
                        Console.WriteLine($"{playerName} got another yellow card."); //Изходен резултат
                    }
                }

                else if (minutes > 35 && minutes < 45) //Трета вписана проверка, ако минутите са по-малки от 35 и по-малки от 45
                {
                    Console.WriteLine($"{playerName} SCORED A GOAL !!!"); //Изходен резултат от тази проверка
                }
            }

            else if (minutes >= 45) //Сложна проверка, ако минутите са по-големи или равни на 45
            {
                Console.WriteLine("Second half time."); //Изходен резултат на първия ред

                if (minutes > 45 && minutes <= 55) //Първа вписана проверка, ако минутите са по-малки от 45 и са по-малки или равни на 55
                {
                    Console.WriteLine($"{playerName} got a freekick."); //Резултат от горната проверка

                    if (minutes % 2 == 0) //Втора вписана проверка, ако минутите са четни
                    {
                        Console.WriteLine($"{playerName} missed the freekick."); //Изходен резултат
                    }
                }

                else if (minutes > 55 && minutes <= 80) //Трета вписана проверка, ако минутите са по-големи от 55 и по-малки или равни на 80
                {
                    Console.WriteLine($"{playerName} missed a shot from corner."); //Изходен резултат от тази проверка

                    if (minutes % 2 != 0) //Отново вписана проверка, ако минутите са нечетни
                    {
                        Console.WriteLine($"{playerName} has been changed with another player."); //Изходен резултат
                    }
                }

                else if (minutes > 80 && minutes <= 90) //Последна n-вписана проверка, ако минутите са по-малки от 80 и по-малки или равни на 90 :D 
                {
                    Console.WriteLine($"{playerName} SCORED A GOAL FROM PENALTY !!!"); //Последен изходен резултат и му се видя края :D
                }
            }
            // Всички резултати ги направих със стрингова интерполация. В случая има малко вход и променливи, но заиграване с вложени проверки.
            // minutes % 2 != 0 - това е за нечетни числа, а това minutes % 2 == 0 е за четните числа
        }
    }
}
