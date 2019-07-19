namespace P04.Recharge
{
    using P04.Recharge.Models;

    public class Program
    {
        public static void Main()
        {
            // Enter business logic

            Employee employee = new Employee("100", 200);
            employee.Work(5);
            employee.Sleep();

            Robot robot = new Robot("200", 100, 50);
            robot.CurrentPower = 100;
            robot.Work(5);
            robot.Recharge();
        }
    }
}
