namespace P04.Recharge.Models
{
    public abstract class Worker
    {
        protected string id;
        protected int workingHours;

        public Worker(string id, int workingHours)
        {
            this.id = id;
            this.workingHours = workingHours;
        }
    }
}