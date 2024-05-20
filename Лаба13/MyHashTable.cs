using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary2;
using System.Threading.Tasks;
using System.Dynamic;
using System.Xml.Linq;

namespace Лаба13
{
    public class MyHashTable<T> where T : IInit, ICloneable, new()
    {
        public Point<T>?[] table;
        public int Capacity => table.Length;

        //Конструктор
        public MyHashTable() { }
        public MyHashTable(int length)
        {
            table = new Point<T>[length];
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = MakeRandomData();
            }
        }
        public Point<T> MakeRandomData()
        {
            T data = new T();
            data.RandomInit();
            return new Point<T>(data);
        }
        //Печать
        public void PrintTable()
        {
            for (int i = 0; i < table.Length; i++)
            {
                Console.WriteLine($"{i}:");
                if (table[i] != null) //не пустая ссылка
                {
                    Console.WriteLine(table[i].Data);
                    if (table[i].Next != null) //цепочка не пустая
                    {
                        Point<T>? current = table[i].Next; //идём по цепочке
                        while (current != null)
                        {
                            Console.WriteLine(current.Data);
                            current = current.Next;
                        }
                    }
                }
            }
            if (table.Length == 0)
                Console.WriteLine("Таблица пустая!");
            Console.WriteLine();
        }

        public void AddPoint()
        {
            T randomData = new T();
            randomData.RandomInit();

            if (table == null || table.Length == 0)
            {
                table = new Point<T>?[1];
                table[0] = new Point<T>(randomData);
                return;
            }

            int index = GetIndex(randomData);

            // Позиция пустая
            if (table[index] == null)
            {
                table[index] = new Point<T>(randomData);
            }
            else // Есть цепочка
            {
                Point<T>? current = table[index];

                // Проверяем, существует ли уже такой элемент в цепочке
                while (current != null)
                {
                    if (current.Data.Equals(randomData))
                    {
                        Console.WriteLine("Элемент уже существует в цепочке.");
                        return;
                    }
                    current = current.Next;
                }

                // Добавляем новый элемент в конец цепочки
                current = table[index];
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = new Point<T>(randomData);
                current.Next.Pred = current;
            }
        }
        public int GetIndex(T data)
        {
            return Math.Abs(data.GetHashCode()) % Capacity;
        }
        public void FindByName(string name)
        {
            if (table == null || table.Length == 0)
            {
                Console.WriteLine("Таблица пустая.");
                return;
            }

            bool found = false;

            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null)
                {
                    Point<T>? current = table[i];
                    while (current != null)
                    {
                        if (current.Data.Name == name)
                        {
                            Console.WriteLine($"Элемент с именем \"{name}\" найден на позиции {i}.");
                            found = true;
                        }
                        current = current.Next;
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine($"Элемент с именем \"{name}\" не найден.");
            }
            Console.WriteLine();
        }
        public bool Contains(T data)
        {
            int index = GetIndex(data);
            if (table == null)
                Console.WriteLine("Таблица пустая!");
            if (table[index] == null)
                return false;
            if (table[index].Data.Equals(data))//нужный элемент
                return true;
            else
            {
                Point<T>? current = table[index];
                while (current != null)
                {
                    if (current.Data.Equals(data))
                        return true;
                    current = current.Next;
                }
            }
            return false;
        }
        public bool RemoveByName(string name)
        {
            if (table == null || table.Length == 0)
            {
                Console.WriteLine("Таблица пустая!");
                return false;
            }

            bool removed = false;

            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null)
                {
                    Point<T>? current = table[i];
                    while (current != null)
                    {
                        if (current.Data.Name == name)
                        {
                            if (current == table[i]) // Если удаляемый элемент находится в самом начале цепочки
                            {
                                table[i] = current.Next;
                                if (table[i] != null)
                                    table[i].Pred = null;
                            }
                            else
                            {
                                current.Pred.Next = current.Next;
                                if (current.Next != null)
                                    current.Next.Pred = current.Pred;
                            }
                            removed = true;
                        }
                        current = current.Next;
                    }
                }
            }
            if (removed)
            {
                Console.WriteLine($"Элемент с именем \"{name}\" удален.");
            }
            else
            {
                Console.WriteLine($"Элемент с именем \"{name}\" не найден.");
            }

            Console.WriteLine();
            return removed;
        }
    }
}


