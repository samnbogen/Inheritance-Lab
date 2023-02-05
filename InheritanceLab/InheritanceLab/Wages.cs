using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InheritanceLab
{
    internal class Wages : Employee
    {
        private double rate;
        private double hourly;

        public double Rate { get => rate; }
        public double Hourly { get => hourly; }

        public Wages(string id, string name, string address, double rate, double hourly)
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

            if (this.hourly <= 40) 
            {
                weeklyPay = this.rate * this.hourly;
            }
            else
            {
                double overtimeHours = this.hourly - 40;

                weeklyPay = this.rate * 40;

                double overtimePay = overtimeHours * (this.rate * 1.5);

                weeklyPay += overtimePay;
            }

            return weeklyPay;
        }
    }
}
