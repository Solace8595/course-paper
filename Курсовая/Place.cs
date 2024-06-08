using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая
{
    public class Place
    {
        public string name, link, time, type, information, picture;
        public int cost;

        public Place() { }

        public Place(string name, string link, string time, string type, string information, int cost, string picture)
        {
            this.name = name;
            this.link = link;
            this.time = time;
            this.type = type;
            this.information = information;
            this.cost = cost;
            this.picture = picture;
        }

        public override string ToString()
        {
            return $"{name}\n" +
                   "\n" +
                   $"Ссылка на сайт с информацией: {link}\n" +
                   "\n" +
                   $"{information}\n" +
                   "\n" +
                   $"Стоимость: {cost}\n";
        }
    }

    public class Activity : Place
    {
        public Activity() { }

        public Activity(string name, string link, string time, string type, string information, int cost, string picture)
            : base(name, link, time, type, information, cost, picture) { }
    }

    public class Cafe : Place
    {
        public Cafe() { }

        public Cafe(string name, string link, string time, string type, string information, int cost, string picture)
            : base(name, link, time, type, information, cost, picture) { }
    }
}
