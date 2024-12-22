using System;
using System.Collections.Generic;

namespace MaterialTrackingSystem
{
    public class ReportGenerator
    {
        public void GenerateStockReport(List<Material> materials)
        {
            Console.WriteLine("\nОтчет об остатках материалов:");
            foreach (var material in materials)
            {
                Console.WriteLine($"Материал: {material.Name}, Количество: {material.Quantity}, Минимальный остаток: {material.MinQuantity}");
            }
        }
    }
}