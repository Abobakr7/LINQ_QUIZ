using LINQ_QUIZ.Models.Enums;
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
            var query = users
                            .SelectMany(u => u.SalaryRecord, (u, s) => new
                            {
                                Salary = s.Amount,
                                Month = s.Month,
                                DeptName = u.Department != null ? u.Department.Name : "No Department"
                            })
                            .GroupBy(s => new { s.DeptName, s.Month })
                            .Select(grp => new DepartmentAndMonthTotalSalary
                            {
                                DepartmentName = grp.Key.DeptName,
                                Month = (int)grp.Key.Month,
                                TotalSalary = grp.Sum(s => s.Salary)
                            });

            return query.ToList();
        }
    }

    public class DepartmentAndMonthTotalSalary
    {
        public string DepartmentName { get; set; }
        public int Month { get; set; }
        public decimal TotalSalary { get; set; }
    }
}
