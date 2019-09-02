using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.DomainServices;

namespace PetShop.Infrastructure
{
    public class FakeDB
    {
        IPetRepo repo = new PetRepo();
        static List<Pet> pets = new List<Pet>();
        private static int id = 1;
        public static void SamplePets()
        {

            Pet p1 = new Pet
            {
                Id = id++,
                Type = "Dog",
                Name = "Bubz",
                Color = "Black",
                Birthday = new DateTime(2016, 4, 20),
                PreviousOwner = "Bob",
                Price = 15000
            };

            Pet p2 = new Pet
            {
                Id = id++,
                Type = "Parrot",
                Name = "Joe",
                Color = "Red, blue and yellow",
                Birthday = new DateTime(2013, 8, 17),
                PreviousOwner = "Jack, the Savage",
                Price = 12000
            };

            Pet p3 = new Pet
            {
                Id = id++,
                Type = "Dog",
                Name = "Fluffy",
                Color = "White",
                Birthday = new DateTime(2018, 1, 19),
                PreviousOwner = "James",
                Price = 20000
            };

            pets.Add(p1);
            pets.Add(p2);
            pets.Add(p3);
        }

        public static List<Pet> GetPets()
        {
            return pets;
        }

        public static int GetNextPetID()
        {
            return id++;
        }
    }
}
