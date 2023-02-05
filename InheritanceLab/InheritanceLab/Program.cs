using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace InheritanceLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            string[] lines = File.ReadAllLines(@"employees.txt");

            double totalWages = 0;
            double totalPartTime = 0;
            double totalSalaried = 0;
            double totalEmployees = 0;

            foreach (string line in lines)
            {
                // split lines into parts
                string[] cells = line.Split(':');

                string id = cells[0];
                string name = cells[1];
                string address = cells[2];

                string firstdigit = id.Substring(0, 1);

                int firstDigitInt = int.Parse(firstdigit);

                if (firstDigitInt >= 0 && firstDigitInt <= 4)
                {
                    string salary = cells[7];

                    double salaryDouble = double.Parse(salary);

                    Salaried salaried = new Salaried(id, name, address, salaryDouble);
                    employees.Add(salaried);

                    totalSalaried++;
                    totalEmployees++;
                }
                else if(firstDigitInt >= 5 && firstDigitInt <= 7)
                {
                    string rate = cells[7];
                    string hours = cells[8];

                    double ratesDouble = double.Parse(rate);
                    double hoursDouble = double.Parse(hours);

                    Wages wages = new Wages(id, name, address, ratesDouble, hoursDouble);
                    employees.Add(wages);

                    totalWages++;
                    totalEmployees++;
                }
                else if(firstDigitInt >= 8 && firstDigitInt <= 9)
                {
                    string rate = cells[7];
                    string hours = cells[8];

                    double ratesDouble = double.Parse(rate);
                    double hoursDouble = double.Parse(hours);

                    PartTime partime = new PartTime(id, name, address, ratesDouble, hoursDouble);
                    employees.Add(partime);

                    totalPartTime++;
                    totalEmployees++;
                }
            }
            double weeklyPaySum = 0;

            foreach (Employee employee in employees)
            {
                double weeklyPay = employee.CalculateWeeklyPay();

                weeklyPaySum += weeklyPay;
            }

            double averageWeeklyPay = weeklyPaySum / employees.Count;

            Console.WriteLine("Average weekly pay is: $" + Math.Round(averageWeeklyPay, 2));

            Wages highestPaidWage = null;
                
            foreach (Employee employee in employees)
            {
                if (employee is Wages)
                {
                    Wages wages = (Wages)employee;

                    if (highestPaidWage == null || wages.CalculateWeeklyPay() > highestPaidWage.CalculateWeeklyPay())
                    {
                        highestPaidWage = wages;
                    }
                }
            }

            Console.WriteLine("Employee " + highestPaidWage.Name + " is the highest paid ($" + highestPaidWage.CalculateWeeklyPay() + ")");

            Wages lowestPaidWage = null;

            foreach (Employee employee in employees)
            {
                if (employee is Wages)
                {
                    Wages wages = (Wages)employee;

                    if (lowestPaidWage == null || wages.CalculateWeeklyPay() < lowestPaidWage.CalculateWeeklyPay())
                    {
                        lowestPaidWage = wages;
                    }
                }
            }

            Console.WriteLine("Employee " + lowestPaidWage.Name + " is the lowest paid ($" + lowestPaidWage.CalculateWeeklyPay() + ")");

            Console.WriteLine( Math.Round(totalSalaried / totalEmployees, 2) + "% are Salaried, " + Math.Round(totalWages / totalEmployees, 2) + "% are Waged, " + Math.Round(totalPartTime / totalEmployees, 2) + "% are Part Time");
        }

       
    }
}
