using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_QUIZ.ReportsService
{
    internal class DepartmentReport
    {
        public IEnumerable<DepartmentReportResult> GenerateReport()
        {
            var users = DataBase.UserSource.GetAllUsers();
            // Implement the logic to generate the department report
        }
    }

    public class DepartmentReportResult
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int EmployeeCount { get; set; }
        public string HeadOfDepartmentName { get; set; }
        public decimal TotalSalaries { get; set; }
        public decimal MaxSalary { get; set; }
        public decimal MinSalary { set; get; }

    }
}
