using System.Numerics;

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

        public int statXP=0;
        public int statLevel=1;

        public List<EntityEnemy>? move(Vector2 direction, int sizeX, int sizeY, List<EntityEnemy> enemies)
        {
            this.x = (x + (int)(direction.X * speed) > sizeX ? sizeX : (int)(direction.X * speed));
            this.y = (y + (int)(direction.Y * speed) > sizeY ? sizeY : (int)(direction.Y * speed));




            if (!(enemies == null || enemies.Count == 0))
            {

                EntityEnemy? closestEnemy = null;
                float closestDistance = float.MaxValue;
                Vector2 currentPosition = new Vector2(x, y);

                foreach (var enemy in enemies)
                {
                    Vector2 enemyPosition = new Vector2(enemy.x, enemy.y);
                    float distance = Vector2.Distance(currentPosition, enemyPosition);

                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestEnemy = enemy;
                    }
                }


                if(closestEnemy != null) enemies[enemies.IndexOf(closestEnemy)] = this.attack(enemies[enemies.IndexOf(closestEnemy)]);


            }
            return enemies;
        }
        public bool death()
        {
            return (this.statBaseHP <= 0);
        }
        public EntityEnemy attack(EntityEnemy closestEnemy) {
            foreach(Weapon weapon in equippedWeapons) { closestEnemy = weapon.attack(closestEnemy,this.x, this.y); }
            return (closestEnemy);
        }
        public void xpUp(int xp)
        {
            this.statXP += xp;
            if (this.statXP > Math.Pow(this.statLevel / 0.5, 3))
            {
                this.statXP -= (int)Math.Pow(this.statLevel / 0.5, 3);
                this.statLevel++;
                //timer pause
                //add LevelUp popup              
            }
        }
        public void levelDown() {
            throw new NotImplementedException();
        }
        public EntityPlayerCharacter(int y, int x, float speed, float statBaseHP, Weapon equippedWeapon, float statBonusAttack, float statBonusArmor, float statAttackSpeed)
        {
            this.y = y;
            this.x = x;
            this.speed = speed;
            this.statBaseHP = statBaseHP;
            this.equippedWeapons = new Weapon[6];
            this.equippedWeapons[0] = (equippedWeapon ?? new Weapon(0));
            this.statBonusAttack = statBonusAttack;
            this.statBonusArmor = statBonusArmor;
            this.statAttackSpeed = statAttackSpeed;
        }

        public void addWeapon(int weaponType){
            if (this.equippedWeapons[5] != null) {
                for (int i = 0; i < equippedWeapons.Length-1; i++) {
                    if (equippedWeapons[i] == null)
                    {
                        new Weapon(weaponType);
                        break;
                    }
                    if (equippedWeapons[i].weaponType == weaponType)
                    {
                        equippedWeapons[i].Upgrade(2);
                        break;
                    }
                }
            }
        }

        public void increaseSpeed(){
            this.speed++;
        }
		public void increaseHP()
		{
			this.statBaseHP++;
		}
		public void increaseAttack()
		{
			this.statBonusAttack++;
		}
		public void increaseArmor()
		{
			this.statBonusArmor++;
		}
		public void increaseAttackSpeed()
		{
			this.statAttackSpeed++;
		}
	}
}