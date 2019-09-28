using PetShop.Core.DomainServices;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure
{
    public class OwnerRepo//: IOwnerRepo
    {
        /*private List<Owner> _owners = FakeDB.GetOwners();
        public Owner AddOwner(Owner owner)
        {
            owner.Id = FakeDB.GetNextPetID();
            _owners.Add(owner);
            return owner;
        }

        public List<Owner> GetAllOwners()
        {

            return _owners;
        }

        public Owner ReadById(int id)
        {
            foreach (Owner owner in _owners)
            {
                if (owner.Id == id)
                    return owner;
            }

            return null;
        }

        public Owner UpdateOwner(Owner owner)
        {
            Owner ownerToUpdate = ReadById(owner.Id);
            if (ownerToUpdate != null)
            {
                ownerToUpdate.Name = owner.Name;
                return ownerToUpdate;
            }

            return null;

        }

        public Owner DeleteOwner(int id)
        {
            Owner owner = ReadById(id);
            if (owner != null)
            {
                _owners.Remove(owner);
                return owner;
            }

            return owner;
        }*/
    }
}
