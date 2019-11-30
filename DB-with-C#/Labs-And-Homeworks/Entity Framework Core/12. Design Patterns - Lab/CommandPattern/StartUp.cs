namespace CommandPattern
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var modifyPrice = new ModifyPrice();
            var product = new Product("Phone", 500);

            List<ICommand> operations = new List<ICommand>()
            {
                new ProductCommand(product, PriceAction.Increase, 100),
                new ProductCommand(product, PriceAction.Increase, 50),
                new ProductCommand(product, PriceAction.Decrease, 25)
            };

            Execute(product, modifyPrice, operations[0]);

            Execute(product, modifyPrice, operations[1]);

            Execute(product, modifyPrice, operations[2]);

            Console.WriteLine(product);
        }

        private static void Execute(Product product, ModifyPrice modifyPrice, ICommand productCommand)
        {
            modifyPrice.SetCommand(productCommand);
            modifyPrice.Invoke();
        }
    }
}
