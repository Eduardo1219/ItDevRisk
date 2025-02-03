using Domain.OperationCategory.Entity;
using Domain.OperationCategory.Entity.Enum;
using Domain.OperationCategory.Service;
using ItDevRisk.Actions.Dtos;
using ItDevRisk.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItDevRisk.Actions
{
    public class CategorizeAction
    {
        private readonly IOperationCategoryService _operationCategoryService;

        public CategorizeAction(IOperationCategoryService operationCategoryService)
        {
            _operationCategoryService = operationCategoryService;
        }

        public async Task CategorizeOperation()
        {
            Console.Clear();
            var categories = await GetCategoryEntities();
            Console.Clear();
            if (!categories.Any())
            {
                Console.WriteLine("Any category was found in the database. Please, register a category first to turn possible the categorization of operations.");
                return;
            }

            Console.WriteLine("======= Categorizar operações =========");
            Console.Write("Inform the referential date: ");
            var referenceDate = GetValidDateInput();
            Console.Write("Inform the operations quantity: ");
            var operationsQnt = GetValidIntNumberInput();
            var operations = GetCategoriesInformation(operationsQnt);
            await GetOperationCategoryName(referenceDate, operations, categories);
        }

        public async Task GetOperationCategoryName(DateTime referenceDate, List<OperationInputDto> operations, List<OperationCategoryEntity> categories)
        {
            categories = categories.OrderBy(c => c.PriorityLevel).ToList();
            for (int i = 0; i < operations.Count; i++)
            {
                bool categoryNotExist = true;
                foreach (var category in categories)
                {
                    if (operations[i].Sector == category.Sector || category.Sector == SectorEnum.AnySector)
                    {
                        bool isOperationCategory = category.ValidateOperation(referenceDate, operations[i].NextPaymentDate, operations[i].NegotiatedValue);
                        if (isOperationCategory)
                        {
                            Console.WriteLine($"Operation {i + 1}: {category.Name.ToUpper()}");
                            categoryNotExist = false;
                            break;
                        }
                    }
                }
                if(categoryNotExist) Console.WriteLine($"Operation {i + 1}: Category not found");
            }
        }

        public async Task<List<OperationCategoryEntity>> GetCategoryEntities()
        {
            return await _operationCategoryService.GetAllCategories();
        }

        public List<OperationInputDto> GetCategoriesInformation(int operationsQnt)
        {
            var categories = new List<OperationInputDto>();
            Console.WriteLine("Inform the operation values separated by white space: ");
            for (int i = 0; i < operationsQnt; i++)
            {
                var askForOperation = true;
                do
                {
                    Console.Write($"Operation {i + 1}: ");
                    var operation = Console.ReadLine();
                    if (string.IsNullOrEmpty(operation))
                    {
                        Console.WriteLine("operations values are required!");
                        WriteTraceLine();
                        continue;
                    }
                    var operationValues = operation.Split(" ");

                    if (operationValues.Length != 3)
                    {
                        Console.WriteLine("operations values are invalid. Please check the values informed.");
                        WriteTraceLine();
                        continue;
                    }

                    var (isValidDecimalInpt, decimNumbFormated) = operationValues[0].TryParseValidDecimal();
                    var (isValidSectorInpt, sectorFormated) = operationValues[1].GetValueFromDescription<SectorEnum>();
                    var (isValidDateInpt, dateFormated) = operationValues[2].TryParseValidDate();
                    if (!isValidDecimalInpt)
                    {
                        Console.WriteLine("negotiated value informed is invalid!. Please check the value informed.");
                        WriteTraceLine();
                        continue;
                    }


                    if (!isValidSectorInpt)
                    {
                        Console.WriteLine("sector informed is invalid!. Please check the value informed.");
                        WriteTraceLine();
                        continue;
                    }


                    if (!isValidDateInpt)
                    {
                        Console.WriteLine("date informed is invalid!. Please check the value informed.");
                        WriteTraceLine();
                        continue;
                    }
                    askForOperation = false;
                    categories.Add(new OperationInputDto(decimNumbFormated, sectorFormated, dateFormated));
                } while (askForOperation);

            }

            return categories;
        }

        public int GetValidIntNumberInput()
        {
            var askForInput = true;
            var numberInpt = 0;

            do
            {
                var referenceDateInpt = Console.ReadLine();
                if (string.IsNullOrEmpty(referenceDateInpt))
                {
                    Console.WriteLine("É obrigatório informar uma quantidade!");
                    continue;
                }
                var (isValidInpt, intNumbFormated) = referenceDateInpt.TryParseValidInt();

                if (!isValidInpt || intNumbFormated <= 0)
                {
                    Console.WriteLine("Número informado invalido!");
                    Console.WriteLine("Exemplos de números válidos: 1, 2");
                    WriteTraceLine();
                    continue;
                }

                askForInput = false;
                numberInpt = intNumbFormated;
            } while (askForInput);
            return numberInpt;
        }

        public decimal GetValidDecimalNumberInput()
        {
            var askForInput = true;
            var numberInpt = decimal.MinValue;

            do
            {
                var referenceDateInpt = Console.ReadLine();
                if (string.IsNullOrEmpty(referenceDateInpt))
                {
                    Console.WriteLine("É obrigatório informar uma quantidade!");
                    continue;
                }
                var (isValidInpt, decimNumbFormated) = referenceDateInpt.TryParseValidDecimal();

                if (!isValidInpt)
                {
                    Console.WriteLine("Número informado invalido!");
                    Console.WriteLine("Exemplos de números válidos: 1, 2");
                    WriteTraceLine();
                    continue;
                }

                askForInput = false;
                numberInpt = decimNumbFormated;
            } while (askForInput);
            return numberInpt;
        }

        public DateTime GetValidDateInput()
        {
            var askForInput = true;
            var dateInpt = DateTime.UtcNow;

            do
            {
                var referenceDateInpt = Console.ReadLine();
                if (string.IsNullOrEmpty(referenceDateInpt))
                {
                    Console.WriteLine("É obrigatório informar uma data de refêrencia!");
                    continue;
                }
                var (isValidDate, dateFormated) = referenceDateInpt.TryParseValidDate();

                if (!isValidDate)
                {
                    Console.WriteLine("Data informada inválida!");
                    Console.WriteLine("Exemplos de datas válidas: 02/02/2025, 01/01/2024");
                    WriteTraceLine();
                    continue;
                }

                askForInput = false;
                dateInpt = dateFormated;
            } while (askForInput);

            return dateInpt;
        }
        public void WriteTraceLine()
        {
            Console.WriteLine("-----------------------------------------------------");
        }
    }
}
