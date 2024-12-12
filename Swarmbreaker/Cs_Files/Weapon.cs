namespace Swarmbreaker.Cs_Files {
    public class Weapon {

        public string name { get; set; }
        public string description { get; set; }
        public float attackSpeed { get; set; }
        public float attackBase { get; set; }
        public int weaponType { get; set; } //referenced in WeaponData
        public int attackType { get; set; }// 0 -> slash | 1 -> stab | 2 -> projectile (no melee damage)
        public int weaponRange { get; set; }
        public int projectiles { get; set; }
        public DateTime lastAttack { get; set; } = DateTime.Now;
        public List<Projectile> Projectiles { get; set; } = new List<Projectile>();
        public bool weaponShowing { get; set; } = false;
        public int weaponDegree { get; set; } = 0;



        public List<EntityEnemy> attack(List<EntityEnemy> enemyList, EntityEnemy closestEnemy, int x, int y) {

            TimeSpan elapsedTime = DateTime.Now - lastAttack;

            if ( elapsedTime.TotalMilliseconds >= attackSpeed ) {

                if ( attackType > 0 ) {
                    for ( int i = 0; i < projectiles; i++ ) {
                        Projectiles.Add(new(( int ) WeaponData.data[weaponType, 0], ( int ) WeaponData.data[weaponType, 1], ( int ) WeaponData.data[weaponType, 2], ( int ) WeaponData.data[weaponType, 3], ( int ) WeaponData.data[weaponType, 4], x, y));
                    }
                }
                foreach ( var projectile in Projectiles ) {
                    if ( projectile != null )
                        enemyList = projectile.move(enemyList, closestEnemy);
                }


                //general weapon behaviour
                weaponShowing = true;




                lastAttack = DateTime.Now;
            }

            return enemyList;

        }

        public int CalculateAngle(EntityEnemy closestEnemy, int x, int y) {
            // Calculate the differences in coordinates
            int deltaX = closestEnemy.x - x;
            int deltaY = closestEnemy.y - y;

            // Get the angle in radians and convert to degrees
            double angleInRadians = Math.Atan2(deltaY, deltaX);
            double angleInDegrees = angleInRadians * ( 180 / Math.PI );

            // Normalize the angle to 0–360 degrees
            angleInDegrees = ( angleInDegrees + 360 ) % 360;

            // Return the angle as an integer
            return ( int ) Math.Round(angleInDegrees)+weaponDegree;
        }




        public void Upgrade(int upgradeType) {
            switch ( upgradeType ) {

                case 0:
                attackSpeed *= ( float ) 1.1;
                break;

                case 1:
                attackBase *= ( float ) 1.05;
                break;

                case 2:
                projectiles++;
                break;

                default:
                break;
            }
        }




        public Weapon(int weaponType) {
            this.name = ( string ) WeaponData.data[weaponType, 5];
            this.description = ( string ) WeaponData.data[weaponType, 6];
            this.attackSpeed = float.Parse(WeaponData.data[weaponType, 7].ToString());
            this.attackBase = float.Parse(WeaponData.data[weaponType, 8].ToString());
            this.attackType = ( int ) WeaponData.data[weaponType, 9];
            this.weaponRange = ( int ) WeaponData.data[weaponType, 10];
            this.projectiles = ( int ) WeaponData.data[weaponType, 11];
            if ( weaponType == 0 )
                this.weaponDegree = -45;
        }

    }
}
