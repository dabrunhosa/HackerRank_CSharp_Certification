//using Commons;
//using System;

//namespace Task2
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            TextHandle.WriteFile(new Result());
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution
{
    public class Solution
    {
        public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        { 
            Dictionary<string,int> result = new Dictionary<string,int>();
            var sortedEmployees = employees.OrderBy(employee => employee.Company);

            var numberEmployees = CountOfEmployeesForEachCompany(employees);

            foreach (var employee in sortedEmployees)
            { 
                if (result.ContainsKey(employee.Company))
                    result[employee.Company] += employee.Age;
                else
                    result[employee.Company] = employee.Age;
            }

            foreach (var company in numberEmployees)
            {
                result[company.Key] = (int)Math.Round((decimal)result[company.Key]/numberEmployees[company.Key]);
            }


            return result;
        }

        public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            var sortedEmployees = employees.OrderBy(employee => employee.Company);

            foreach (var employee in sortedEmployees)
            {
                if(result.ContainsKey(employee.Company))
                    result[employee.Company]++;
                else
                    result[employee.Company] = 1;
            }


            return result;
        }

        public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            Dictionary<string, Employee> result = new Dictionary<string, Employee>();
            var sortedEmployees = employees.OrderBy(employee => employee.Company);

            foreach (var employee in sortedEmployees)
            {
                if (result.ContainsKey(employee.Company))
                    result[employee.Company] = result[employee.Company].Age < employee.Age ? employee : result[employee.Company];
                else
                    result[employee.Company] = employee;
            }


            return result;
        }

        public static void Main()
        {
            int countOfEmployees = int.Parse(Console.ReadLine());

            var employees = new List<Employee>();

            for (int i = 0; i < countOfEmployees; i++)
            {
                string str = Console.ReadLine();
                string[] strArr = str.Split(' ');
                employees.Add(new Employee
                {
                    FirstName = strArr[0],
                    LastName = strArr[1],
                    Company = strArr[2],
                    Age = int.Parse(strArr[3])
                });
            }

            foreach (var emp in AverageAgeForEachCompany(employees))
            {
                Console.WriteLine($"The average age for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in CountOfEmployeesForEachCompany(employees))
            {
                Console.WriteLine($"The count of employees for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in OldestAgeForEachCompany(employees))
            {
                Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");
            }
        }
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }
}