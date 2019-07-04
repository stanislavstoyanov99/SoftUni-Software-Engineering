﻿namespace Restaurant.Food.MainDishes
{
    public class Fish : MainDish
    {
        private const int grams = 22;

        public Fish(string name, decimal price) 
            : base(name, price, grams)
        {

        }
    }
}
