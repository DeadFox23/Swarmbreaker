namespace Swarmbreaker.Cs_Files
{
    public class Weapon
    {

        public string name { get; set; }
        public string description { get; set; }
        public float attackSpeed { get; set; }
        public float attackBase { get; set; }
        public int weaponType { get; set; } //referenced in WeaponData
        public int attackType { get; set; }// 0 -> slash | 1 -> stab | 2 -> projectile (no melee damage)
        public int weaponRange { get; set; }
        public int projectiles { get; set; }
        public DateTime lastAttack { get; set; } = DateTime.Now;
        public List<Projectile> Projectiles { get; set; } = [];



        public EntityEnemy attack(EntityEnemy closestEnemy, int x, int y) {

            TimeSpan elapsedTime = DateTime.Now - lastAttack;

            if (elapsedTime.TotalMilliseconds >= attackSpeed){


                //detect closest enemy



                if (attackType > 0)
                {
                    for (int i = 0; i < projectiles; i++)
                    {
                        Projectiles.Add(new((int)WeaponData.data[weaponType, 0], (int)WeaponData.data[weaponType, 1], (int)WeaponData.data[weaponType, 0], x, y));
                    }
                }
                


                //general weapon behaviour



                lastAttack = DateTime.Now;
            }

            return closestEnemy;

        }




        public void Upgrade(int upgradeType){
            switch(upgradeType){

                case 0:
                    attackSpeed *=  (float)1.1;
                    break;

                case 1:
                    attackBase  *=  (float)1.05;
                    break;
                
                case 2:
                    projectiles++;
                    break;

                default:
                    break;
            }
        }




        public Weapon(int weaponType)
        {
            this.name           =(string)   WeaponData.data[weaponType, 3];
            this.description    =(string)   WeaponData.data[weaponType, 4];
            this.attackSpeed    =(float)    WeaponData.data[weaponType, 5];
            this.attackBase     =(float)    WeaponData.data[weaponType, 6];
            this.attackType     =(int)      WeaponData.data[weaponType, 7];
            this.weaponRange    =(int)      WeaponData.data[weaponType, 8];
            this.projectiles    =(int)      WeaponData.data[weaponType, 9];
        }

    }
}
