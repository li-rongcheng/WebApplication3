using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp3RazorPages.Pages.Path1
{
    public class Page2Model : PageModel
    {
        public void OnGet(string param1, string param2)
        {
            Console.WriteLine($"{nameof(Page2Model)} :> param1 = {param1}; param2 = {param2}");
        }
    }
}