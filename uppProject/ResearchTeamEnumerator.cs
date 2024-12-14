using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace uppProject
{
    internal class ResearchTeamEnumerator : IEnumerator<Person>
    {
        private List<Person> persons = new List<Person>();
        public ResearchTeamEnumerator(List<Person> arr) 
        { 
            persons = arr;
            quantity = arr.Count;
        }
        int current = -1;
        public static int quantity = 0;
        public bool MoveNext()
        {
            if (current + 1 == quantity)
            {
                Reset();
                return false;
            }
            current++;
            return true;
        }
        public void Reset() => current = -1;
        public Person Current
        {
            get
            {
                return (persons[current] as Person);
            }
        }

    }
}
