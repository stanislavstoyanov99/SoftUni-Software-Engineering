namespace AnimalCentre.Models.Procedures
{
    using System;
    using System.Collections.Generic;

    using AnimalCentre.Models.Contracts;

    public class NailTrim : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime >= procedureTime)
            {
                animal.ProcedureTime -= procedureTime;

                animal.Happiness -= 7;
            }
            else
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            if (!this.ProcedureHistory.ContainsKey("NailTrim"))
            {
                this.ProcedureHistory.Add("NailTrim", new List<IAnimal> { animal });
            }
            else
            {
                this.ProcedureHistory["NailTrim"].Add(animal);
            }
        }
    }
}
