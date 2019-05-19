using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalMoney = default(double);
            double priceOfProduct = default(double);
            double currentMoney = default(double);

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Start")
                {
                    while (true)
                    {
                        string product = Console.ReadLine().ToLower();
                        if (product == "end")
                        {
                            Console.WriteLine($"Change: {totalMoney:F2}");
                            return;
                        }

                        switch (product)
                        {
                            case "nuts":
                                priceOfProduct = 2.0;
                                break;
                            case "water":
                                priceOfProduct = 0.7;
                                break;
                            case "crisps":
                                priceOfProduct = 1.5;
                                break;
                            case "soda":
                                priceOfProduct = 0.8;
                                break;
                            case "coke":
                                priceOfProduct = 1.0;
                                break;
                            default: Console.WriteLine("Invalid product"); continue;
                        }

                        if (totalMoney >= priceOfProduct && priceOfProduct > 0)
                        {
                            Console.WriteLine($"Purchased {product}");
                            totalMoney -= priceOfProduct;
                        }
                        else if (priceOfProduct > totalMoney)
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                    }
                }

                currentMoney = double.Parse(command);
                if (currentMoney != 0.1 && currentMoney != 0.2 && currentMoney != 0.5 && currentMoney != 1 && currentMoney != 2)
                {
                    Console.WriteLine($"Cannot accept {currentMoney}");
                }
                else
                {
                    totalMoney += currentMoney;
                }
            }

            //Second way for solution
            //string input = Console.ReadLine();

            //double balance = 0;
            //while (input != "Start")
            //{
            //    double coin = double.Parse(input);

            //    if (coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2)
            //    {
            //        balance += coin;
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Cannot accept {coin}");
            //    }

            //    input = Console.ReadLine();
            //}

            //input = Console.ReadLine();
            //while (input != "End")
            //{
            //    double productPrice = 0;

            //    switch (input)
            //    {
            //        case "Nuts":
            //            productPrice = 2;
            //            break;
            //        case "Water":
            //            productPrice = 0.7;
            //            break;
            //        case "Crisps":
            //            productPrice = 1.5;
            //            break;
            //        case "Soda":
            //            productPrice = 0.8;
            //            break;
            //        case "Coke":
            //            productPrice = 1;
            //            break;
            //        default:
            //            Console.WriteLine("Invalid product");
            //            break;
            //    }
            //    if (balance >= productPrice && productPrice > 0)
            //    {
            //        string productToLower = input.ToLower();
            //        Console.WriteLine($"Purchased {productToLower}");
            //        balance -= productPrice;
            //    }
            //    else if (productPrice > 0)
            //    {
            //        Console.WriteLine("Sorry, not enough money");
            //    }

            //    input = Console.ReadLine();
            //}

            //Console.WriteLine($"Change: {balance:F2}");
        }
    }
}
