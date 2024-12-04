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




        public Projectile(int radius, int speed, int range,int x, int y)
        {
            this.radius = radius;
            this.speed = speed;
            this.range = range;
            this.x = x;
            this.y = y;
        }

        public EntityEnemy move(Vector2 direction, EntityEnemy closestEnemy) {
            direction *= speed;
            this.x += (int)direction.X;
            this.y += (int)direction.Y;


            if (closestEnemy.x >= this.x - 10 && closestEnemy.x <= this.x + 10 && closestEnemy.y >= this.y - 10 && closestEnemy.y <= this.y + 10) { 
            
            }


                return closestEnemy;
        }

    }
}
