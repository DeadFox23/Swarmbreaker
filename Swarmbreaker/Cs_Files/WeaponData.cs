namespace Swarmbreaker.Cs_Files
{
    public static class WeaponData
    {
        public static Object[,] data = new Object[5, 12] { 

            //  (int)
            //  0:      projectileRadius
            //  1:      projectileSpeed
            //  2:      projectileRange
            //  3:      projectileDamage
            //  4:      projectilePenetration
            
            //  (String)
            //  5:      weaponName
            //  6:      weaponDescription
            
            //  (float) 
            //  7:      weaponAttackSpeed
            //  8:      weaponAttackBase

            //  (int)
            //  9:      weaponAttackType
            //  10:     weaponWeaponRange
            //  11:     weaponProjectiles


            {5, 1, 100, 10, 0, "Slingshot", "Slingshot", (float)1.3, (float)15, 3, 15, 1},
            {0, 0, 0, 0, 0, "Tree", "Tree", (float)1.5, (float)20, 1, 40, 0},
			{3, 5, 75, 25, 0, "Shotgun", "Shotgun", 1.2, 5, 3, 20, 3}, 
            {0, 0, 0, 0, 0, "Knife", "Knife", 0.7, 9, 2, 25, 0},
            {0, 0, 0, 0, 0, "Axe", "Axe", 0.9, 10, 1, 30, 0} 
		};
        
    }
}
