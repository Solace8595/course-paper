using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая
{
    public class Cafe
    {
        protected string name, link, time, type, information;
        protected double cost;
        public Cafe(string name, string link, string time, string type, string information, double cost)  // конструктор с параметрами
        {
            this.name = name;
            this.link = link;
            this.time = time;
            this.type = type;
            this.information = information;
            this.cost = cost;
        }
        public Cafe() { }
    }
}
