using System;

class Program
{
    static void Main(string[] args)
    {
        int energy = 100;
        int coins = 100;
        string[] workingDayEvents = Console.ReadLine().Split('|');

        foreach (var day in workingDayEvents)  //обхождаме всеки ден от workingDayEvents
        {
            string[] tokens = day.Split('-');  //сплитваме (евента или продукта) и стойността от стринга с -
            string content = tokens[0];        //евента за деня или съставката която трябва да се купи
            int value = int.Parse(tokens[1]);  //стойността на евента или продукта
            string message = string.Empty;     //съобщението което ще принтираме след всяка итерация 

            switch (content)
            {
                case "rest":
                    int gainedEnergy = Math.Min(value, 100 - energy); //изчисляваме колко енергия ще получим така че да не превишим 100
                    energy += gainedEnergy; //добавяме към нашата енергия изчислената gainedEnergy
                    message = $"You gained {gainedEnergy} energy.\nCurrent energy: {energy}."; //задаваме стойност на съобщението ни
                    break;
                case "order":
                    if (energy - 30 < 0)                        //ако след опит за поръчка енергията ни падне под 0
                    {
                        energy += 50;                           //добавяме 50 енергия
                        message = "You had to rest!";           //задаваме стойност на съобщението ни
                    }
                    else                                        //ако можем да изпълним поръчката
                    {
                        energy -= 30;                           //вадим 30 от енергията
                        coins += value;                         //добавяме парите
                        message = $"You earned {value} coins."; //задаваме стойност на съобщението ни
                    }
                    break;
                default:                                      //ако трябва да купуваме продукт
                    coins -= value;                           //изваждаме от парите ни цената на продукта

                    if (coins > 0)                            //ако не сме банкрутирали           
                    {
                        message = $"You bought {content}.";   //задаваме стойност на съобщението ни
                    }
                    else                                      //банкрутирали сме
                    {
                        message = $"Closed! Cannot afford {content}."; //задаваме стойност на съобщението ни
                    }
                    break;
            }

            Console.WriteLine(message); //принтираме настоящото съобщение

            if (coins <= 0)        //при банкрут прекратяваме итерирането по масива
            {
                break;
            }
        }

        if (coins > 0)             //ако не сме банкрутирали
        {
            Console.WriteLine($"Day completed!\nCoins: {coins}\nEnergy: {energy}");
        }
    }
}
