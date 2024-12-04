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
            entities = new List<EntityEnemy>();
            Random random = new Random();
            int amountEnemy = random.Next(waveNumber, waveNumber+2);
            for (int i = 0; i <= amountEnemy; i++) {
				entities.Add(new EntityEnemy());
                entities.ElementAt(i).y = random.Next(-100, height+100);
				entities.ElementAt(i).x = random.Next(-100, width+100);

			}
        }
    }
}