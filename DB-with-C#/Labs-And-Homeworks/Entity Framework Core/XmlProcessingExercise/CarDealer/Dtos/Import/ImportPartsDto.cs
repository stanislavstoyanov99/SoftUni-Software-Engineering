namespace CarDealer.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("partId")]
    public class ImportPartsDto
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
    }
}
