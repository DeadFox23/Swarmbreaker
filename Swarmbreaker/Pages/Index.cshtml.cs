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
		public int index { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
		{
			stats = new List<string>();
			stats.Add("HP");
			stats.Add("Damage");
			stats.Add("Armor");
        }

		public int randomNum()
		{
            var random = new Random();
			index = random.Next(stats.Count);
			return index;
		}

		public void OnGet()
		{

		}
	}
}
