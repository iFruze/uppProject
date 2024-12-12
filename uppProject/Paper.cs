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
            Random r = new Random();    
            Publication = ((PaperTitles)r.Next(0,17)).ToString();
            Info = new Person();
            Date = DateTime.Now.AddDays(r.Next(-5000, -1));
        }
        public override string ToString() => $"Название: {this.Publication}\nАвтор: {this.Info.ToShortString()}\nДата публикации: {this.Date.ToShortDateString()}";
    }
}
