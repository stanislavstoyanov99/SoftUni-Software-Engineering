
namespace AnimalCentre.Models.Procedures
{
    using System;
    using System.Collections.Generic;

    using AnimalCentre.Models.Contracts;

    public class Play : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime >= procedureTime)
            {
                animal.ProcedureTime -= procedureTime;

                animal.Happiness += 12;
                animal.Energy -= 6;
            }
            else
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            if (!this.ProcedureHistory.ContainsKey("Play"))
            {
                this.ProcedureHistory.Add("Play", new List<IAnimal> { animal });
            }
            else
            {
                this.ProcedureHistory["Play"].Add(animal);
            }
        }
    }
}
