using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Entity;

namespace PetShop.UI.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return new List<Pet>
            {
                new Pet()
                {
                    Name = "Bobby",
                    Type = "Dog",
                    Price = 10000
                },

                new Pet()
                {
                    Name = "Tomato",
                    Type = "Cucumber",
                    Price = 1000000
                }
            };
        }
    }
}