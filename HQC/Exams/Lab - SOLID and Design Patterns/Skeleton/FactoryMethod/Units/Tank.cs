namespace TankManufacturer.Units
{
    public class Tank
    {
        public Tank(string model, double speed, int attackDamage)
        {
            this.Model = model;
            this.Speed = speed;
            this.AttackDamage = attackDamage;
        }

        public string Model { get; set; }

        public double Speed { get; set; }

        public int AttackDamage { get; set; }

        public override string ToString()
        {
            return string.Format("-Tank\n...Model: {0}\n...Speed: {1:F2}\n...Damage: {2}",
                this.Model, this.Speed, this.AttackDamage);
        }
    }
}
