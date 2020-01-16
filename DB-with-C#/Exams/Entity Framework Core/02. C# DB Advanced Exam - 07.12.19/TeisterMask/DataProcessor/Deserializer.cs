namespace TeisterMask.DataProcessor
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
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using TeisterMask.Data.Models;
    using TeisterMask.DataProcessor.ImportDto;
    using TeisterMask.Data.Models.Enums;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var rootAttribute = new XmlRootAttribute("Projects");
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectDto[]), rootAttribute);

            using var stringReader = new StringReader(xmlString);

            var projectsDto = (ImportProjectDto[])xmlSerializer.Deserialize(stringReader);

            StringBuilder sb = new StringBuilder();

            foreach (var projectDto in projectsDto)
            {
                bool isProjectDtoValid = IsValid(projectDto);

                if (isProjectDtoValid == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var project = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = DateTime.ParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                };

                if (projectDto.DueDate == null || projectDto.DueDate == "")
                {
                    project.DueDate = null;
                }
                else
                {
                    project.DueDate = DateTime.ParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                var tasks = new List<Task>();

                foreach (var taskDto in projectDto.Tasks)
                {
                    bool isTaskDtoValid = IsValid(taskDto);

                    if (isTaskDtoValid == false)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;                   
                    }

                    var task = new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = DateTime.ParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        DueDate = DateTime.ParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        ExecutionType = Enum.Parse<ExecutionType>(taskDto.ExecutionType),
                        LabelType = Enum.Parse<LabelType>(taskDto.LabelType)
                    };

                    if (project.DueDate != null)
                    {
                        if (task.OpenDate < project.OpenDate ||
                            task.DueDate > project.DueDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                    }
                    else
                    {
                        if (task.OpenDate < project.OpenDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                    }

                    tasks.Add(task);
                }

                project.Tasks = tasks;

                context.Projects.Add(project);

                sb.AppendLine(String.Format(SuccessfullyImportedProject,
                    project.Name,
                    project.Tasks.Count));

            }
            
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeesDto = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            foreach (var employeeDto in employeesDto)
            {
                bool isEmployeeDtoValid = IsValid(employeeDto);

                if (isEmployeeDtoValid == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                var employeeTasks = new List<EmployeeTask>();

                foreach (var taskId in employeeDto.Tasks.Distinct())
                {
                    var task = context.Tasks.FirstOrDefault(t => t.Id == taskId);

                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employeeTasks.Add(new EmployeeTask
                    {
                        Employee = employee,
                        TaskId = task.Id
                    });
                }

                employee.EmployeesTasks = employeeTasks;

                context.Employees.Add(employee);

                sb.AppendLine(string.Format(SuccessfullyImportedEmployee,
                    employee.Username,
                    employee.EmployeesTasks.Count));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}