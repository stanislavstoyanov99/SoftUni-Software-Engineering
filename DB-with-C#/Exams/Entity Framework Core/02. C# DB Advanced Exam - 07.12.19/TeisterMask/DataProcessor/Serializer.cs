namespace TeisterMask.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Globalization;
    using System.Xml.Serialization;

    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    using Data;
    using TeisterMask.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .Where(e => e.EmployeesTasks
                    .Any(e => e.Task.OpenDate.Date >= date))
                .Select(e => new ExportEmployeeDto
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                        .Where(e => e.Task.OpenDate.Date >= date)
                        .OrderByDescending(e => e.Task.DueDate.Date)
                        .ThenBy(e => e.Task.Name)
                        .Select(et => new ExportTaskDto
                        {
                            TaskName = et.Task.Name,
                            OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = et.Task.LabelType.ToString(),
                            ExecutionType = et.Task.ExecutionType.ToString()
                        })
                        .ToArray()
                })
                .ToArray()
                .OrderByDescending(e => e.Tasks.Length)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();

            string jsonExport = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return jsonExport;
        }

        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projectsWithTheirTasks = context.Projects
                .Where(p => p.Tasks.Any())
                .OrderByDescending(p => p.Tasks.Count)
                .ThenBy(p => p.Name)
                .Select(p => new ExportProjectDto
                {
                    TasksCount = p.Tasks.Count,
                    ProjectName = p.Name,
                    HasEndDate = HasProjectEndDate(p.DueDate),
                    Tasks = p.Tasks
                        .Select(t => new ExportProjectTaskDto
                        {
                            Name = t.Name,
                            Label = t.LabelType.ToString()
                        })
                        .OrderBy(t => t.Name)
                        .ToArray()
                })
                .ToArray();

            var rootAttribute = new XmlRootAttribute("Projects");
            var xmlSerializer = new XmlSerializer(typeof(ExportProjectDto[]), rootAttribute);

            StringBuilder sb = new StringBuilder();

            using var stringWriter = new StringWriter(sb);

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(stringWriter, projectsWithTheirTasks, namespaces);

            return sb.ToString().TrimEnd();
        }

        private static string HasProjectEndDate(DateTime? dueDate)
        {
            if (dueDate == null)
            {
                return "No";
            }
            else
            {
                return "Yes";
            }
        }
    }
}