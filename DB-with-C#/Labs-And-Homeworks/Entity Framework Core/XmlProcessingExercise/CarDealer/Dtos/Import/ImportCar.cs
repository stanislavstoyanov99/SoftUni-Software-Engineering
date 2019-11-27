namespace CarDealer.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("Car")]
    public class ImportCar
    {
        [XmlElement(ElementName = "make")]
        public string Make { get; set; }

        [XmlElement(ElementName = "model")]
        public string Model { get; set; }

        [XmlElement(ElementName = "TraveledDistance")]
        public long TravelledDistance { get; set; }

        [XmlElement(ElementName = "parts")]
        public ImportParts Parts { get; set; }
    }
}
