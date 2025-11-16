using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_QUIZ.Models
{
    internal class User
    {
        public int Id { get;private set; }
        public string Name { get;private set; }
        public int Age { get;private set; }
        public string Country { get;private set; }
        public Department? Department { get;private set; }
        public User? Manager { get;private set; }
        public IEnumerable<SalaryRecord> SalaryRecord { get;private set; }

        public User(int id, string name, int age, string country,User? manager,Department? department,decimal initialSalary)
        {
            Id = id;
            Name = name;
            Age = age;
            Country = country;
            Department = department;
            Manager = manager;
            var currentMonth = DateTime.Now.Month;
            SalaryRecord = new List<SalaryRecord>
            {
                new SalaryRecord(initialSalary,currentMonth)
            };
        }

        public void MakeAppraisal(decimal percentage)
        {
            if (SalaryRecord == null) return;
            var lastSalry = GetCurrentSalary();
            var newSalaryAmount = lastSalry != null ? lastSalry + (lastSalry * percentage / 100) : 0;
        }

        /// <summary>
        /// TODO: Get the last salary record of the user
        /// </summary>
        /// <returns></returns>
        public decimal GetCurrentSalary()
        {

        }
    }
}
