using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Timers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Swarmbreaker.Cs_Files;
using static System.Collections.Specialized.BitVector32;

namespace Swarmbreaker.Pages
{
    public class DefaultMap : PageModel
    {
        [BindProperty]

		public required List<EntityEnemy> enemies { get; set; } = new List<EntityEnemy>();
		public required List<EntityPlayerCharacter> players { get; set; } = new List<EntityPlayerCharacter>();
		public int waveNumber { get; set; }

        public System.Timers.Timer? timer;
        int height = 1080;
        int width = 1920;

       public DefaultMap() { }
      
        public void OnGet() {
            Main();
            
        }
        [HttpGet]
        public IActionResult OnGetWindow(string Height,string Width)
        {

            height = Convert.ToInt32(Height);
            width = Convert.ToInt32(Width);
                   //"(?<=\\bHeight\\b\\W:\\s)[0-9]+"))

			return new JsonResult(new { height = Height, width = Width });
        }
        public IActionResult OnGetEnemy(string baum)
        {
            foreach (EntityEnemy enemy in SaveData.enemies)
            {
                
                enemy.move(SaveData.players);
                
                    
            }
            string result = JsonConvert.SerializeObject(SaveData.enemies, Formatting.Indented);
            return new JsonResult(new { result });
        }

        public IActionResult OnGetPlayer(char key)
        {
			Console.WriteLine(key);
			Vector2 pos = new Vector2(0,0);
			switch (key)
			{               
				case 'a':
                    pos = new Vector2(-1,0);
					break;
				case 'd':
					pos = new Vector2(1, 0);
					break;
				case 'w':
					pos = new Vector2(0, -1);
					break;
				case 's':
					pos = new Vector2(0, 1);
					break;
                default:
                    break;
			}
			foreach (EntityPlayerCharacter player in SaveData.players)
            {
                player.move(pos, width, height, SaveData.enemies);
            }
            string result = JsonConvert.SerializeObject(SaveData.players, Formatting.Indented);
            return new JsonResult(new { result });
        }








        public void Main()
        {
            if(SaveData.players.Count == 0) {
				players.Add(new EntityPlayerCharacter(height / 2, width / 2, 5, 50, new Weapon(1), 0, 0, 5));
				SaveData.addPlayer(height / 2, width / 2, 5, 50, new Weapon(1), 0, 0, 5);
			}
            waveNumber =20;
            spawn();
		}
        
        public void spawn() {

            int y;
            int x;
            float speed;
            float statBaseHP;
            float statBaseAttack;
            float statBonusAttack;
            float statBonusArmor;
            int xpDrop;
            Boolean isBoss;

			Random random = new Random();
            int amountEnemy = random.Next(waveNumber, waveNumber+2);

            for (int i = 0; i <= amountEnemy; i++) {
                y = random.Next(-100, height + 100);
				x = random.Next(-100, width + 100);
                speed = 20;
                statBaseHP = 20;
                statBaseAttack = 2; 
                statBonusAttack = 2;
                statBonusArmor = 0;
                xpDrop = 5;
                isBoss = false;
				
				SaveData.addEnemy(y, x, speed, statBaseHP, statBaseAttack, statBonusAttack, statBonusArmor, xpDrop, isBoss);
				enemies.Add(new EntityEnemy(y, x, speed, statBaseHP, statBaseAttack, statBonusAttack, statBonusArmor, xpDrop, isBoss, 1));
			}
        }




        public IActionResult OnGetButton(string action)
        {
            //Kontrollausgabe
			Console.WriteLine(action);
            switch (action)
            {
                case "Speed":
                    foreach(EntityPlayerCharacter player in SaveData.players)
                    {player.increaseSpeed();}
                    break;
                case "HP":
					foreach (EntityPlayerCharacter player in SaveData.players)
					{player.increaseHP();}
					break;
                case "Damage":
					foreach (EntityPlayerCharacter player in SaveData.players)
					{player.increaseAttack();}
					break;
                case "Armor":
					foreach (EntityPlayerCharacter player in SaveData.players)
					{player.increaseArmor();}
					break;
                case "Attackspeed":
					foreach (EntityPlayerCharacter player in SaveData.players)
					{player.increaseAttackSpeed();}
					break;

                case "Slingshot":
					foreach (EntityPlayerCharacter player in SaveData.players)
					{ player.addWeapon(1);}	
					break;
                case "Tree":
					foreach (EntityPlayerCharacter player in SaveData.players)
					{ player.addWeapon(2); }
					break;
                case "Shotgun":
					foreach (EntityPlayerCharacter player in SaveData.players)
					{ player.addWeapon(3); }
					break;
                case "Knife":
					foreach (EntityPlayerCharacter player in SaveData.players)
					{ player.addWeapon(4); }
					break;
                case "Axe":
					foreach (EntityPlayerCharacter player in SaveData.players)
					{ player.addWeapon(5); }
					break;
            }

            return new JsonResult(new { });
        }
    }
}