﻿namespace CarDealer.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "parts")]
    public class ImportParts
    {
        [XmlElement(ElementName = "partId")]
        public ImportPartsId[] PartsId { get; set; }
    }
}
