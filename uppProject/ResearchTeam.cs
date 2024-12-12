using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frame;
namespace uppProject
{
   internal class ResearchTeam : Team, INameAndCopy
   {
        private string title;
        private TimeFrame time;
        private ArrayList papers;
        private ArrayList persons;
        private static int count = 0;
        public override string ToString() => $"Название: {this.Title}\nОрганизация, проводившая исследования: {this.Name}\nРегистрационный номер: {this.RegisterNumber}\nВремя проведения исследований: {this.Time}\n{this.Show()}";
        public string ToShortString() => $"Название: {this.Title}\nОрганизация, проводившая исследования: {this.Name}\nРегистрационный номер: {this.RegisterNumber}\nВремя проведения исследований: {this.Time}";
        public ArrayList Papers
        {
            get => papers;
            set => papers = new ArrayList(value);
        }
        public ArrayList Persons
        {
            get => persons;
            set => persons = new ArrayList(value);
        }
        public Paper LastPublication
        {
            get
            {
                if (papers.Contains(null)) return null;
                var res = papers[0];
                foreach (var p in papers)
                {
                    if ((res as Paper).Date < (p as Paper).Date)
                    {
                        res = p;
                    }
                }
                return (res as Paper);
            }
        }
        public string Title
        {
            get => title;
            set
            {
                if (value == "") throw new ArgumentException("Название исследования не может быть пустым.");
                title = value;
            }
        }
        public TimeFrame Time
        {
            get
            {
                return time;
            }
            set
            {
                if (value.ToString() == "")
                {
                    throw new ArgumentException("Пустая строка ввода продолжительности.");
                }
                else
                    time = value;
            }
        }
        //public Paper this[int i]
        //{
        //    get
        //    {
        //        if (papers[i] == null)
        //        {
        //            throw new ArgumentNullException("Неправильный индекс.");
        //        }
        //        else
        //            return (Paper)papers[i];
        //    }
        //    set
        //    {
        //        if (value == null)
        //        {
        //            throw new ArgumentNullException("Пустой объект.");
        //        }
        //        else
        //            papers[i] = value;
        //    }
        //}
        object INameAndCopy.DeepCopy() => new ResearchTeam(this.Title, this.Name, this.RegisterNumber, this.Time, this.Papers, this.Persons);
        public bool this[TimeFrame i]
        {
            get
            {
                if(i == this.Time)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public ResearchTeam(string title, string org, int regNumber, TimeFrame time, ArrayList paper, ArrayList person) : base(org, regNumber)
        {
            this.Title = title;
            this.Time = time;
            this.papers = new ArrayList(paper);
            this.persons = new ArrayList(person);
            count++;
        }
        public ResearchTeam() : base()
        {
            Random random = new Random();
            this.Title = $"Исследование №{++count}";
            this.Time = (TimeFrame)random.Next(0,3);
            this.Papers = new ArrayList();
            this.Persons = new ArrayList();
        }
        public void AddPapers(params Paper[] paper)
        {
            if(paper.Contains(null)) throw new ArgumentNullException("Пустая странца.");
            papers.AddRange(paper);
            foreach(Paper t in papers) this.AddMembers(t.Info);
        }
        public void AddMembers(params Person[] person)
        {
            if(person.Contains(null)) throw new ArgumentNullException("Пустое поле участника.");
            this.persons.AddRange(person);
        }
        public string Show()
        {
            StringBuilder stringBuilder = new StringBuilder("\nСтраницы:\n\n");
            foreach (object p in papers)
            {
                stringBuilder.Append(p.ToString());
                stringBuilder.Append("\n\n");
            }
            return stringBuilder.ToString();
        }
        //public Paper Search()
        //{
        //    var res = papers[0];
        //    foreach (var p in papers)
        //    {
        //        if((res as Paper).Date < (p as Paper).Date)
        //        {
        //            res = p;
        //        }
        //    }
        //    return (res as Paper);
        //}
   }
}
