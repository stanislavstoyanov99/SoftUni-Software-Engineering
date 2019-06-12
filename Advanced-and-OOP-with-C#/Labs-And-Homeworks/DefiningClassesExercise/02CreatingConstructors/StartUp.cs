namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person firstPerson = new Person();
            Person thirdPerson = new Person("No name", 1);
            Person secondPerson = new Person(1);           
        }
    }
}
