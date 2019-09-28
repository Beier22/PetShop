using System;
using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.AppServices;
using PetShop.Core.AppServices.Implementation;
using PetShop.Core.DomainServices;
using PetShop.Infrastructure;

namespace PetShopUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, and welcome to the pet shop!");
            
            var serviceCollection = new ServiceCollection();
            //serviceCollection.AddScoped<IPetRepo, PetRepo>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPrinter, Printer>();
            

            ////then build provider 
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.StartUI();
        }

    }
}
