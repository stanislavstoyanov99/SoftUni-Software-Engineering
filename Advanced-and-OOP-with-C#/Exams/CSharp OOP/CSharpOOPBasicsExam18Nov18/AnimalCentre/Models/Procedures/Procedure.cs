namespace AnimalCentre.Models.Procedures
{
    using System.Text;
    using System.Collections.Generic;

    using AnimalCentre.Models.Contracts;

    public abstract class Procedure : IProcedure
    {
        public Procedure()
        {
            this.ProcedureHistory = new Dictionary<string, List<IAnimal>>();
        }

        protected Dictionary<string, List<IAnimal>> ProcedureHistory { get; set; }

        public abstract void DoService(IAnimal animal, int procedureTime);

        public string History()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var procedure in this.ProcedureHistory)
            {
                sb.AppendLine($"{procedure.Key}");

                foreach (var animal in procedure.Value)
                {
                   sb.AppendLine(animal.ToString());
                }                   
            }

            return sb.ToString().TrimEnd();
        }
    }
}
