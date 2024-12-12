using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace uppProject
{
    internal class Team : INameAndCopy
    {
        protected string titleOfOrganization;
        protected int registerNumber;
        public string Name
        {
            get => titleOfOrganization;
            set
            {
                if (value == "") throw new ArgumentException("Название организации не может быть пустым");
                titleOfOrganization = value;
            }
        }
        public int RegisterNumber
        {
            get => registerNumber;
            set
            {
                if (value <= 0) throw new ArgumentException("Номер организации не может быть отрицательным либо равен 0");
                registerNumber = value;
            }
        }
        object INameAndCopy.DeepCopy() => new Team(this.Name, this.RegisterNumber);
        public Team(string name, int num)
        {
            this.Name = name;
            this.RegisterNumber = num;
        }
        public Team() 
        { 
            Random r = new Random();
            this.RegisterNumber = r.Next(1, 1000);
            this.Name = ((Org)r.Next(0,10)).ToString();
        }
        public override bool Equals(object? obj) => obj is Team t ? this.Name == t.Name && this.RegisterNumber == t.RegisterNumber : throw new ArgumentNullException("Неверный тип объекта");
        public static bool operator==(Team t1, Team t2) => t1.Name == t2.Name && t1.RegisterNumber == t2.RegisterNumber;
        public static bool operator!=(Team t1, Team t2) => t1.Name != t2.Name && t1.RegisterNumber != t2.RegisterNumber;
        public override int GetHashCode() => (int)this.Name.GetHashCode() | (int)this.RegisterNumber.GetHashCode() << 12;
        public override string ToString() => $"Организация {this.Name}. Регистрационный номер: {this.RegisterNumber}";
    }
}
