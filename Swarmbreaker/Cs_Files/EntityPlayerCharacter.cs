using System.Collections;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Swarmbreaker.Cs_Files
{
    public class EntityPlayerCharacter : IEntity
    {

        public int y { get; set; } = 0;
        public int x { get; set; } = 0;
        public float speed { get; set; } = 1.0f;
        public float statBaseHP { get; set; } = 0;
        public Weapon[] equippedWeapons { get; set; }
        public float statBonusAttack { get; set; } = 0;
        public float statBonusArmor { get; set; } = 0;
        public float statAttackSpeed { get; set; } = 0;
        public float statBaseAttack { get; set; } = 0;

        public int statXP=0;
        public int statLevel=1;

        public void move(Vector2 direction, int ms, int sizeX, int sizeY)
        {
            this.x = (x+(int)(direction.X*speed)>sizeX?sizeX: (int)(direction.X * speed));
            this.y = (y+(int)(direction.Y*speed)>sizeY?sizeY: (int)(direction.Y * speed));
            this.attack(ms);
        }
        public void death() { }

        public void attack(int ms) {
            foreach(Weapon weapon in equippedWeapons) { weapon.attack(ms); }
        }
        public void xpUp(int xp) {
            this.statXP += xp;
            if(this.statXP > this.statLevel /0.5 * 3) {
            
            }
        }
        public void levelDown() {
            throw new NotImplementedException();
        }
        public EntityPlayerCharacter(int y, int x, float speed, float statBaseHP,float statBaseAttack, Weapon equippedWeapon, float statBonusAttack, float statBonusArmor, float statAttackSpeed)
        {
            this.y = y;
            this.x = x;
            this.speed = speed;
            this.statBaseHP = statBaseHP;
            this.equippedWeapons = new Weapon[6];
            this.equippedWeapons[0] = (equippedWeapon ?? new Weapon("placeholder", "placeholder", (float)0.0, (float)0.0, 0, 0, 0));
            this.statBaseAttack = statBaseAttack;
            this.statBonusAttack = statBonusAttack;
            this.statBonusArmor = statBonusArmor;
            this.statAttackSpeed = statAttackSpeed;
        }

        public void addWeapon(string name, string description, float attackSpeed, float attackBase, int weaponType, int weaponRange, int projectiles){
            if (this.equippedWeapons[5] != null) {
                for (int i = 1; i < equippedWeapons.Length-1; i++) {
                    equippedWeapons[i] = equippedWeapons[i] != null ? equippedWeapons[i] : new Weapon(name, description, attackSpeed, attackBase, weaponType, weaponRange, projectiles);
                }
            }
        }
    }
}