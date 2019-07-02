using System;

namespace HotelReservation
{
    public class Engine
    {
        private string[] information;

        public Engine()
        {
            this.information = new string[] { };
        }

        public void Start()
        {
            information = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            decimal pricePerDay = decimal.Parse(information[0]);
            int numberOfDays = int.Parse(information[1]);
            string season = information[2];

            Season seasonEnum = Enum.Parse<Season>(season, true);
            DiscountType discountEnum = DiscountType.None;

            if (information.Length == 4)
            {
                string discount = information[3];
                discountEnum = Enum.Parse<DiscountType>(discount, true);
            }

            decimal totalPrice = PriceCalculator.GetTotalPrice(pricePerDay, numberOfDays, seasonEnum, discountEnum);

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
