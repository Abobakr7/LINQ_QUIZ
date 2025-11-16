using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ_QUIZ.Models.Enums;

namespace LINQ_QUIZ.Models
{
    internal class SalaryRecord
    {
        public decimal Amount { get; private set; }
        public Month Month { get; private set; }
        public int Year { get; private set; }
        public SalaryRecord(decimal amount, Month month, int year)
        {
            Amount = amount;
            Month = month;
            Year = year;
        }
    }
}
