using PetShop.Core.DomainServices;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.SQLData.Repositories
{
    public class OwnerRepo : IOwnerRepo
    {
        PetShopContext _ctx;

        public OwnerRepo(PetShopContext context)
        {
            _ctx = context;
        }

        public Owner AddOwner(Owner owner)
        {
            var entityEntry = _ctx.Owners.Add(owner);
            _ctx.SaveChanges();
            return entityEntry.Entity;
        }

        public Owner DeleteOwner(int id)
        {
            Owner owner = _ctx.Owners.Where(o => o.Id == id).FirstOrDefault();
            var entityEntry = _ctx.Owners.Remove(owner);
            _ctx.SaveChanges();
            return entityEntry.Entity;
        }

        public List<Owner> GetAllOwners()
        {
            return _ctx.Owners.ToList();
        }

        public Owner ReadById(int id)
        {
            Owner owner = _ctx.Owners.Where(o => o.Id == id).FirstOrDefault();
            return owner;
        }

        public Owner UpdateOwner(Owner owner)
        {
            var entityEntry = _ctx.Update(owner);
            _ctx.SaveChanges();
            return entityEntry.Entity;
        }
    }
}
