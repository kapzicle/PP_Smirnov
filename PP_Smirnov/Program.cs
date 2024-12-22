using System;
using System.Collections.Generic;

namespace MaterialTrackingSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Инициализация материалов
            var materials = new List<Material>
            {
                new Material(1, "Дерево", 50, 20),
                new Material(2, "Краска", 30, 10)
            };

            var operations = new List<Operation>();
            var notification = new Notification();
            var reportGenerator = new ReportGenerator();
            int operationID = 1;

            Console.WriteLine("Добро пожаловать в систему учета материалов!");

            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Показать отчет об остатках материалов");
                Console.WriteLine("2. Зарегистрировать расход материала");
                Console.WriteLine("3. Выйти из программы");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            reportGenerator.GenerateStockReport(materials);
                            break;

                        case "2":
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("\nДоступные материалы:");
                                    foreach (var material in materials)
                                    {
                                        Console.WriteLine($"ID: {material.MaterialID}, Название: {material.Name}, Остаток: {material.Quantity}");
                                    }

                                    Console.Write("\nВведите ID материала (или 0 для возврата в меню): ");
                                    int materialID = int.Parse(Console.ReadLine());

                                    if (materialID == 0) break;

                                    var selectedMaterial = materials.Find(m => m.MaterialID == materialID);
                                    if (selectedMaterial == null)
                                    {
                                        Console.WriteLine("Материал с таким ID не найден. Попробуйте снова.");
                                        continue;
                                    }

                                    Console.Write($"Введите количество израсходованного материала ({selectedMaterial.Name}): ");
                                    int quantityUsed = int.Parse(Console.ReadLine());

                                    if (quantityUsed > selectedMaterial.Quantity)
                                    {
                                        Console.WriteLine("Недостаточно материала для списания. Попробуйте снова.");
                                    }
                                    else
                                    {
                                        selectedMaterial.RemoveStock(quantityUsed);
                                        operations.Add(new Operation(operationID++, materialID, quantityUsed, DateTime.Now));

                                        if (selectedMaterial.IsBelowMinimum())
                                        {
                                            notification.SendNotification($"Материал {selectedMaterial.Name} ниже минимального остатка!");
                                        }
                                        Console.WriteLine("Расход материала успешно зарегистрирован.");
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Ошибка: ввод должен быть числом. Попробуйте снова.");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                                }
                            }
                            break;

                        case "3":
                            Console.WriteLine("Выход из программы.");
                            return;

                        default:
                            Console.WriteLine("Неверный выбор, попробуйте снова.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
                }
            }
        }
    }
}