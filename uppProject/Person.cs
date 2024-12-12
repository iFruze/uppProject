using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uppProject
{
    internal class Person
    {
        private string name;
        private string surname;
        private DateTime birthday;
        public string Name
        {
            get { return name; }
            set
            {
                if (value == "") throw new ArgumentException("Строка для имени пустая.");
                else name = value;
            }
        }
        public string Surname
        {
            get { return surname; }
            set
            {
                if (value == "") throw new ArgumentException("Строка для фамилии пустая.");
                else surname = value;
            }
        }
        public DateTime Birthday
        {
            get { return birthday; }
            set
            {
                if (value.ToShortDateString() == "") throw new ArgumentException("Строка для даты рождения пустая.");
                else birthday = value;
            }
        }
        public Person()
        {
            Random r = new Random();
            this.Name = ((Names)r.Next(0,10)).ToString();
            this.Surname = ((Surnames)r.Next(0, 10)).ToString();
            this.Birthday = DateTime.Now.AddDays(r.Next(-20000, -10000));
        }
        public Person(string name, string surname, DateTime birthday)
        {
            this.Name = name;
            this.Surname = surname;
            this.Birthday = birthday;
        }
        public override string ToString() => $"Имя: {this.Name}\nФамилия: {this.Surname}\nДата рождения: {this.Birthday.ToShortDateString()}";
        public virtual string ToShortString() => $"{this.Name} {this.Surname}";
    }
}
