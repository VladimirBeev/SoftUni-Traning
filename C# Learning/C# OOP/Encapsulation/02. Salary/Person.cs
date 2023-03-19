using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Person
    {
        public Person(string firstname, string lastname, int age,decimal salary)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Age = age;
            this.Salary = salary;
        }
        private string _firstname;
        private string _lastname;
        private int _age;
        private decimal _salary;
        public string Firstname
        {
            get
            {
                return _firstname;
            }
            private set
            {
                _firstname = value;
            }
        }
        public string Lastname
        {
            get
            {
                return _lastname;
            }
            private set
            {
                _lastname = value;
            }
        }
        public int Age
        {
            get
            {
                return _age;
            }
            private set
            {
                _age = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
            }
        }
        public override string ToString()
        {
            return $"{this.Firstname} {this.Lastname} receives {this.Salary:F2} leva.";
        }
        public void IncreaseSalary(decimal percentage)
        {
            var delimiter = 100;
            if (this.Age <= 30)
            {
                delimiter = 200;
            }
            this.Salary += this.Salary * percentage / delimiter;
            

        }
    }
}
