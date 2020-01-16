namespace Cinema.DataProcessor.ExportDto
{
    public class ExportMoviesDto
    {
        public string MovieName { get; set; }

        public string Rating { get; set; }

        public string TotalIncomes { get; set; }

        public ExportCustomersDto[] Customers { get; set; }
    }
}
