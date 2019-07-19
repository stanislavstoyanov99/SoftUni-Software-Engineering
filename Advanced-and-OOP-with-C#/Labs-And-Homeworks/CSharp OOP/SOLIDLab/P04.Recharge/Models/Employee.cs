namespace P04.Recharge.Models
{
    using System;

    using P04.Recharge.Interfaces;

    public class Employee : Worker, IWorker, ISleeper
    {
        public Employee(string id, int workingHours) 
            : base(id, workingHours)
        {

        }

        public void Sleep()
        {
            Console.WriteLine("I am sleeping ...");
        }

        public void Work(int hours)
        {
            this.workingHours += hours;
        }
    }
}
