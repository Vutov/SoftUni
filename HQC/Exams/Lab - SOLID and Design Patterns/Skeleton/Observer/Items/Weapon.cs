namespace Skyrim.Items
{
    public class Weapon
    {
        public Weapon(int apBonus, int hpBonus)
        {
            this.AttackBonus = apBonus;
            this.HealthBonus = hpBonus;
        }

        public int AttackBonus { get; set; }

        public int HealthBonus { get; set; }

        public override string ToString()
        {
            return string.Format("Weapon AP: {0}, HP: {1}",
                this.AttackBonus, this.HealthBonus);
        }
    }
}
