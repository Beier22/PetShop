using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.DomainServices
{
    public interface IPetRepo
    {
        #region CRUD

        //Create
        Pet AddPet(Pet pet);

        //Read
        IEnumerable<Pet> GetAllPets();
        Pet ReadById(int id);

        //Update
        Pet UpdatePet(Pet pet);

        //Delete
        bool DeletePet(int id);

        #endregion

    }
}
