using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;
using System;

namespace Swarmbreaker.Pages
{
	public class IndexModel : PageModel
	{
		[BindProperty]
		public List<string> stats { get; set; }
        [BindProperty]
        public List<string> weapons { get; set; }
        [BindProperty]
		public int index { get; set; }
        public int weapon { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
		{
			stats = new List<string>();
			stats.Add("HP");
			stats.Add("Damage");
			stats.Add("Armor");

            weapons = new List<string>();
			weapons.Add("Slingshot");
			weapons.Add("Baum");
			weapons.Add("Knife");
			weapons.Add("Axe");
			weapons.Add("Bow");
        }

		public int randomIndex(int list)
		{
            var random = new Random();
			if(list == 1)
				index = random.Next(stats.Count);
			else
                index = random.Next(weapons.Count);
            return index;
		}
        public int randomBool()
        {
            var random = new Random();
            weapon = random.Next(4);
            return weapon;
        }


        public void OnGet()
		{

		}




        public IActionResult GetPopupData()
        {
            var popupData = new
            {
                title = "New Level up",
                items = new List<object>
        {
            new { name = "Weapon 1" },
            new { name = "Weapon 2" },
            new { name = "Stat 1" }
        }
            };
            return new JsonResult(popupData);
        }
    }
}
