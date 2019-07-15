using _10ExplicitInterfaces.Models;

namespace _10ExplicitInterfaces.Factories
{
    public class PersonFactory
    {
        public Citizen CreateCitizen(string[] citizenInfo)
        {
            string citizenName = citizenInfo[0];
            string citizenCountry = citizenInfo[1];
            int citizenAge = int.Parse(citizenInfo[2]);

            Citizen citizen = new Citizen(citizenName, citizenCountry, citizenAge);

            return citizen;
        }
    }
}
