using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.AppServices
{
    public interface IPetService
    {
        List<Pet> GetAllPets();
        List<Pet> SearchType(string search);
        int VerifyNumber(List<Pet> list, string num);
        void CreatePet(Pet pet);
        void UpdatePet(Pet pet);
        void DeletePet(Pet pet);
        List<Pet> OrderByPrice();
        void SellPet(Pet pet);
    }
}
