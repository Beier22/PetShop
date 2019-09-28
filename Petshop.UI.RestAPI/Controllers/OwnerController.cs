using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ownerShop.Core.AppServices;
using PetShop.Core.AppServices.Implementation;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;
using PetShop.Infrastructure.SQLData.Repositories;

namespace Petshop.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        IOwnerService serv;

        public OwnerController(IOwnerService serv)
        {
            this.serv = serv;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return serv.GetAllOwners();
        }

        [HttpGet("{id}")]
        public ActionResult<Owner> GetById(int id)
        {
            return serv.ReadById(id);
        }

        [HttpPost]
        public void Post([FromBody] Owner owner)
        {
            serv.CreateOwner(owner);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Owner owner)
        {
            owner.Id = id;
            serv.UpdateOwner(owner);
        }
    }
}