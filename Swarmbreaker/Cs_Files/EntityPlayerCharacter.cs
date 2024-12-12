using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.JSInterop;
using Swarmbreaker.Pages;
using System.Numerics;

namespace Swarmbreaker.Cs_Files {
    public class EntityPlayerCharacter : IEntity {

        public int y { get; set; } = 0;
        public int x { get; set; } = 0;
        public float speed { get; set; } = 1.0f;
        public float statBaseHP { get; set; } = 0;
        public Weapon[] equippedWeapons { get; set; }
        public float statBonusAttack { get; set; } = 0;
        public float statBonusArmor { get; set; } = 0;
        public float statAttackSpeed { get; set; } = 0;
        public DateTime lastTime_iFrame { get; set; } = DateTime.Now;

        public int[,] shownWeapon {  get; set; } 
        public int statXP { get; set; } = 0;
        public int statLevel { get; set; } = 1;
        public Boolean levelUp { get; set; } = false;

        public List<EntityEnemy>? move(Vector2 direction, int sizeX, int sizeY, List<EntityEnemy> enemies) {
            //fieldsize = sizeX * sizeY / border control
            if ( x + ( direction.X * speed ) > sizeX-60 )
                this.x = sizeX-60;
            else if ( x + ( direction.X * speed ) < 0 )
                this.x = 0;
            else
                this.x += ( int ) ( direction.X * speed );


            if ( y + ( direction.Y * speed ) > sizeY-60 )
                this.y = sizeY-60;
            else if ( y + ( direction.Y * speed ) < 0 )
                this.y = 0;
            else
                this.y += ( int ) ( direction.Y * speed );



            if ( !( enemies == null || enemies.Count == 0 ) ) {

                EntityEnemy? closestEnemy = null;
                float closestDistance = float.MaxValue;
                Vector2 currentPosition = new Vector2(x, y);

                foreach ( var enemy in enemies ) {
                    Vector2 enemyPosition = new Vector2(enemy.x, enemy.y);
                    float distance = Vector2.Distance(currentPosition, enemyPosition);

                    if ( distance < closestDistance ) {
                        closestDistance = distance;
                        closestEnemy = enemy;
                    }
                }

                enemies = this.attack(enemies, closestEnemy!);


            }



            //falls projectile keine weiteren hits machen darf wird es aus der liste entfernt
            foreach ( Weapon weapon in equippedWeapons ) {
                if ( weapon != null ) {
                    foreach ( Projectile proj in weapon.Projectiles ) {
                        if ( proj.penetration < 0 || proj.distanceTraveled >= proj.range ) {
                            weapon.Projectiles.Remove(proj);
                        }
                    }

                }
            }



            return enemies;
        }

        public void attackAnimation() {
            for ( int i = 0; i < 6; i++ ) {
            }
        }
        public bool death() {
            return ( this.statBaseHP <= 0 );
        }
        public List<EntityEnemy> attack(List<EntityEnemy> enemyList, EntityEnemy closestEnemy) {
            foreach ( Weapon weapon in equippedWeapons ) { if ( weapon != null ) enemyList = weapon.attack(enemyList, closestEnemy, this.x, this.y); }
            return ( enemyList );
        }
        public void xpUp(int xp) {
            this.statXP += xp;
            if ( this.statXP > Math.Pow(this.statLevel / 0.5, 3) ) {
                this.statXP -= ( int ) Math.Pow(this.statLevel / 0.5, 3);
                this.statLevel++;
                this.levelUp = true;
			}
        }
        public void levelDown() {
            throw new NotImplementedException();
        }
        public EntityPlayerCharacter(int y, int x, float speed, float statBaseHP, Weapon equippedWeapon, float statBonusAttack, float statBonusArmor, float statAttackSpeed, Boolean levelUp) {
            this.y = y;
            this.x = x;
            this.speed = speed;
            this.statBaseHP = statBaseHP;
            this.equippedWeapons = new Weapon[6];
            this.equippedWeapons[0] = ( equippedWeapon ?? new Weapon(0) );
            this.statBonusAttack = statBonusAttack;
            this.statBonusArmor = statBonusArmor;
            this.statAttackSpeed = statAttackSpeed;
            this.levelUp = levelUp;
            this.shownWeapon = new int[6, 2];
        }

        public void addWeapon(int weaponType) {
            if ( this.equippedWeapons[5] != null ) {
                for ( int i = 0; i < equippedWeapons.Length - 1; i++ ) {
                    if ( equippedWeapons[i] == null ) {
                        new Weapon(weaponType);
                        break;
                    }
                    if ( equippedWeapons[i].weaponType == weaponType ) {
                        equippedWeapons[i].Upgrade(2);
                        break;
                    }
                }
            }
        }

        public void increaseSpeed() {
            this.speed++;
        }
        public void increaseHP() {
            this.statBaseHP++;
        }
        public void increaseAttack() {
            this.statBonusAttack++;
        }
        public void increaseArmor() {
            this.statBonusArmor++;
        }
        public void increaseAttackSpeed() {
            this.statAttackSpeed++;
        }
    }
}