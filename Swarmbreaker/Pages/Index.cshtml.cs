using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;
using System;
using System.Text.RegularExpressions;

namespace Swarmbreaker.Pages
{
	public class IndexModel : PageModel
	{

		public IndexModel(ILogger<IndexModel> logger)
		{

		}


		public void OnGet()
		{

		}

		public JsonResult OnGetPlayerStats(String data)
        {
            Console.WriteLine(data);

            return new JsonResult(new { test="test" });
        }
    }
}
