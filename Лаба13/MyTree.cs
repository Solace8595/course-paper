using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2;

namespace Лаба13
{
    public class MyTree<T> where T : IInit, ICloneable, IComparable, new()
    {
        public Spot<T>? root = null;

        int count = 0;
        public bool IsEmpty => root == null;
        public int Count => count;
        public MyTree(int length)
        {
            count = length;
            root = MakeTree(length, root);
        }
        public void PrintTree()
        {
            if (root == null)
            {
                Console.WriteLine("Дерево пустое!");
            }
            else
            {
                Show(root);
            }
        }

        // ИДС
        Spot<T>? MakeTree(int length, Spot<T>? spot)
        {
            T data = new T();
            data.RandomInit();
            Spot<T> newItem = new Spot<T>(data);
            if (length == 0)
            {
                return null;
            }
            int nl = length / 2;
            int nr = length - nl -1;
            newItem.Left = MakeTree(nl, newItem.Left);
            newItem.Right = MakeTree(nr, newItem.Right);
            return newItem;
        }
        static void Show(Spot<T>? spot, int space = 5)
        {
            if (spot != null)
            {
                Show(spot.Left, space + 5);
                for (int i = 0; i < space; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(spot.Data);
                Show(spot.Right, space + 5);
            }
        }
        public int CountItemsByName(string name)
        {
            return CountItemsByName(root, name);
        }
        static int CountItemsByName(Spot<T>? spot, string name)
        {
            if (spot == null)
            {
                return 0;
            }

            int count = 0;
            int compareResult = spot.Data.Name.CompareTo(name);

            if (compareResult == 0)
            {
                count++;
            }

            count += CountItemsByName(spot.Left, name);
            count += CountItemsByName(spot.Right, name);

            return count;
        }

        //Дерево поиска
        public void AddPoint(T data)
        {
            Spot<T>? point = root;
            Spot<T>? current = null;
            bool isExist = false;
            while (point != null && !isExist)
            {
                current = point;
                if (point.Data.CompareTo(data) == 0)
                {
                    isExist = true;
                }
                else//поиск места
                {
                    if (point.Data.CompareTo(data) < 0)
                    {
                        point = point.Left;
                    }
                    else
                    {
                        point = point.Right;
                    }
                }
                //нашли место
                if (isExist)
                {
                    return; //ничего не добавили
                }
                Spot<T> newPoint = new Spot<T>(data);
                if (current.Data.CompareTo(data) < 0)
                {
                    current.Left = newPoint;
                }
                else
                {
                    current.Right = newPoint;
                }
                count++;
            }
        }
        static void TransformToArray(Spot<T> spot, T[] array, ref int current)
        {
            if (spot != null)
            {
                TransformToArray(spot.Left, array, ref current);
                array[current] = spot.Data;
                current++;
                TransformToArray(spot.Right, array, ref current);
            }
        }
        public void TransformToFindTree()
        {
            T[] array = new T[count];
            int current = 0;
            TransformToArray(root, array, ref current);

            root = new Spot<T>(array[0]);
            count = 0;
            for (int i = 1; i < array.Length; i++) 
            {
                AddPoint(array[i]);
            }
        }
        public void Clear()
        {
            root = null;
            count = 0;
        }
    }
}
