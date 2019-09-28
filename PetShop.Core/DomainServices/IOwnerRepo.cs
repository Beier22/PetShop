using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainServices
{
    public interface IOwnerRepo
    {
        //Create
        Owner AddOwner(Owner owner);

        //Read
        List<Owner> GetAllOwners();
        Owner ReadById(int id);

        //Update
        Owner UpdateOwner(Owner owner);

        //Delete
        Owner DeleteOwner(int id);
    }
}
