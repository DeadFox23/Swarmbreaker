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


		public void OnGet() {
			waveNumber = 20;
			spawn();
            
        }
        public void spawn() {
            entities = new List<EntityEnemy>();
            Random random = new Random();
            int y = random.Next(1, waveNumber+2);
            for (int i = 0; i <= y; i++) {
				entities.Add(new EntityEnemy());
                entities.ElementAt(i).Id = i;
                entities.ElementAt(i).y = random.Next(-100, 200);
				entities.ElementAt(i).x = random.Next(-100, 200);
                
			}
            
        }
    }
}