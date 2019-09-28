using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.AppServices;
using PetShop.Core.AppServices.Implementation;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;
using PetShop.Infrastructure.SQLData;
using PetShop.Infrastructure.SQLData.Repositories;

namespace Petshop.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        IPetService serv;

        public PetsController(IPetService serv)
        {
            this.serv = serv;
        }
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return serv.GetAllPets();
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> GetById(int id)
        {
            return serv.ReadById(id);
        }

        [HttpPost]
        public void Post([FromBody] Pet pet)
        {
            serv.CreatePet(pet);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pet pet)
        {
            pet.Id = id;
            serv.UpdatePet(pet);
        }
    }
}