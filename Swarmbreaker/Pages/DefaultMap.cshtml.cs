using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Swarmbreaker.Cs_Files;

namespace Swarmbreaker.Pages
{
    public class DefaultMap : PageModel
    {
        [BindProperty]
        public List<EntityEnemy> entities { get; set; }



		public void OnGet() {
            entities = new List<EntityEnemy>();
            for (int i = 0; i < 10; i++) {
				entities.Add(new EntityEnemy());
			}
            
        }
    }
}