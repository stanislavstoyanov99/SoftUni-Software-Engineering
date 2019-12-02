namespace Cinema.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    [XmlType("Customer")]
    public class ImportCustomersDto
    {
        [XmlElement(ElementName = "FirstName")]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "LastName")]
        public string LastName { get; set; }

        [XmlElement(ElementName = "Age")]
        public int Age { get; set; }

        [XmlElement(ElementName = "Balance")]
        public decimal Balance { get; set; }

        [XmlArray("Tickets")]
        public ImportTicketsDto[] Tickets { get; set; }
    }
}
