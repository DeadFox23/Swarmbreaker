namespace Swarmbreaker.Cs_Files
{
    public class Weapon
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public float attackSpeed { get; set; }
        public float attackBase { get; set; }
        public int weaponType { get; set; } // 0 -> slash | 1 -> stab | 2 -> projectile (no melee damage)
        public int weaponRange { get; set; }
        public int projectiles { get; set; }

        public void attack() { }
        Weapon(string name, string description, float attackSpeed, float attackBase, int weaponType)
        {
            Name = name;
            Description = description;
            this.attackSpeed = attackSpeed;
            this.attackBase = attackBase;
            this.weaponType = weaponType;
        }
    }
}
