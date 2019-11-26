
namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("SoldProducts")]
    public class SoldProductsDto
    {
        [XmlElement(ElementName = "count")]
        public int Count { get; set; }

        [XmlArray(ElementName = "products")]
        public ProductInfoDto[] Products { get; set; }
    }
}
