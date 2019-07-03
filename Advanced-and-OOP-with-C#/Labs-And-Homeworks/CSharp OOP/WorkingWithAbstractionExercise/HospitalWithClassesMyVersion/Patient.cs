namespace P04_Hospital_WithClasses
{
    public class Patient
    {
        public Patient(string patientName)
        {
            this.Name = patientName;
        }

        public string Name { get; set; }
    }
}
