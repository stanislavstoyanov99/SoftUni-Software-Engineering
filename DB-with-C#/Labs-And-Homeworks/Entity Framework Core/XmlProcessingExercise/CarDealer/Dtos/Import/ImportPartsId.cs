﻿namespace CarDealer.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "parts")]
    public class ImportPartsId
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
    }
}
