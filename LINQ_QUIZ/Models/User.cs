using LINQ_QUIZ.Exceptions;
using LINQ_QUIZ.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_QUIZ.Models
{
    internal class User
    {
        private const decimal MINIMUM_WAGE = 2500m;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Country { get; private set; }
        public Department? Department { get; private set; }
        public User? Manager { get; private set; }
        public List<SalaryRecord> SalaryRecord { get; private set; }

        public User(int id, string name, int age, string country, User? manager, Department? department, decimal initialSalary)
        {
            Id = id;
            Name = name;
            Age = age;
            Country = country;
            Department = department;
            Manager = manager;

            if (initialSalary < MINIMUM_WAGE)
                throw new InvalidSalaryException($"Salary {initialSalary:C} is below minimum wage {MINIMUM_WAGE:C}");

            if (initialSalary > Manager?.GetCurrentSalary())
                throw new InvalidSalaryException($"Salary {initialSalary:C} cannot be more than Manager's salary");

            Month currentMonth = (Month)DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            SalaryRecord = new List<SalaryRecord>
            {
                new SalaryRecord(initialSalary, currentMonth, currentYear)
            };
        }

        public void MakeAppraisal(decimal percentage)
        {
            if (SalaryRecord == null) return;

            int appraisalsCount = SalaryRecord
                                    .Where(s => s.Year == DateTime.Now.Year)
                                    .Select(s => s.Amount)
                                    .Distinct()
                                    .Count();

            if (appraisalsCount >= 2)
                throw new InvalidSalaryException($"User had already 2 or more appraisals this year.");

            decimal? lastSalary = GetCurrentSalary();
            decimal newSalaryAmount = lastSalary != null ? (decimal)(lastSalary + (lastSalary * percentage / 100)) : 0m;

            Month currentMonth = (Month)DateTime.Now.Month;
            SalaryRecord.Add(new SalaryRecord(newSalaryAmount, currentMonth, DateTime.Now.Year));
        }

        /// <summary>
        /// TODO: Get the last salary record of the user
        /// </summary>
        /// <returns></returns>
        public decimal? GetCurrentSalary()
        {
            SalaryRecord? currentSalary = SalaryRecord.LastOrDefault();
            return currentSalary?.Amount;
        }
    }
}
