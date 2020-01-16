﻿namespace SoftJail.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Prisoner")]
    public class ExportPrisonerInfoDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string IncarcerationDate { get; set; }

        [XmlArray("EncryptedMessages")]
        public ExportEncryptedMessageDto[] EncryptedMessages { get; set; }
    }
}
