using AspProject.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspProject.Controllers
{
    
    [Route("Products/[controller]")]
   //[ApiController]
    public class ProductsController : ControllerBase
    {
        private Data.ApplicationDbContext _context;

        public ProductsController(Data.ApplicationDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            try
            {
                var list = _context.Products.ToList();
                return Ok(list);
            }
            catch (Exception er)
            {
                return BadRequest("Get all products has been faild");
            }
        }

        //[HttpPost]
        //[Route("GetProduct")]
        //public IActionResult GetProduct()
        //{
            
        //    var data = _context.Products.ToList();
        //    var recordsTotal = data.Count();
        //    var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data };
        //    return Ok(jsonData);
        //}



        [Authorize(policy: "AdminPolicy")]
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddProducts(Products products)
        {
            if (ModelState.IsValid)
            {
                //var existingUser = _context.Products.Where(p => p.ProductName.Equals(products.ProductName)).ToList();
                //if (existingUser != null && existingUser.Count > 0)
                //{
                //    return BadRequest("Products alredy exists");
                //}
                try
                {
                    await _context.Products.AddAsync(products);
                    _context.SaveChanges();
                    return Ok(products);
                }
                catch (Exception)
                {
                    return BadRequest("Add Products has been faild");
                }
                
            }
            return BadRequest("Invalid payload");
        }
        [Authorize(policy: "AdminPolicy")]
        [HttpPost("Edit")]
        public async Task<IActionResult> UpdateProduct(Products prod)
        {
            if (!ModelState.IsValid)
              return BadRequest("Cant Update");
             _context.Products.Update(prod);
            _context.SaveChanges();
            return Ok();
        }
        [Authorize(policy: "DeletePolicy")]
        [HttpGet("Delete")]
        public IActionResult Delete(int Id)
        {
            var data = _context.Products.Where(x=>x.Id==Id).FirstOrDefault();
            _context.Products.Remove(data);
            _context.SaveChanges();
            return Ok(data);
        }
    } 
}
