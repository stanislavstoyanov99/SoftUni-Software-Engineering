namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    public class UsersOutputDto
    {
        [XmlElement(ElementName = "count")]
        public int Count { get; set; }

        [XmlArray(ElementName = "users")]
        public UserInfoDto[] Users { get; set; }
    }
}
