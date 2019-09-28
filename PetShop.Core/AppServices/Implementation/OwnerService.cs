using ownerShop.Core.AppServices;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Core.AppServices.Implementation
{
    public class OwnerService: IOwnerService
    {
        private IOwnerRepo repo;

        public OwnerService(IOwnerRepo repo)
        {
            this.repo = repo;
        }

        public void CreateOwner(Owner owner)
        {
            repo.AddOwner(owner);
        }

        public void DeleteOwner(Owner owner)
        {
            repo.DeleteOwner(owner.Id);
        }

        public List<Owner> GetAllOwners()
        {
            List<Owner> owners = repo.GetAllOwners().ToList();
            return owners;
        }

        public Owner ReadById(int id)
        {
            return repo.ReadById(id);
        }

        public List<Owner> SearchType(string search)
        {
            List<Owner> owners = repo.GetAllOwners().Where(owner => owner.Name.ToLower().Contains(search.ToLower())).ToList();
            return owners;
        }

        public void UpdateOwner(Owner owner)
        {
            repo.UpdateOwner(owner);
        }

        public int VerifyNumber(List<Owner> list, string input)
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
