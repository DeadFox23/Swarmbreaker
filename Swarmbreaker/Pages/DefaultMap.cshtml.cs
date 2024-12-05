using System.Collections.Generic;
using System.Numerics;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Timers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Swarmbreaker.Cs_Files;

namespace Swarmbreaker.Pages
{
    public class DefaultMap : PageModel
    {
        [BindProperty]
		public required List<EntityEnemy> entities { get; set; } = new List<EntityEnemy>();
		public required List<EntityPlayerCharacter> players { get; set; } = new List<EntityPlayerCharacter>();
		public int waveNumber { get; set; }
        public System.Timers.Timer? timer;
        int height = 1080;
        int width = 1920;
      
        public void OnGet() {
            Main();
            
        }
        [HttpGet]
        public IActionResult OnGetData(string Height,string Width)
        {
            Console.WriteLine(Height);
            
            //"(?<=\\bHeight\\b\\W:\\s)[0-9]+"))


			return new JsonResult(new { height = Height, width = Width });
        }
        public IActionResult OnGetEnemy(string baum)
        {
            Console.WriteLine(baum);
            return new JsonResult(new { b = "bbbbb" });
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
                SaveData.addEnemy();
                entities.Add(new EntityEnemy());
                entities.ElementAt(i).y = random.Next(-100, height + 100);
                entities.ElementAt(i).x = random.Next(-100, width + 100);
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