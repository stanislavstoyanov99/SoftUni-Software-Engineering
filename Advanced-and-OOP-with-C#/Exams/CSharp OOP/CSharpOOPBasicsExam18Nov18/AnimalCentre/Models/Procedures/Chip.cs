namespace AnimalCentre.Models.Procedures
{
    using System;
    using System.Collections.Generic;

    using AnimalCentre.Models.Contracts;

    public class Chip : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime >= procedureTime)
            {
                animal.ProcedureTime -= procedureTime;

                animal.Happiness -= 5;
            }
            else
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            if (animal.IsChipped == true)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }

            animal.IsChipped = true;

            if (!this.ProcedureHistory.ContainsKey("Chip"))
            {
                this.ProcedureHistory.Add("Chip", new List<IAnimal> { animal });
            }
            else
            {
                this.ProcedureHistory["Chip"].Add(animal);
            }
        }
    }
}
