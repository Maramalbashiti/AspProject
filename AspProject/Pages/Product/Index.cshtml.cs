using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace AspProject.Pages.Product
{
    public class IndexModel : PageModel
    {
        private Data.ApplicationDbContext _context;
        public IndexModel(Data.ApplicationDbContext context)
        {
            _context = context; 

        }

        public HtmlString dataasJson { get; set; }
        //public List<Data.Products> pro { get; set;
        //

        public Data.Products pro { get; set; }
        public void OnGet()
        {
            List<Data.Products> list = _context.Products.ToList();
            dataasJson = new HtmlString(System.Text.Json.JsonSerializer.Serialize<List<Data.Products>>(list));
        }
    }
}
