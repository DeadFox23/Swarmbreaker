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
        public required List<EntityEnemy> enemys { get; set; } = new List<EntityEnemy>();
		public required List<EntityPlayerCharacter> players { get; set; }  = new List<EntityPlayerCharacter>();
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
            foreach (var enemy in enemys)
            {
                //TODO BUILD JSON 
                result = JsonConvert.SerializeObject(enemy, Formatting.Indented);
            }
            return new JsonResult(new { result });
        }


        public void Main()
        {
            
            waveNumber = 900;
            spawn();
            
        }
        
        public void spawn() {

            //players.Add(new EntityPlayerCharacter());

            Random random = new Random();
            int amountEnemy = random.Next(waveNumber, waveNumber+2);
            for (int i = 0; i <= amountEnemy; i++) {
                EntityEnemy enemy = new EntityEnemy();
				enemys.Add(enemy);
				enemys.ElementAt(i).y = random.Next(-100, height+100);
				enemys.ElementAt(i).x = random.Next(-100, width+100);

			}
            Console.WriteLine();
        }


        public IActionResult OnGetAction(string action)
        {
            Console.WriteLine(action);
            switch (action)
            {
                case "Speed":
                    //foreach(EntityPlayerCharacter player : players)
                    //    {

                    //}
                    //players.ElementAt(0).increaseSpeed();
                    break;
                case "HP":
                    //increaseHP();
                    break;
                case "Damage":
                    //increaseAttack();
                    break;
                case "Armor":
                    //increaseArmor();
                    break;
                case "Attackspeed":
                    //increaseAttackSpeed();
                    break;

                case "Slingshot":
                    //addWeapon(\"Slingshot\", \"Slingshot\", 1.3, 15, 3, 100, 1);
                    break;
                case "Tree":
                    //addWeapon(\"Tree\", \"Tree\", 1.5, 20, 1, 40, 0);
                    break;
                case "Shotgun":
                    //addWeapon(\"Shotgun\", \"Shotgun\", 1.2, 5, 3, 75, 3);
                    break;
                case "Knife":
                    //addWeapon(\"Knife\", \"Knife\", 0.7, 9, 2, 25, 0);
                    break;
                case "Bow":
                    //addWeapon(\"Bow\", \"Bow\", 1, 11, 3, 150, 1);
                    break;
                case "Axe":
                    //addWeapon(\"Axe\", \"Axe\", 0.9, 10, 1, 30, 0);
                    break;
            }

            return new JsonResult(new { });
        }
    }
}