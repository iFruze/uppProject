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
                if (value == "") throw new ArgumentNullException("Строка для имени пустая.");
                else name = value;
            }
        }
        public string Surname
        {
            get { return name; }
            set
            {
                if (value == "") throw new ArgumentNullException("Строка для фамилии пустая.");
                else surname = value;
            }
        }
        public DateTime Birthday
        {
            get { return birthday; }
            set
            {
                if (value.ToShortDateString() == "") throw new ArgumentNullException("Строка для даты рождения пустая.");
                else birthday = value;
            }
        }
        public Person()
        {
            this.Name = "Бенис";
            this.Surname = "Дуев";
            this.Birthday = new DateTime(1980, 4, 29);
        }
        public Person(string name, string surname, DateTime birthday)
        {
            this.Name = name;
            this.Surname = surname;
            this.Birthday = birthday;
        }
        public override string ToString() => $"Имя: {this.Name}\nФамилия: {this.Surname}\nДата рождения: {this.Birthday.ToShortDateString()}";
        public virtual string ToShortString() => $"Имя: {this.Name}\nФамилия: {this.Surname}";
    }
}
