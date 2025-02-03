using Domain.OperationCategory.Entity;
using Domain.OperationCategory.Service;
using ItDevRisk.Helpers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItDevRisk.Actions
{
    public class MainActions
    {
        private readonly ILogger<MainActions> _logger;
        private readonly IOperationCategoryService _operationCategoryService;

        public MainActions(ILogger<MainActions> logger,
            IOperationCategoryService operationCategoryService)
        {
            _logger = logger;
            _operationCategoryService = operationCategoryService;
        }
        public async Task ExecuteAsync()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("=== Menu ===");
                Console.WriteLine("1. Categorizar Operações");
                Console.WriteLine("2. Gerenciar Categorias");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        var categorize = new CategorizeAction(_operationCategoryService);
                        await categorize.CategorizeOperation();
                        break;
                    case "2":
                        Console.WriteLine("You selected Option 2.");
                        break;
                    case "3":
                        isRunning = false;
                        Console.WriteLine("Exiting application...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }

                if (isRunning)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }

                Console.CancelKeyPress += (sender, e) =>
                {
                    e.Cancel = true;
                    Console.WriteLine("\nApplication interrupted. Exiting...");
                    Environment.Exit(0);
                };

            }

        }
    }


}
