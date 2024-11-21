using System.Numerics;

namespace Swarmbreaker.Cs_Files
{
    public class EntityPlayerCharacter : IEntity
    {

        public int id { get; set; }
        public int y { get; set; }
        public int x { get; set; }
        public float speed { get; set; }
        public float statBaseHP { get; set; }
        public Weapon equippedWeapons { get; set; }
        public float statBonusAttack { get; set; }
        public float statBonusArmor { get; set; }

        public static int statXP;
        public static int statLevel;
        public float statAttackSpeed;

        public void move(Vector2 direction)
        {
            this.x += (int)(direction.X*speed);
            this.y += (int)(direction.Y*speed);
        }
        public void death() { }
        public void attack() { }
        public void levelUp() {}
        public void levelDown() {
            throw new NotImplementedException();
        }
        public EntityPlayerCharacter(int id, int y, int x, float speed, float statBaseHP, Weapon equippedWeapons, float statBonusAttack, float statBonusArmor, float statAttackSpeed)
        {
            this.id = id;
            this.y = y;
            this.x = x;
            this.speed = speed;
            this.statBaseHP = statBaseHP;
            this.equippedWeapons = equippedWeapons;
            this.statBonusAttack = statBonusAttack;
            this.statBonusArmor = statBonusArmor;
            this.statAttackSpeed = statAttackSpeed;
        }
    }
}