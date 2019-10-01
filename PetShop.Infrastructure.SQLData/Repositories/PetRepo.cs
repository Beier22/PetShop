using PetShop.Core.DomainServices;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.SQLData.Repositories
{
    public class PetRepo : IPetRepo
    {
        PetShopContext _ctx;

        public PetRepo(PetShopContext context)
        {
            _ctx = context;
        }
        public Pet AddPet(Pet pet)
        {
            //pet.Id = DbInitializer.GetNextPetId();
            pet.Id = 0;
            _ctx.Add(pet);
            _ctx.SaveChanges();
            return pet;
        }

        public Pet DeletePet(int id)
        {
            var entity = _ctx.Remove(new Pet() { Id = id });
            _ctx.SaveChanges();
            return entity.Entity;
        }

        public List<Pet> GetAllPets()
        {
            return _ctx.Pets.ToList();
        }

        public Pet ReadById(int id)
        {
            var entityEntry = _ctx.Pets.Where(pet => pet.Id == id);
            _ctx.SaveChanges();
            return entityEntry.FirstOrDefault();
        }

        public Pet UpdatePet(Pet pet)
        {
            var entityEntry = _ctx.Update(pet);
            _ctx.SaveChanges();
            return entityEntry.Entity;
        }
    }
}
