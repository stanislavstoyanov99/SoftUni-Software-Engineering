namespace HotelReservation
{
    public static class PriceCalculator
    {
        public static decimal GetTotalPrice(decimal pricePerDay, int numberOfDays, Season season, DiscountType discount)
        {
            switch (season)
            {
                case Season.Autumn:
                    pricePerDay *= 1;
                    break;
                case Season.Spring:
                    pricePerDay *= 2;
                    break;
                case Season.Winter:
                    pricePerDay *= 3;
                    break;
                case Season.Summer:
                    pricePerDay *= 4;
                    break;
            }

            decimal totalPrice = pricePerDay * numberOfDays;

            switch (discount)
            {
                case DiscountType.VIP:
                    totalPrice = totalPrice * 0.80m;
                    break;
                case DiscountType.SecondVisit:
                    totalPrice = totalPrice * 0.90m;
                    break;
                case DiscountType.None:
                    totalPrice += default(decimal);
                    break;
            }

            return totalPrice;
        }
    }
}
