using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_QUIZ.ReportsService
{
    internal class DepartmentAndMonthTotalSalaryReport
    {
        public IEnumerable<DepartmentAndMonthTotalSalary> GenerateDepartmentAndMonthTotalSalaryReport()
        {
            var users = DataBase.UserSource.GetAllUsers();
            // Implement the logic to generate the department and month total salary report
        }
    }

    public class DepartmentAndMonthTotalSalary
    {
        public string DepartmentName { get; set; }
        public int Month { get; set; }
        public decimal TotalSalary { get; set; }
    }
}
