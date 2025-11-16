using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ_QUIZ.DataBase;
using LINQ_QUIZ.Models;

namespace LINQ_QUIZ.ReportsService
{
    /// <summary>
    /// TODO: Implement TotalSalariesReport to generate a report of total salaries that company expected to Pay.
    /// </summary>
    internal class TotalSalariesReport
    {
        public decimal GenerateTotalSalariesReport()
        {
            IEnumerable<User> users = UserSource.GetAllUsers();
            return users
                        .SelectMany(u => u.SalaryRecord)
                        .Where(s => (int)s.Month == DateTime.Now.Month) // should add this `s.Year == DateTime.Now.Year` because salary record tracks year too
                        .Sum(s => s.Amount);
        }
    }
}
