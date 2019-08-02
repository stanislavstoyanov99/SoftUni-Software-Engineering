using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using INStock.Contracts;

namespace INStock.Models
{
    public class ProductStock : IProductStock
    {
        private List<IProduct> products;

        public ProductStock()
        {
            this.products = new List<IProduct>();
        }

        public IProduct this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => this.products.Count;

        public void Add(IProduct product)
        {
            Product existingProduct = (Product)products
                .FirstOrDefault(p => p.Label == product.Label);

            if (existingProduct == null)
            {
                products.Add(product);
            }
            else
            {
                if (existingProduct.Price != product.Price)
                {
                    throw new ArgumentException();
                }

                existingProduct.Quantity += product.Quantity;
            }
        }

        public bool Contains(IProduct product)
        {
            return this.products.Any(p => p.Label == product.Label);
        }

        public IProduct Find(int index)
        {
            try
            {
                return this.products[index - 1];
            }
            catch (ArgumentOutOfRangeException ae)
            {

                throw new IndexOutOfRangeException(ae.Message, ae);
            }
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllInPriceRange(decimal lo, decimal hi)
        {
            return products.Where(p => p.Price > lo && p.Price < hi)
                .ToList();
        }

        public IProduct FindByLabel(string label)
        {
            IProduct foundProduct = this.products
                .FirstOrDefault(p => p.Label == label);

            if (foundProduct == null)
            {
                throw new ArgumentException();
            }

            return foundProduct;
        }

        public IProduct FindMostExpensiveProduct()
        {
            throw new NotImplementedException();
        }

        public bool Remove(IProduct product)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            return this.products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.products.GetEnumerator();
        }
    }
}
