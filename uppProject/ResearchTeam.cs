using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Frame;
namespace uppProject
{
   internal class ResearchTeam : Team, INameAndCopy, IEnumerable<Person>
   {
        private string title;
        private TimeFrame time;
        private ArrayList papers;
        private ArrayList persons;
        private static int count = 0;
        public override string ToString() => $"Название: {this.Title}\nОрганизация, проводившая исследования: {this.Name}\nРегистрационный номер: {this.RegisterNumber}\nВремя проведения исследований: {this.Time}\n{this.ShowPapers()}";
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
        public IEnumerator<Person> GetEnumerator()
        {
           // ResearchTeamEnumerator list = new ResearchTeamEnumerator();
            List<Person> list2 = new List<Person>();
            foreach (Paper t in papers)
            {
                list2.Add(t.Info);
            }
            return new ResearchTeamEnumerator(list2);
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        System.Collections.Generic.IEnumerator<Person> IEnumerable<Person>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public Team Base
        {
            get => new Team(this.Name, this.RegisterNumber);
            set => new Team(value.Name, value.RegisterNumber);
        }
        public IEnumerable<Person> PersonsWithoutPublications()
        {
            ArrayList coincidence = new ArrayList();
            foreach(Paper t in papers) coincidence.Add(t.Info);
            foreach (Person t in persons)
            {
                if(!coincidence.Contains(t)) yield return t;
            }
        }
        public IEnumerable<int> PublicationsFromNYears(int n)
        {
           // ArrayList coincidence = new ArrayList();
            for (int i = 0; i < papers.Count; i++)
            {
                if ((papers[i] as Paper).Date.Year >= DateTime.Now.AddYears(-n).Year)
                    yield return i;
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
        public void AddPapers(Person p = null, params Paper[] paper)
        {
            if(paper.Contains(null)) throw new ArgumentNullException("Пустая странца.");
            if ((object)p != null)
            {
                for (int i = 0; i < paper.Length; i++) paper[i].Info = p;
                papers.AddRange(paper);
                return;
            }
            foreach (Paper t in paper)
            {
                if (persons.Contains(t.Info))
                {
                    papers.Add(t);
                }
                else
                {
                    papers.Add(t);
                    this.AddMembers(t.Info);
                }
            }
        }
        public void AddMembers(params Person[] person)
        {
            if(person.Contains(null)) throw new ArgumentNullException("Пустое поле участника.");
            this.persons.AddRange(person);
        }
        public string ShowPapers()
        {
            StringBuilder stringBuilder = new StringBuilder("\nСтраницы:\n\n");
            foreach (Paper p in papers)
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
        public IEnumerable<Person> PersonsWhithMoreThanOnePublications()
        {
            ArrayList condience = new ArrayList();
            foreach (Paper p in papers)
            {
                int count = 0;
                foreach(Paper temp in papers)
                {
                    if(p.Info == temp.Info && !condience.Contains(p.Info))
                    {
                        count++;
                    }
                }
                condience.Add(p.Info);
                if (count > 1) yield return p.Info; 
            }
        }
   }
}
