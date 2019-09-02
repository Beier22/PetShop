using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;

namespace PetShop.Core.AppServices.Implementation
{
    public class PetService: IPetService
    {
        private IPetRepo repo;

        public PetService(IPetRepo repo)
        {
            this.repo = repo;
        }

        public void CreatePet(Pet pet)
        {
            repo.AddPet(pet);
        }

        public void DeletePet(Pet pet)
        {
            repo.DeletePet(pet.Id);
        }

        public List<Pet> GetAllPets()
        {
            List<Pet> pets = repo.GetAllPets().ToList();
            return pets;
        }

        public List<Pet> OrderByPrice()
        {
            return repo.GetAllPets().OrderBy(pet => pet.Price).ToList();
        }

        public List<Pet> SearchType(string search)
        {
            List<Pet> pets = repo.GetAllPets().Where(pet => pet.Type.ToLower().Contains(search.ToLower())).ToList();
            return pets;
        }

        public void SellPet(Pet pet)
        {
            pet.SoldDate = DateTime.Now;
            repo.UpdatePet(pet);
        }

        public void UpdatePet(Pet pet)
        {
            repo.UpdatePet(pet);
        }

        public int VerifyNumber(List<Pet> list, string input)
        {
            if (input == "")
                return -1;

            int num;
            if (int.TryParse(input, out num) && num > 0 && num <= list.Count)
            {
                return num;
            }

            return 0;
        }
    }
}
