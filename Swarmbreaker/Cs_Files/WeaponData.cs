namespace Swarmbreaker.Cs_Files
{
    public static class WeaponData
    {
        public static Object[,] data = new Object[5, 10] { 

            //  (int)
            //  0:      projectileRadius
            //  1:      projectileSpeed
            //  2:      projectileRange
            
            //  (String)
            //  3:      weaponName
            //  4:      weaponDescription
            
            //  (float) 
            //  5:      weaponAttackSpeed
            //  6:      weaponAttackBase

            //  (int)
            //  7:      weaponAttackType
            //  8:      weaponWeaponRange
            //  9:      weaponProjectiles


            {5, 1, 100, "Slingshot", "Slingshot", (float)1.3, (float)15, 3, 15, 1},
            {0, 0, 0, "Tree", "Tree", (float)1.5, (float)20, 1, 40, 0},
			{3, 5, 75, "Shotgun", "Shotgun", 1.2, 5, 3, 20, 3}, 
            {0, 0, 0, "Knife", "Knife", 0.7, 9, 2, 25, 0},
            {0, 0, 0, "Axe", "Axe", 0.9, 10, 1, 30, 0} 
		};
        
    }
}
