namespace P01_HospitalDatabase
{
    using Microsoft.EntityFrameworkCore;

    using P01_HospitalDatabase.Data;
    using P01_HospitalDatabase.Data.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var db = new HospitalContext();

            db.Database.Migrate();

            Patient[] patients = new Patient[]
            {
                new Patient
                {
                    FirstName = "Kiril",
                    LastName = "Petrov",
                    Address = "Sofia town",
                    Email = "kiril77@gmail.com",
                    HasInsurance = true
                },
                new Patient
                {
                    FirstName = "Stanislav",
                    LastName = "Stoyanov",
                    Address = "Pernik town",
                    Email = "slavi_biserov@mail.bg",
                    HasInsurance = false
                },
                new Patient
                {
                    FirstName = "Stamat",
                    LastName = "Stamatov",
                    Address = "Plovdiv town",
                    Email = "stamat_stamatov@mail.bg",
                    HasInsurance = true
                }
            };

            db.Patients.AddRange(patients);

            db.SaveChanges();
        }
    }
}
