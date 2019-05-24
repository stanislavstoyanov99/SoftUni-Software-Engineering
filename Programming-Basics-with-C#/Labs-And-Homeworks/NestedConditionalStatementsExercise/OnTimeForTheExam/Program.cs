using System;

class Program
{
    static void Main(string[] args)
    {
        int hourOfTheExam = int.Parse(Console.ReadLine());
        int minuteOfTheExam = int.Parse(Console.ReadLine());

        int hourOfTheArrival = int.Parse(Console.ReadLine());
        int minuteOfTheArrival = int.Parse(Console.ReadLine());

        TimeSpan examTime = new TimeSpan(hourOfTheExam, minuteOfTheExam, 0);
        TimeSpan studentTime = new TimeSpan(hourOfTheArrival, minuteOfTheArrival, 0);

        string result = string.Empty;

        if (examTime == studentTime)
        {
            result = "On time";
        }
        else if (examTime > studentTime && (examTime - studentTime).Minutes <= 30 && (examTime - studentTime).Hours == 0)
        {
            result = $"On time" + Environment.NewLine + $"{(examTime - studentTime).Minutes} minutes before the start";
        }
        else if (examTime > studentTime && (examTime - studentTime).Minutes > 30 || (examTime - studentTime).Hours != 0)
        {
            if ((examTime - studentTime).Hours != 0)
            {
                result = "Early" + Environment.NewLine + $"{(examTime - studentTime).Hours} : {(examTime - studentTime).Minutes} hours before the start";
            }
            else
            {
                result = "Early" + Environment.NewLine + $"{(examTime - studentTime).Minutes} minutes before the start.";
            }
        }
        else
        {
            if ((studentTime - examTime).Hours != 0)
            {
                result = "Late" + Environment.NewLine + $"{(studentTime - examTime).Hours} : {(examTime - studentTime).Minutes} hours after the start";
            }
            else
            {
                result = "Late" + Environment.NewLine + $"{(studentTime - examTime).Minutes} minutes after the start";
            }
        }
        Console.WriteLine(result);
    }
}

