using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceLab
{
    internal class Employee
    {
        protected string id;
        protected string name;
        protected string address;

        public string ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; } 
        public string Address { get => address; set => address = value; } 
        
        public Employee() { }   
        public Employee(string id, string name, string address) 
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }

        public virtual double CalculateWeeklyPay()
        {
            return 0;
        }


    }
}
