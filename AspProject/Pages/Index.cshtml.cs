using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspProject.Data;

namespace AspProject.Pages
{
    
    public class IndexModel : PageModel
    {
        private Data.ApplicationDbContext _context;
        //private readonly ApplicationDbContext _context;


        private readonly ILogger<IndexModel> _logger;


        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
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
            //pro = _context.Products.ToList();

        }
    }
}
