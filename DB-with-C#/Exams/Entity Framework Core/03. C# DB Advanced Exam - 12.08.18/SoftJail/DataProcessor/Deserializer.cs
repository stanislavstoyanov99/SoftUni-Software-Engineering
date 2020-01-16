namespace SoftJail.DataProcessor
{

    using System;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    using Data;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage
            = "Invalid Data";

        private const string SuccessfullyImportedDepartmentAndCell
            = "Imported {0} with {1} cells";

        private const string SuccessfullyImportedPrisoner
            = "Imported {0} {1} years old";

        private const string SuccessfullyImportedOfficersPrisoners
            = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentsCellsDto = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            foreach (var departmentCellDto in departmentsCellsDto)
            {
                bool isDepartmentCellDtoValid = IsValid(departmentCellDto);
                bool areCellsValid = departmentCellDto.Cells
                    .All(c => IsValid(c));

                if (isDepartmentCellDtoValid == false || areCellsValid == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var cells = new List<Cell>();

                foreach (var cellDto in departmentCellDto.Cells)
                {
                    var cell = new Cell
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    };

                    cells.Add(cell);
                }

                var department = new Department
                {
                    Name = departmentCellDto.Name,
                    Cells = cells
                };

                context.Departments.Add(department);

                sb.AppendLine(String.Format(SuccessfullyImportedDepartmentAndCell,
                    department.Name,
                    department.Cells.Count));
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersMailsDto = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            foreach (var prisonerMailDto in prisonersMailsDto)
            {
                bool isPrisonerDtoValid = IsValid(prisonerMailDto);
                bool areMailsValid = prisonerMailDto.Mails
                    .All(m => IsValid(m));

                if (isPrisonerDtoValid == false || areMailsValid == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var mails = new List<Mail>();

                foreach (var mailDto in prisonerMailDto.Mails)
                {
                    var mail = new Mail
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address
                    };

                    mails.Add(mail);
                }

                var prisoner = new Prisoner
                {
                    FullName = prisonerMailDto.FullName,
                    Nickname = prisonerMailDto.Nickname,
                    Age = prisonerMailDto.Age,
                    IncarcerationDate = DateTime.ParseExact(prisonerMailDto.IncarcerationDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture),
                    Bail = prisonerMailDto.Bail,
                    CellId = prisonerMailDto.CellId,
                    Mails = mails
                };

                if (prisonerMailDto.ReleaseDate == null)
                {
                    prisoner.ReleaseDate = null;
                }
                else
                {
                    prisoner.ReleaseDate = DateTime.ParseExact(prisonerMailDto.ReleaseDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture);
                }

                context.Prisoners.Add(prisoner);

                sb.AppendLine(String.Format(SuccessfullyImportedPrisoner,
                    prisoner.FullName,
                    prisoner.Age));
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var rootAttribute = new XmlRootAttribute("Officers");
            var xmlSerializer = new XmlSerializer(typeof(ImportOfficerDto[]), rootAttribute);

            using var stringReader = new StringReader(xmlString);

            var officerPrisonersDto = (ImportOfficerDto[])xmlSerializer.Deserialize(stringReader);

            StringBuilder sb = new StringBuilder();

            foreach (var officerPrisonerDto in officerPrisonersDto)
            {
                bool isWeaponValid = Enum.IsDefined(typeof(Weapon), officerPrisonerDto.Weapon);
                bool isPositionValid = Enum.IsDefined(typeof(Position), officerPrisonerDto.Position);
                bool isOfficerPrisonerDtoValid = IsValid(officerPrisonerDto);

                if (isWeaponValid == false ||
                    isPositionValid == false ||
                    isOfficerPrisonerDtoValid == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var officer = new Officer
                {
                    FullName = officerPrisonerDto.Name,
                    Salary = officerPrisonerDto.Money,
                    Position = Enum.Parse<Position>(officerPrisonerDto.Position),
                    Weapon = Enum.Parse<Weapon>(officerPrisonerDto.Weapon),
                    DepartmentId = officerPrisonerDto.DepartmentId
                };

                var officerPrisoners = new List<OfficerPrisoner>();

                for (int i = 0; i < officerPrisonerDto.Prisoners.Length; i++)
                {
                    officerPrisoners.Add(new OfficerPrisoner
                    {
                        PrisonerId = officerPrisonerDto.Prisoners[i].Id
                    });
                }

                officer.OfficerPrisoners = officerPrisoners;

                context.Officers.Add(officer);

                sb.AppendLine(String.Format(SuccessfullyImportedOfficersPrisoners,
                    officer.FullName,
                    officer.OfficerPrisoners.Count));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(Object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool result = Validator.TryValidateObject(obj, validationContext, validationResult, true);

            return result;
        }
    }
}