namespace P01_HospitalDatabase
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    using P01_HospitalDatabase.Data;
    using P01_HospitalDatabase.Data.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var db = new HospitalContext();

            db.Database.Migrate();

            Patient patient = new Patient
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Address = "Radomir town",
                Email = "slavkata_99@abv.bg",
                HasInsurance = true
            };

            db.Patients.Add(patient);

            db.SaveChanges();

            var patients = db.Patients
                .ToList();

            foreach (var pa in patients)
            {
                Console.WriteLine(pa.FirstName + " " + pa.LastName + " " + pa.Email);
            }
        }
    }
}
