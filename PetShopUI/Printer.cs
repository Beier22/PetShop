using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using PetShop.Core.AppServices;
using PetShop.Core.AppServices.Implementation;
using PetShop.Core.DomainServices;
using PetShop.Core.Entity;
using PetShop.Infrastructure;

namespace PetShopUI
{
    public class Printer: IPrinter
    {
        private IPetService service;

        public Printer(IPetService service)
        {
            this.service = service;
            FakeDB.SamplePets();
        }

        public void StartUI()
        {
            ConsoleKey key = ConsoleKey.A;
            while (key != ConsoleKey.Escape)
            {
                Console.WriteLine("What would you like to do?\n" +
                                  "1. List all pets\n" +
                                  "2. Search by type\n" +
                                  "3. Create new pet\n" +
                                  "4. Delete a pet\n" +
                                  "5. Update a pet\n" +
                                  "6. Sort pets by price\n" +
                                  "7. See the 5 cheapest pets\n" +
                                  "Esc. Exit program\n" +
                                  "To select, please press the corresponding key");
                key = Console.ReadKey().Key;
                Console.Clear();
                switch (key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("List of all pets:");
                        ListPets(service.GetAllPets());
                        Console.WriteLine("Enter a number to see more info about a pet:");
                        DisplayPetInfo(service.GetAllPets());
                        break;
                    case ConsoleKey.D2:
                        Search();
                        break;
                    case ConsoleKey.D3:
                        CreatePet();
                        break;
                    case ConsoleKey.D4:
                        DeletePet();
                        break;
                    case ConsoleKey.D5:
                        UpdatePet();
                        break;
                    case ConsoleKey.D6:
                        OrderByPrice();
                        break;
                    case ConsoleKey.D7:
                        DisplayCheapest();
                        break;
                    case ConsoleKey.D8:
                        SellPet();
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine(">Exiting program");
                        break;
                    default:
                        Console.WriteLine("Key unrecognized");
                        break;

                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ListPets(List<Pet> list)
        {
            int i = 1;

            foreach (Pet p in list)
            {
                Console.WriteLine(i++ + ". Type: " + p.Type + ", Name: " + p.Name + ", Price: " + p.Price);
            }


        }

        private void Search()
        {
            Console.WriteLine("Please enter search word:");
            List<Pet> pets = service.SearchType(Console.ReadLine());
            if (pets.Count == 0)
            {
                Console.WriteLine("No pets found");
                return;
            }
            ListPets(pets);
            Console.WriteLine("Enter a number to see more info about a pet");
            DisplayPetInfo(pets);
        }

        private Pet DisplayPetInfo(List<Pet> pets)
        {
            Console.WriteLine("Press enter with no input to cancel");
            int num = 0;
            while (num == 0)
            {
                num = service.VerifyNumber(pets, Console.ReadLine());
                if (num == 0)
                {
                    Console.WriteLine("Invalid. Try again");
                } else if (num == -1)
                {
                    Console.WriteLine("Cancelled and exiting");
                    return null;
                }
            }

            Pet pet = pets[num - 1];
            Console.WriteLine("Name: " + pet.Name + 
                              "\nType: " + pet.Type +
                              "\nBirthday: " + pet.Birthday.ToLongDateString() +
                              "\nPrice: " + pet.Price);
            return pet;
        }

        public void CreatePet()
        {
            Console.WriteLine("Creating pet!");
            Pet pet = new Pet();
            InputPetInfo(pet);
            service.CreatePet(pet);
            
        }

        private Pet InputPetInfo(Pet pet)
        {
            Console.WriteLine("Please fill out the following information:");
            Console.WriteLine("Name: ");
            pet.Name = Console.ReadLine();
            Console.WriteLine("Type: ");
            pet.Type = Console.ReadLine();
            Console.WriteLine("Color: ");
            pet.Color = Console.ReadLine();
            Console.WriteLine("Birthday (YYYY-MM-DD): ");
            DateTime bd;
            while (!DateTime.TryParse(Console.ReadLine(), out bd))
            {
                Console.WriteLine("Date unrecognized, try again. Make sure it's in the format YYYY-MM-DD (only numbers and including dashes)");
            }
            Console.WriteLine("Price: ");
            int price;
            while (!int.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Not a number, try again");
            }

            pet.Price = price;
            Console.WriteLine("Previous owner: ");
            pet.PreviousOwner = Console.ReadLine();
            return pet;
        }

        public void UpdatePet()
        {
            List<Pet> pets = service.GetAllPets();
            Console.WriteLine("Select pet to update:");
            ListPets(pets);
            Pet pet = DisplayPetInfo(pets);
            Console.WriteLine("Updating pet!");
            InputPetInfo(pet);
            service.UpdatePet(pet);

        }

        public void DeletePet()
        {
            List<Pet> pets = service.GetAllPets();
            Console.WriteLine("Select pet to delete");
            ListPets(pets);
            Pet pet = DisplayPetInfo(pets);
            service.DeletePet(pet);
            Console.WriteLine("Pet has been deleted");
        }

        private void OrderByPrice()
        {
            List<Pet> pets = service.OrderByPrice();
            ListPets(pets);
            Console.WriteLine("Select pet to see more info");
            DisplayPetInfo(pets);
        }

        private void DisplayCheapest()
        {

            List<Pet> pets = service.OrderByPrice();
            if (pets.Count > 5)
            {
                pets = pets.GetRange(0, 5);
            }
            else
            {
                pets = pets.GetRange(0, pets.Count);
            }
            ListPets(pets);
            Console.WriteLine("Select pet to see more info");
            DisplayPetInfo(pets);
        }

        private void SellPet()
        {
            List<Pet> pets = service.GetAllPets();
            Console.WriteLine("Please choose pet to sell");
            ListPets(pets);
            Pet pet = DisplayPetInfo(pets);
            Console.WriteLine("Pet sold");

        }
    }
}
