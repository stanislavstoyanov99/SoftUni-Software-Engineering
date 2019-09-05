namespace AnimalCentre.Models.Procedures
{
    using System;
    using System.Collections.Generic;

    using AnimalCentre.Models.Contracts;
    using AnimalCentre.Utilities.Messages;

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
                throw new ArgumentException(ExceptionMessages.InvalidProcedureTime);
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
