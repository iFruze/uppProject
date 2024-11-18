using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frame;
namespace uppProject
{
   internal class ResearchTeam
    {
        private string title;
        private string org;
        private int regNumber;
        private TimeFrame time;
        private Paper[] papers;
        public override string ToString() => $"Исследование номер {this.RegNumber}\nНазвание: {this.Title}\nОрганизация, проводившая исследования: {this.Org}\nВремя проведения исследований: {this.Time}\n{this.Show()}";
        public string Title
        {
            get
            {
                return title;
            }
            set
            { 
                if (value == "")
                {
                    throw new ArgumentException("Пустая строка ввода названия.");
                }
                else
                    title = value;
            }
        }
        public string Org
        {
            get
            {
                return org;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Пустая строка ввода организации.");
                }
                else
                    org = value;
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
        public int RegNumber
        {
            get
            {
                return regNumber;
            }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Пустая строка ввода названия.");
                }
                else
                    regNumber = value;
            }
        }
        public Paper this[int i]
        {
            get
            {
                if (papers[i] == null)
                {
                    throw new ArgumentNullException("Неправильный индекс.");
                }
                else
                    return papers[i];
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Пустой объект.");
                }
                else
                    papers[i] = value;
            }
        }
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
        public ResearchTeam(string title, string org, int regNumber, TimeFrame time)
        {
            this.Title = title;
            this.Org = org;
            this.RegNumber = regNumber;
            this.Time = time;
            papers = new Paper[0];
        }
        public ResearchTeam()
        {
            this.Title = "None";
            this.Org = "None";
            this.RegNumber = 1;
            this.Time = 0;
            papers = new Paper[0];
        }
        public void AddPapers(params Paper[] paper)
        {
            for(int i = 0; i < paper.Length; i++)
            {
                if(paper[i] == null)
                {
                    throw new ArgumentNullException("Пустая странца.");
                }
            }
            int new_size = paper.Length + papers.Length;
            Paper[] pap = new Paper[new_size];
            for (int i = 0; i < papers.Length; i++)
            {
                pap[i] = papers[i];
            }
            int ind = 0;
            for (int i = papers.Length; i < pap.Length; i++)
            {
                pap[i] = paper[ind++];
            }
            papers = pap;
        }
        public string Show()
        {
            StringBuilder stringBuilder = new StringBuilder("\nСтраницы:\n\n");
            foreach (Paper p in papers)
            {
                stringBuilder.Append(p.ToString());
                stringBuilder.Append("\n\n");
            }
            return stringBuilder.ToString();
        }
        
        public Paper Search()
        {
            Paper res = papers[0];
            foreach (Paper p in papers)
            {
                if(res.Date < p.Date)
                {
                    res = p;
                }
            }
            return res;
        }
    }
}
