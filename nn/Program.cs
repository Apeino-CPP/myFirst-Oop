using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true;
            bool reservComplited;
            Table[] tables = { new Table(1, 4), new Table(2, 7), new Table(3, 15) };
            while (isOpen)
            {
                for(int i = 0; i < tables.Length; i++)
                {
                    tables[i].ShowInfo();
                }

                Console.Write("\nВведите имя стола: ");
                int withTable = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Write("\nВведите мест для брони: ");
                int desPlaces = Convert.ToInt32(Console.ReadLine());
                reservComplited = tables[withTable].Reserve(desPlaces);
                if (reservComplited) Console.WriteLine($"Столик под номером {withTable + 1}" +
                    $" Забронированно {desPlaces} мест(a).");
                else Console.WriteLine($"Бронированние места за сттоликом {withTable + 1} не удалось");
                Console.WriteLine("Введите Q для выхода из программы");
                ConsoleKeyInfo exitKey = Console.ReadKey();
                if (exitKey.KeyChar == 'q' || exitKey.KeyChar == 'Q') isOpen = false;

                Console.Clear();
            }
        }
    }
    class Table
    {
        public int Number;
        public int MaxPlaces;
        public int FreePlaces;

        public Table(int number, int maxPlaces)
        {
            Number = number;
            MaxPlaces = maxPlaces;
            FreePlaces = maxPlaces;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"|| Стол: {Number} \t|| Кол-во мест: {MaxPlaces} \t||" 
                + $" Свободно мест: {FreePlaces} \t||");
        }
        public bool Reserve(int places)
        {
            if (FreePlaces >= places)
            {
                FreePlaces -= places;
                return true;
            }
            else return false;
        }
    }
    
}

