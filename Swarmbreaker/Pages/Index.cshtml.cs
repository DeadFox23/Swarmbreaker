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
			weapons.Add("MP");
			weapons.Add("Baum");
			weapons.Add("");
        }

		public int randomIndex()
		{
            var random = new Random();
			index = random.Next(stats.Count);
			return index;
		}
        public int randomBool()
        {
            var random = new Random();
            weapon = random.NextInt(0,1);
            return index;
        }


        public void OnGet()
		{

		}
	}
}
