using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба13
{
    public class MyList<T> where T : IInit, ICloneable, new()
    {
       public Point<T>? beg = null;
        Point<T>? end = null;

        int count = 0;
        public int Count => count;
        public Point<T>? FindItemByName(string name)
        {
            Point<T>? current = beg;

            while (current != null)
            {
                if (current.Data.Name == name)// проверка на существование элемента
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }
        public void AddAfter(string name)
        {
            Point<T>? current = FindItemByName(name);

            if (current != null)
            {
                T newData = MakeRandomItem();
                Point<T> newItem = new Point<T>(newData);

                newItem.Next = current.Next;
                newItem.Pred = current;

                if (current.Next != null) //обновление ссылки на следующий элемент у предыдущего
                {
                    current.Next.Pred = newItem;
                }
                current.Next = newItem;
                count++;
                Console.WriteLine("Элемент добавлен!");
            }
            else
            {
                Console.WriteLine("Элемент с указанным именем не найден.");
            }
        }
        public Point<T> MakeRandomData()
        {
            T data = new T();
            data.RandomInit();
            return new Point<T>(data);
        }
        public T MakeRandomItem()
        {
            T data = new T();
            data.RandomInit();
            return data;
        }
        public void AddToBegin(T item)
        {
            T newData = (T)item.Clone();//глубокое копирование
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (beg != null)
            {
                beg.Pred = newItem;
                newItem.Next = beg;
                beg = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        public void AddToEnd(T item)
        {
            if (item == null)
            {
                return;
            }

            Point<T> newItem = new Point<T>(item);
            count++;

            if (end != null)
            {
                end.Next = newItem;
                newItem.Pred = end;
                end = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }
        public MyList() { }
        public MyList(int size)
        {
            for (int i = 0; i < size; i++)
            {
                T newItem = MakeRandomItem();
                AddToEnd(newItem);
            }
            count = size;
        }
        public MyList(T[] collection)
        {
            T newData = (T)collection[0].Clone();
            beg = new Point<T>(newData);
            end = beg;
            for (int i = 0; i < collection.Length; i++)
            {
                AddToEnd(collection[i]);
            }
        }

        public void PrintList()
        {
            Point<T>? current = beg;
            if (current == null)
            {
                Console.WriteLine("Список пуст");
                Console.WriteLine();
            }
            for (int i = 0; current != null; i++)
            {
                Console.WriteLine(current);
                current = current.Next;
            }
        }
        public bool RemoveItem(Point<T> item)
        {
            if (item == null)
            {
                return false;
            }

            // Если удаляемый элемент - начало списка
            if (item == beg)
            {
                beg = item.Next; // Сдвигаем указатель начала на следующий элемент
                if (beg != null)
                {
                    beg.Pred = null; // Убираем связь с предыдущим начальным элементом
                }
                else
                {
                    end = null;
                }
                count--;
                return true;
            }

            // Если удаляемый элемент - конец списка
            if (item == end)
             {
                end = end.Pred; // Сдвигаем указатель конца на предыдущий элемент
                end.Next = null; // Убираем связь с последующим конечным элементом
                count--;
                return true;
            }

            // Если удаляемый элемент находится где-то в середине списка
            Point<T>? current = beg;
            while (current != null)
            {
                if (current == item)
                {
                    Point<T>? pred = current.Pred;
                    Point<T>? next = current.Next;
                    pred.Next = next; // Устанавливаем связь между предыдущим и следующим элементами, обходя текущий элемент
                    next.Pred = pred; // Устанавливаем обратную связь
                    count--;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }
        public MyList<T> Clone()
        {
            if (beg == null)
            {
                Console.WriteLine("Список пуст!");
                return null;
            }

            MyList<T> newList = new MyList<T>();
            Point<T> currentOriginal = beg;
            Point<T> predCloned = null;

            while (currentOriginal != null)
            {
                Point<T> clonedPoint = new Point<T>(currentOriginal.Data);

                if (newList.beg == null)
                {
                    newList.beg = clonedPoint; // Первый узел в клонированном списке.
                }
                else
                {
                    predCloned.Next = clonedPoint; // Связываем предыдущий клонированный узел с текущим.
                    clonedPoint.Pred = predCloned; // Установка предыдущего узла для двусвязного списка.
                }

                predCloned = clonedPoint;

                if (currentOriginal.Next == null)
                {
                    newList.end = clonedPoint; // Установка конца списка.
                }

                currentOriginal = currentOriginal.Next;
            }

            return newList;
        }
        public static void DeleteEven(MyList<T> list)
        {
            if (list.beg == null)
            {
                Console.WriteLine("Список пуст");
                Console.WriteLine();
                return;
            }

            if (list.beg == list.end)
            {
                Console.WriteLine("Список состоит из одного элемента");
                Console.WriteLine();
                return;
            }

            Point<T>? current = list.beg;
            int index = 1;
            while (current != null)
            {
                if (index % 2 == 0)
                {
                    list.RemoveItem(current);
                    current = current.Next; // Переход к следующему элементу
                    index++;
                }
                else
                {
                    current = current.Next;
                    index++;
                }
            }
        }
        public void DeleteList()
        {
            Point<T>? current = beg;
            while (current != null)
            {
                Point<T>? next = current.Next;
                current.Data = default(T);
                current.Next = null;
                current.Pred = null;
                current = next;
            }
            beg = null;
            end = null;
            count = 0;
        }
    }
}


