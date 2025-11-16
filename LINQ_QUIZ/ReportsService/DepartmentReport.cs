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
            var query = users
                            .GroupBy(u => u.Department)
                            .Select(grp => {
                                int deptId = grp.Key != null ? grp.Key.Id : -1;
                                string deptName = grp.Key != null ? grp.Key.Name : "No Department";
                                string headofDepartmentName = grp.Key != null ?
                                                                grp.Where(u => u.Manager == null).Select(u => u.Name).First() :
                                                                string.Empty;

                                return new DepartmentReportResult
                                {
                                    DepartmentId = deptId,
                                    DepartmentName = deptName,
                                    EmployeeCount = grp.Count(),
                                    HeadOfDepartmentName = headofDepartmentName,
                                    TotalSalaries = grp.SelectMany(u => u.SalaryRecord).Sum(s => s.Amount),
                                    MaxSalary = grp.SelectMany(u => u.SalaryRecord).Max(s => s.Amount),
                                    MinSalary = grp.SelectMany(u => u.SalaryRecord).Min(s => s.Amount)
                                };
                            });
            return query.ToList();
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
