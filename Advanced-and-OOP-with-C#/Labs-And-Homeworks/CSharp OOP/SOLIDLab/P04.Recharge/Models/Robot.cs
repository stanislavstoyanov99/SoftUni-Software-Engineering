namespace P04.Recharge.Models
{
    using P04.Recharge.Interfaces;

    public class Robot : Worker, IWorker, IRechargeable
    {
        private int capacity;
        private int currentPower;

        public Robot(string id, int capacity, int workingHours) 
            : base(id, workingHours)
        {
            this.capacity = capacity;
        }

        public int Capacity
        {
            get { return this.capacity; }
        }

        public int CurrentPower
        {
            get => this.currentPower;
            set { this.currentPower = value; }
        }

        public void Recharge()
        {
            this.currentPower = this.capacity;
        }

        public void Work(int hours)
        {
            if (hours > this.currentPower)
            {
                hours = currentPower;
            }

            this.workingHours += hours;
            this.currentPower -= hours;
        }
    }
}