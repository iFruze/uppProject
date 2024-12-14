using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uppProject
{
    internal class Paper : INameAndCopy
    {
        public string Name { get; set; }
        public Person Info { get; set; }
        public DateTime Date { get; set; }
        public Paper(string p, Person i, DateTime d)
        {
            Name = p;
            Info = i;
            Date = d;
        }
        public Paper()
        {
            Random r = new Random();    
            Name = ((PaperTitles)r.Next(0,17)).ToString();
            Info = new Person();
            Date = DateTime.Now.AddDays(r.Next(-1080, -1));
        }
        object INameAndCopy.DeepCopy() => new Paper(Name, Info, Date);
        public override string ToString() => $"Название: {this.Name}\nАвтор: {this.Info.ToShortString()}\nДата публикации: {this.Date.ToShortDateString()}";
    }
}
