using System.Collections.Generic;
using System.Numerics;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Timers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Swarmbreaker.Cs_Files;

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
        public IActionResult OnGetData(string Height,string Width)
        {

            height = Convert.ToInt32(Height);
            width = Convert.ToInt32(Width);
                   //"(?<=\\bHeight\\b\\W:\\s)[0-9]+"))

			return new JsonResult(new { height = Height, width = Width });
        }
        public IActionResult OnGetEnemy(string baum)
        {
            string result = null;
            foreach (var enemy in SaveData.enemies)
            {
                //TODO BUILD JSON 
                result = JsonConvert.SerializeObject(enemy, Formatting.Indented);
            }
            return new JsonResult(new { result });
        }


        public void Main()
        {
            if(SaveData.players.Count == 0) {
				players.Add(new EntityPlayerCharacter(height / 2, width / 2, 5, 50, new Weapon(1), 0, 0, 5));
				SaveData.addPlayer(height / 2, width / 2, 5, 50, new Weapon(1), 0, 0, 5);
                waveNumber = 900;
                spawn();
			}
		}
        
        public void spawn() {
 
            Random random = new Random();
            int amountEnemy = random.Next(waveNumber, waveNumber+2);
            for (int i = 0; i <= amountEnemy; i++) {
				int y = random.Next(-100, height + 100);
				int x = random.Next(-100, width + 100);
                float speed = 2;
				float statBaseHP = 50;
				float statBaseAttack = 5;
				float statBonusAttack = 0;
				float statBonusArmor = 0;
                int xpDrop = 5;
                bool isBoss = false;


                SaveData.addEnemy(y, x, speed, statBaseHP, statBaseAttack, statBonusAttack, statBonusArmor, xpDrop, isBoss);
                enemies.Add(new EntityEnemy(y, x, speed, statBaseHP, statBaseAttack, statBonusAttack, statBonusArmor, xpDrop, isBoss));
            }
        }




        public IActionResult OnGetAction(string action)
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