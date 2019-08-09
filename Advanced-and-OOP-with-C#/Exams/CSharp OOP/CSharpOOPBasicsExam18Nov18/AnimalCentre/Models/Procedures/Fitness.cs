namespace AnimalCentre.Models.Procedures
{
    using System;
    using System.Collections.Generic;

    using AnimalCentre.Models.Contracts;

    public class Fitness : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime >= procedureTime)
            {
                animal.ProcedureTime -= procedureTime;

                animal.Happiness -= 3;
                animal.Energy += 10;
            }
            else
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            if (!this.ProcedureHistory.ContainsKey("Fitness"))
            {
                this.ProcedureHistory.Add("Fitness", new List<IAnimal> { animal });
            }
            else
            {
                this.ProcedureHistory["Fitness"].Add(animal);
            }
        }
    }
}
