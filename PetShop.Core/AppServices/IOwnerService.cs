using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ownerShop.Core.AppServices
{
    public interface IOwnerService
    {
        List<Owner> GetAllOwners();
        List<Owner> SearchType(string search);
        int VerifyNumber(List<Owner> list, string num);
        void CreateOwner(Owner owner);
        void UpdateOwner(Owner owner);
        void DeleteOwner(Owner owner);
        Owner ReadById(int id);
    }
}
