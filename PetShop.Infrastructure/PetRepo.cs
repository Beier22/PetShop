using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure
{
    public class PetRepo//: IPetRepo
    {
        /*
        private List<Pet> _pets = FakeDB.GetPets();
        public Pet AddPet(Pet pet)
        {
            pet.Id = FakeDB.GetNextPetID();
            _pets.Add(pet);
            return pet;
        }

        public List<Pet> GetAllPets()
        {
            
            return _pets;
        }

        public Pet ReadById(int id)
        {
            foreach (Pet pet in _pets)
            {
                if (pet.Id == id)
                    return pet;
            }

            return null;
        }

        public Pet UpdatePet(Pet pet)
        {
            Pet petToUpdate = ReadById(pet.Id);
            if (petToUpdate != null)
            {
                petToUpdate.Name = pet.Name;
                petToUpdate.Price = pet.Price;
                petToUpdate.Type = pet.Type;
                petToUpdate.Birthday = pet.Birthday;
                petToUpdate.Color = pet.Color;
                petToUpdate.PreviousOwner = pet.PreviousOwner;
                petToUpdate.SoldDate = pet.SoldDate;
                return petToUpdate;
            }

            return null;

        }

        public Pet DeletePet(int id)
        {
            Pet pet = ReadById(id);
            if (pet != null)
            {
                _pets.Remove(pet);
                return pet;
            }

            return pet;
        }*/

        
    }
}
