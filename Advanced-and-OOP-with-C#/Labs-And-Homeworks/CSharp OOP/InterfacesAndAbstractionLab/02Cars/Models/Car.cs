namespace Cars.Models
{
    public abstract class Car
    {
        public virtual string Start()
        {
            return "Engine start";
        }

        public virtual string Stop()
        {
            return "Breaaak!";
        }
    }
}
