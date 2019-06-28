using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> familyMembers;

        public Family()
        {
            familyMembers = new List<Person>();
        }

        public void AddMember(Person member)
        {
            familyMembers.Add(member);
        }

        public List<Person> GetFilteredMembers()
        {
            var members = familyMembers
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToList();

            return members;
        }
    }
}
