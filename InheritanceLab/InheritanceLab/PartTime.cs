using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceLab
{
    internal class PartTime : Employee
    {
        private double hourly;
        private double rate;

        public double Hourly { get => hourly; }
        public double Rate { get => rate; }

        public PartTime(string id, string name, string address, double rate, double hourly)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.rate = rate;
            this.hourly = hourly;
        }

        public override double CalculateWeeklyPay()
        {
            double weeklyPay = 0;

            weeklyPay = this.rate * this.hourly;

            return weeklyPay;
        }
    }
}
