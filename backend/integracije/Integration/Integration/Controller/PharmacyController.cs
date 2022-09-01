using Integration.Model;
using Integration.Repository;
using Integration.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class PharmacyController: ControllerBase
    {
        private readonly MyDbContext context;
        public PharmacyService ps;
        public PharmacyController(MyDbContext context)
        {
            this.context = context;
            ps = new PharmacyService(new PharmacySqlRepository(context));
        }

        [HttpPost("/takeRecipe")]
        public IActionResult TakeRecipe([FromBody] int id)
        {
            Console.WriteLine(id);
            Console.WriteLine("ne radi");
            Recipe rr = ps.GetRecipes(id);
            //Recipe r = new Recipe(recipe.IdR, recipe.Medicine, recipe.Quantity, recipe.Instructions);
            Console.WriteLine(rr.Quantity);
            Console.WriteLine(rr.Medicine);
            if (ps.CheckRecipe(rr) == true)
            {
                return Ok();
            }
            else
            {
                Console.WriteLine("nije bad request");
                return BadRequest();
            }
        }
    }
}
