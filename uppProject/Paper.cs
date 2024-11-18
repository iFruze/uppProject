using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uppProject
{
    internal class Paper
    {
        public string Publication { get; set; }
        public Person Info { get; set; }
        public DateTime Date { get; set; }
        public Paper(string p, Person i, DateTime d)
        {
            Publication = p;
            Info = i;
            Date = d;
        }
        public Paper()
        {
            Publication = "Руководство по закапыванию хомячков";
            Info = new Person();
            Date = new DateTime(2020, 02, 13);
        }
        public override string ToString() => $"Название: {this.Publication}\nАвтор: {this.Info.ToShortString()}\nДата публикации: {this.Date.ToShortDateString()}";
    }
}
