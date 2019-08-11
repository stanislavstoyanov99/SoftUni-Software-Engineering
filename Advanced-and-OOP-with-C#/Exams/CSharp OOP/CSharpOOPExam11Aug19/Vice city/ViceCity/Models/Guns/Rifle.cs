namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        public Rifle(string name)
            : base(name, 50, 500)
        {

        }

        public override int Fire()
        {
            int totalShootedBullets = 0;

            while (this.CanFire && this.TotalBullets > 0)
            {
                // Empty barrel
                if (this.BulletsPerBarrel == 0)
                {
                    this.TotalBullets -= 50;

                    this.BulletsPerBarrel = 50;
                }

                totalShootedBullets += 5;
                this.BulletsPerBarrel -= 5;
                this.TotalBullets -= 5;
            }

            return totalShootedBullets;
        }
    }
}
