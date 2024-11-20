using System.Collections.Generic;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Swarmbreaker.Cs_Files;

namespace Swarmbreaker.Pages
{
    public class DefaultMap : PageModel
    {
        [BindProperty]
        public required List<EntityEnemy> entities { get; set; }
        public int waveNumber { get; set; }
        int hight = 1080;
        int width = 1920;
      

        public void OnPost()
        {

        }
        public void OnGet() {
			waveNumber = 900;
			spawn();
            
        }
        public IActionResult OnGetWindowSize(String myData)
        {
            String[] tmp = myData.Split(',');
            tmp[0].Remove(0 - 7);
            hight = Int32.Parse(tmp[0]);
            tmp[1].Remove(0 - 6);
            width = Int32.Parse(tmp[1]);
            return new JsonResult(new {});
        }
        public void Game()
        {
            var timer = new System.Timers.Timer();
            timer.Interval = 1000;
        }

        public void spawn() {
            entities = new List<EntityEnemy>();
            Random random = new Random();
            int amountEnemy = random.Next(waveNumber, waveNumber+2);
            for (int i = 0; i <= amountEnemy; i++) {
				entities.Add(new EntityEnemy());
                entities.ElementAt(i).Id = i;
                entities.ElementAt(i).y = random.Next(-100, hight+100);
				entities.ElementAt(i).x = random.Next(-100, width+100);
                
			}
            
        }
    }
}