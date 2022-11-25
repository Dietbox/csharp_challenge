using Dietbox.Interview.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dietbox.Interview.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var service = new ProductService();

            return Ok(service.Get(id));
        }

        [HttpPost]
        [HttpPut("{id}")]
        [HttpDelete("{id}")]
        public IActionResult AdicionarOuAtualizarOuDeletar(int? id, string name, string description, decimal price, bool deletar)
        {
            if (deletar)
            {
                var service = new ProductService();

                service.Delete(id.Value);

                return Ok();
            }
            else
            {
                var service = new ProductService();
                
                if (price < 1 || price > 100) return BadRequest();

                if (id.HasValue)
                {
                    var camisetaVelha = service.Get(id.Value);

                    var a = new Product()
                    {
                        Id = id.Value,
                        Name = camisetaVelha.Name,
                        Description = camisetaVelha.Description,
                        Price = camisetaVelha.Price,
                    };

                    service.Update(a);

                    return Ok();
                }
                else
                {
                    var camisetaNova = new Product()
                    {
                        Id = new Random().Next(100000, 999999),
                        Name = name,
                        Description = description,
                        Price = price
                    };

                    service.Add(camisetaNova);

                    return Ok();
                }
            }
        }
    }
}