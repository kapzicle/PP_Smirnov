using System;

namespace MaterialTrackingSystem
{
    public class Material
    {
        public int MaterialID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; private set; }
        public int MinQuantity { get; set; }

        public Material(int materialID, string name, int quantity, int minQuantity)
        {
            MaterialID = materialID;
            Name = name;
            Quantity = quantity;
            MinQuantity = minQuantity;
        }

        public void AddStock(int quantity)
        {
            Quantity += quantity;
            Console.WriteLine($"Добавлено {quantity} единиц материала {Name}. Текущее количество: {Quantity}.");
        }

        public void RemoveStock(int quantity)
        {
            if (Quantity >= quantity)
            {
                Quantity -= quantity;
                Console.WriteLine($"Списано {quantity} единиц материала {Name}. Текущее количество: {Quantity}.");
            }
            else
            {
                Console.WriteLine($"Недостаточно материала {Name} для списания {quantity} единиц.");
            }
        }

        public bool IsBelowMinimum()
        {
            return Quantity < MinQuantity;
        }
    }
}