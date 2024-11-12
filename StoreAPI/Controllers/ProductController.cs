using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Model.Context;
using StoreAPI.Model.Entity;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDBContext _dbContext;

        public ProductController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GETALL - Hamisin getir
        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _dbContext.Products.ToList();
            return Ok(values);
        }

        //CREATE - Bazaya elave etmek
        [HttpPost]
        public IActionResult ProductAdd(Product p)
        {
            string answer = "Product add DB";

            _dbContext.Products.Add(p);
            _dbContext.SaveChanges();
            return Ok(answer);
        }

        //GETBYID - id sine gore getirmek
        [HttpGet("{id}")]
        public IActionResult ProductGetId(int id)
        {
            var values = _dbContext.Products.Find(id);
            return Ok(values);
        }

        //UPDATE - Bazaya redakte etmek
        [HttpPut]
        public IActionResult ProductUpdate(Product p)
        {
            string answer = "Product update DB";

            _dbContext.Products.Update(p);
            _dbContext.SaveChanges();
            return Ok(answer);
        }

        //DELETE - Bayadan silmek
        [HttpDelete("{id}")]
        public IActionResult ProductDelete(int id)
        {
            string answer = "Product delete DB";

            var values = _dbContext.Products.Find(id);
            _dbContext.Remove(values);
            _dbContext.SaveChanges();
            return Ok(answer);
        }
    }
}
