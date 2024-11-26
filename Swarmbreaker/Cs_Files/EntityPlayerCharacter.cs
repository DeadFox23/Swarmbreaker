using System.Collections;

namespace Swarmbreaker.Cs_Files
{
    public class EntityPlayerCharacter : IEntity
    {

        public int Id { get; set; }
        public int y { get; set; }
        public int x { get; set; }
        public double statBaseHP { get; set; }
        public double statBaseAttack { get; set; }
        public double statBonusAttack { get; set; }
        public double statBonusArmor { get; set; }

        public static int statXP;
        public static int statLevel;
        public double statAttackSpeed;

        public void move() { }
        public void death() { }
        public void attack() { }
        public void levelUp() {}
    }
}