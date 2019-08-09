namespace AnimalCentre.Models.Procedures
{
    using System;
    using System.Collections.Generic;

    using AnimalCentre.Models.Contracts;

    public class Vaccinate : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime >= procedureTime)
            {
                animal.ProcedureTime -= procedureTime;

                animal.Energy -= 8;
                animal.IsVaccinated = true;
            }
            else
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            if (!this.ProcedureHistory.ContainsKey("Vaccinate"))
            {
                this.ProcedureHistory.Add("Vaccinate", new List<IAnimal> { animal });
            }
            else
            {
                this.ProcedureHistory["Vaccinate"].Add(animal);
            }
        }
    }
}
