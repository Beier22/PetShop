using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.SQLData
{
    public static class DbInitializer
    {
        private static int id = 1;
        private static int oid = 1;
        public static void Seed(PetShopContext context)
        {
            List<Pet> pets = new List<Pet>();
            List<Owner> owners = new List<Owner>();

            
            Owner o1 = new Owner
            {
                Id = oid++,
                Name = "Johnny"
            };

            Owner o2 = new Owner
            {
                Id = oid++,
                Name = "Suzy"
            };

            Owner o3 = new Owner
            {
                Id = oid++,
                Name = "James"
            };

            Owner o4 = new Owner()
            {
                Id = oid++,
                Name = "Jack, the Savage"
            };

            Owner o5 = new Owner()
            {
                Id = oid++,
                Name = "Bob"
            };



            owners.Add(o1);
            owners.Add(o2);
            owners.Add(o3);

            Pet p1 = new Pet
            {
                Id = id++,
                Type = "Dog",
                Name = "Bubz",
                Color = "Black",
                Birthday = new DateTime(2016, 4, 20),
                PreviousOwner = o1,
                Price = 15000
            };

            Pet p2 = new Pet
            {
                Id = id++,
                Type = "Parrot",
                Name = "Joe",
                Color = "Red, blue & yellow",
                Birthday = new DateTime(2013, 8, 17),
                PreviousOwner = o2,
                Price = 12000
            };

            Pet p3 = new Pet
            {
                Id = id++,
                Type = "Dog",
                Name = "Fluffy",
                Color = "White",
                Birthday = new DateTime(2018, 1, 19),
                PreviousOwner = o3,
                Price = 20000
            };

            Pet p4 = new Pet
            {
                Id = id++,
                Type = "Cat",
                Name = "Whiskers",
                Color = "White & black",
                Birthday = new DateTime(2012, 10, 12),
                PreviousOwner = o4,
                Price = 8000
            };

            Pet p5 = new Pet
            {
                Id = id++,
                Type = "Turtle",
                Name = "Leonardo",
                Color = "Green",
                Birthday = new DateTime(2008, 12, 01),
                PreviousOwner = o5,
                Price = 25000
            };

            pets.Add(p1);
            pets.Add(p2);
            pets.Add(p3);
            pets.Add(p4);
            pets.Add(p5);

            context.Pets.AddRange(pets);
            context.Owners.AddRange(owners);
            context.SaveChanges();

            
        }
        public static int GetNextPetId()
        {
            return id++;
        }
    }
}
