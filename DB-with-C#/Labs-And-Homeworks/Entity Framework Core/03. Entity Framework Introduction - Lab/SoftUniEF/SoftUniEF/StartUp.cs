namespace SoftUniEF
{
    using System;
    using System.Linq;
    using SoftUniEF.Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var db = new SoftUniContext();

            // Find vs Casual Select and Where - Comparison

            //DateTime dt1 = DateTime.Now;
            //Project project1 = db.Projects
            //    .Find(2);
            //DateTime dt2 = DateTime.Now;

            DateTime dt3 = DateTime.Now;
            string project2 = db.Projects
                .Where(p => p.ProjectId == 2)
                .Select(p => p.Name)
                .First();
            DateTime dt4 = DateTime.Now;

            Console.WriteLine($"{project2} - {(dt4 - dt3).Milliseconds}");
            //Console.WriteLine($"{project1.Name} - {(dt2 - dt1).Milliseconds}");
        }
    }
}
