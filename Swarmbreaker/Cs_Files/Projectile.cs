using System.Numerics;

namespace Swarmbreaker.Cs_Files
{
    public class Projectile
    {
        public int radius { get; set; } = 0;
        public int speed { get; set; } = 0;
        public int range { get; set; } = 0;
        public int x { get; set; }
        public int y { get; set; }
        public int damage { get; set; }
        public int penetration { get; set; }
        public Vector2 direction { get; set; }



        public Projectile(int radius, int speed, int range, int damage, int x, int y)
        {
            this.radius = radius;
            this.speed = speed;
            this.range = range;
            this.damage = damage;
            this.x = x;
            this.y = y;
        }

        public EntityEnemy[] move(EntityEnemy[] enemyList, EntityEnemy closestEnemy)
        {
            direction *= speed;
            this.x += (int)direction.X;
            this.y += (int)direction.Y;


            foreach ( EntityEnemy enemy in enemyList ) {
                if ( enemy.x >= this.x - this.radius
                    && enemy.x <= this.x + this.radius
                    && enemy.y >= this.y - this.radius
                    && enemy.y <= this.y + this.radius
                    && penetration>-1) {
                    penetration--;
                    enemy.statBaseHP -= damage;

                }
            }

                return enemyList;
            }
			
		
    }
}
