using System.Linq;
using System;

using NUnit.Framework;
using INStock.Contracts;
using INStock.Models;

namespace INStock.Tests
{
    [TestFixture]
    public class ProductStockTests
    {
        private IProductStock productStock;

        [SetUp]
        public void Create_Test_Objects()
        {
            this.productStock = new ProductStock();

            this.productStock.Add(new Product()
            {
                Label = "MyProduct",
                Quantity = 1,
                Price = 100m
            });
        }

        [TearDown]
        public void Destroy_Objects()
        {
            this.productStock = null;
        }

        [Test]
        public void Duplicate_Label_After_Adding_NewProduct()
        {
            int countBeforeAdd = this.productStock.Count;

            this.productStock.Add(new Product() { Label = "MyProduct", Price = 100m });

            Assert.That(this.productStock.Count == countBeforeAdd);
        }

        [Test]
        public void Product_Quantity_Increased_When_Product_Is_Added()
        {
            int quantityBefore = this.productStock
                .First()
                .Quantity;

            this.productStock.Add(new Product()
            {
                Label = "MyProduct",
                Quantity = 5,
                Price = 100m
            });

            Assert.That(productStock.First().Quantity == 6);
        }

        [Test]
        public void Price_Preserved_After_New_Product_Is_Added()
        {
            Product product = new Product()
            {
                Label = "MyProduct",
                Price = 5.9m
            };

            Assert.That(() => this.productStock.Add(product), Throws.ArgumentException);
        }

        [Test]
        public void Check_If_Contains_Works_Correctly()
        {
            Product product = new Product()
            {
                Label = "MyProduct",
                Price = 5.9m
            };

            Assert.That(this.productStock.Contains(product));
        }

        [Test]
        public void Check_If_Contains_Does_Not_Work_Correctly()
        {
            Product product = new Product()
            {
                Label = "MyProduct",
                Price = 5.9m
            };

            Assert.That(!this.productStock.Contains(product));
        }

        [Test]
        public void Finds_Nth_Product_In_Stock()
        {
            Product product = new Product()
            {
                Label = "Product",
                Quantity = 5,
                Price = 100m
            };

            this.productStock.Add(product);
            var foundProduct = this.productStock.Find(2);

            Assert.That(foundProduct.Label, Is.EqualTo(product.Label));
        }

        [Test]
        public void Error_If_Product_Index_Is_Not_Valid()
        {
            Assert.Throws<IndexOutOfRangeException>(() => this.productStock.Find(8));
        }

        [Test]
        public void Product_Found_By_Label()
        {
            IProduct product = productStock.FindByLabel("MyProduct");

            Assert.AreEqual(product, this.productStock.First());
        }

        [Test]
        public void Error_If_Label_Not_Found()
        {
            Assert.Throws<ArgumentException>(() => this.productStock.FindByLabel("Pesho"));
        }

        [Test]
        public void Empty_List_If_Not_Found()
        {
            var products = this.productStock.FindAllInPriceRange(1.0m, 2.0m);

            Assert.That(products.Count() == 0);
        }
    }
}
