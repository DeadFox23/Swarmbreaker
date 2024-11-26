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
      

        public void OnPost()
        {

        }
        public void OnGet() {
            Main();
            
        }

        public IActionResult OnGetWindowSize(String myData)
        {
            height = Int32.Parse(Regex.Match(myData, "(?<=\\bHeight\\b\\W:\\s)[0-9]+(?=,)").ToString());
            width = Int32.Parse(Regex.Match(myData, "(?<=\\bWidth\\b\\W:\\s)[0-9]+(?=,)").ToString());
            return new JsonResult(new {});
        }
        public void Main()
        {// FIX THE WEAPON LATER - CREATE LIST OF POSSIBLE WEAPONS
            players.Add(new EntityPlayerCharacter(height / 2, width / 2, 1, 100, 5, new Weapon("placeholder", "placeholder", 0, 0, 0, 0, 0), 0, 0, 0));
            waveNumber = 900;
            spawn();

        }
        
        public void spawn() {
            entities = new List<EntityEnemy>();
            Random random = new Random();
            int amountEnemy = random.Next(waveNumber, waveNumber+2);
            for (int i = 0; i <= amountEnemy; i++) {
				entities.Add(new EntityEnemy());
                entities.ElementAt(i).Id = i;
                entities.ElementAt(i).y = random.Next(-100, height+100);
				entities.ElementAt(i).x = random.Next(-100, width+100);

			}
        }
    }
}