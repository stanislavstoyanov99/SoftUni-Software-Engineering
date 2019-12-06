namespace SoftJail.DataProcessor
{

    using System;
    using System.IO;
    using System.Xml;
    using System.Text;
    using System.Linq;
    using System.Xml.Serialization;
    using System.Globalization;

    using Newtonsoft.Json;

    using Data;
    using SoftJail.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisonersByCells = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(p => new ExportPrisonerDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                        .Select(po => new ExportOfficerDto
                        {
                            OfficerName = po.Officer.FullName,
                            Department = po.Officer.Department.Name
                        })
                        .OrderBy(po => po.OfficerName)
                        .ToArray(),
                    TotalOfficerSalary = p.PrisonerOfficers
                        .Sum(po => po.Officer.Salary)
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            string jsonExport = JsonConvert.SerializeObject(prisonersByCells, Formatting.Indented);

            return jsonExport;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var prisonersNamesArray = prisonersNames
                .Split(",")
                .ToArray();

            var prisoners = context.Prisoners
                .Where(p => prisonersNamesArray.Contains(p.FullName))
                .Select(p => new ExportPrisonerInfoDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate
                        .ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = p.Mails
                        .Select(m => new ExportEncryptedMessageDto
                        {
                            Description = ReverseDescription(m.Description)
                        })
                        .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            var rootAttribute = new XmlRootAttribute("Prisoners");
            var xmlSerializer = new XmlSerializer(typeof(ExportPrisonerInfoDto[]), rootAttribute);

            StringBuilder sb = new StringBuilder();

            using var stringWriter = new StringWriter(sb);

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(stringWriter, prisoners, namespaces);

            return sb.ToString().TrimEnd();
        }

        private static string ReverseDescription(string description)
        {
            char[] descriptionArray = description.ToCharArray();

            Array.Reverse(descriptionArray);

            return new string(descriptionArray);
        }
    }
}