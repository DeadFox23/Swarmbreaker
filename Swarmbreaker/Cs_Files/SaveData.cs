﻿namespace Swarmbreaker.Cs_Files
{
	public static class SaveData
	{
		public static List<EntityEnemy> entities { get; set; } = new List<EntityEnemy>();
		public static List<EntityPlayerCharacter> players { get; set; } = new List<EntityPlayerCharacter>();
	
		public static void addEnemy()
		{
			entities.Add(new EntityEnemy());
		}
		public static void addPlayer(int y, int x, float speed, float statBaseHP, Weapon equippedWeapon, float statBonusAttack, float statBonusArmor, float statAttackSpeed)
		{
			players.Add(new EntityPlayerCharacter(y, x, speed, statBaseHP, equippedWeapon, statBonusAttack, statBonusArmor, statAttackSpeed));
		}


	}
}
