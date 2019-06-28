using System;

namespace DefiningClasses
{
    public class DateModifier
    {
        private DateTime startDate;
        private DateTime endDate;

        public int GetDifference(string firstDate, string secondDate)
        {
            this.startDate = DateTime.Parse(firstDate);
            this.endDate = DateTime.Parse(secondDate);

            int resultDate = (int)((this.startDate - this.endDate).TotalDays);
            return Math.Abs(resultDate);
        }
    }
}
