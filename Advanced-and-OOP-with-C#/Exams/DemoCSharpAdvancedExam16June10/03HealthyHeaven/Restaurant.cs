using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Restaurant
    {
        private List<Salad> salads;

        public Restaurant(string name)
        {
            this.Name = name;
            this.salads = new List<Salad>();
        }

        public string Name { get; set; }

        public void Add(Salad salad)
        {
            this.salads.Add(salad);
        }

        public bool Buy(string name)
        {
            Salad saladToBuy = this.salads.FirstOrDefault(s => s.Name == name);

            bool result = false;
            if (this.salads.Contains(saladToBuy))
            {
                this.salads.Remove(saladToBuy);
                result = true;
            }

            return result;
        }

        public Salad GetHealthiestSalad()
        {
            int healthistSalad = int.MaxValue;

            foreach (var salad in this.salads)
            {
                if (salad.GetTotalCalories() < healthistSalad)
                {
                    healthistSalad = salad.GetTotalCalories();
                }
            }

            Salad healthiestSalad = this.salads
                .FirstOrDefault(s => s.GetTotalCalories() == healthistSalad);

            return healthiestSalad;
        }

        public string GenerateMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} have {this.salads.Count} salads: ");

            foreach (var salad in this.salads)
            {
                sb.AppendLine($"{salad.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
