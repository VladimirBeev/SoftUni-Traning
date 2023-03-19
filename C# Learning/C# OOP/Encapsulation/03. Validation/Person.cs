using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Person
    {
        public Person(string firstname, string lastname, int age, decimal salary)
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

                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                else
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
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
                else
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
                if (value < 1)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                else
                    _age = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return _salary;
            }
            private set
            {
                if (value < 650)
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }
                else
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
            if (this.Age < 30)
            {
                delimiter = 200;
            }
            this.Salary += this.Salary * percentage / delimiter;


        }
    }
}
