namespace AnimalCentre.Models.Procedures
{
    using System;
    using System.Collections.Generic;

    using AnimalCentre.Models.Contracts;
    using AnimalCentre.Utilities.Messages;

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
                throw new ArgumentException(ExceptionMessages.InvalidProcedureTime);
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
