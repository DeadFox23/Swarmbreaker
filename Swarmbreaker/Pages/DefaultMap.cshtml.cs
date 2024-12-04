using System.Collections.Generic;
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
        public required List<EntityEnemy> entities { get; set; }
        public required List<EntityPlayerCharacter> players { get; set; }
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
            
            waveNumber = 900;
            spawn();
            
        }
        
        public void spawn() {
            players = new List<EntityPlayerCharacter>();
            //players.Add(new EntityPlayerCharacter());
            entities = new List<EntityEnemy>();
            Random random = new Random();
            int amountEnemy = random.Next(waveNumber, waveNumber+2);
            for (int i = 0; i <= amountEnemy; i++) {
				entities.Add(new EntityEnemy());
                entities.ElementAt(i).y = random.Next(-100, height+100);
				entities.ElementAt(i).x = random.Next(-100, width+100);

			}
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
                    players.ElementAt(0).increaseSpeed();
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