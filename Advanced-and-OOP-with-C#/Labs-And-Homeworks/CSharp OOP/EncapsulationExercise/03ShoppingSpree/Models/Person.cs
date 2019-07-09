﻿using System;
using System.Collections.Generic;
using System.Text;

using ShoppingSpree.Exceptions;

namespace ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private decimal money;
        private readonly List<Product> bagOfProducts;

        public Person()
        {
            this.bagOfProducts = new List<Product>();
        }

        public Person(string name, decimal money)
            :this()
        {
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmptyNameException);
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.NegativeMoneyException);
                }

                this.money = value;
            }
        }

        public void BuyProduct(Product product)
        {
            decimal moneyLeft = this.Money - product.Cost;

            if (moneyLeft < 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CannotAffordAProductException,
                    this.Name, product.Name));
            }

            this.Money = moneyLeft;
            this.bagOfProducts.Add(product);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (this.bagOfProducts.Count == 0)
            {
                sb.AppendLine($"{this.Name} - Nothing bought");
            }
            else
            {
                sb.AppendLine($"{this.Name} - {string.Join(", ", this.bagOfProducts)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}