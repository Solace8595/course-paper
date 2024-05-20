using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2;

namespace Лаба13
{
    public class Spot<T> where T: IComparable
    {
        public T? Data { get; set; }
        public Spot<T>? Left { get; set; }
        public Spot<T>? Right { get; set; }

        public Spot()
        {
            this.Data = default(T);
            this.Left = null;
            this.Right = null;
        }
        public Spot(T data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }
        public override string? ToString()
        {
            return Data == null ? "" : Data.ToString();
        }
        public int CompareTo(Point<T> other)
        {
            return Data.CompareTo(other.Data);
        }
    }
}
