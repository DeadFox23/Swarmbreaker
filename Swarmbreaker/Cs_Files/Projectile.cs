namespace Swarmbreaker.Cs_Files
{
    public class Projectile
    {
        public int radius { get; set; } = 0;
        public int speed { get; set; } = 0;
        public int range { get; set; } = 0;



        public Projectile(int radius, int speed, int range) {
            this.radius = radius;
            this.speed = speed;
            this.range = range;
        }

    }
}
