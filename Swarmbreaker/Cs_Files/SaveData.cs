namespace Swarmbreaker.Cs_Files
{
	public static class SaveData
	{
		public static List<EntityEnemy> enemies { get; set; } = new List<EntityEnemy>();
		public static List<EntityPlayerCharacter> players { get; set; } = new List<EntityPlayerCharacter>();
	
		public static void addEnemy(int y, int x, float speed, float statBaseHP, float statBaseAttack, float statBonusAttack, float statBonusArmor, int xpDrop, Boolean isBoss)
		{
			enemies.Add(new EntityEnemy(y, x, speed, statBaseHP, statBaseAttack, statBonusAttack, statBonusArmor, xpDrop, isBoss, 1));
		}
		public static void addPlayer(int y, int x, float speed, float statBaseHP, Weapon equippedWeapon, float statBonusAttack, float statBonusArmor, float statAttackSpeed)
		{
			players.Add(new EntityPlayerCharacter(y, x, speed, statBaseHP, equippedWeapon, statBonusAttack, statBonusArmor, statAttackSpeed));
		}


	}
}
