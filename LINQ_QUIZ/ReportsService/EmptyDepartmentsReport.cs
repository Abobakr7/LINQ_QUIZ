using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ_QUIZ.DataBase;
using LINQ_QUIZ.Models;

namespace LINQ_QUIZ.ReportsService
{
    internal class EmptyDepartmentsReport
    {
        public IEnumerable<Department> GenerateEmptyDepartmentReport()
        {
            IEnumerable<User> users = UserSource.GetAllUsers();
            Department[] depts = new[] { Department.SERVICE_GROUP, Department.IT, Department.HR, Department.OIL_AND_GAS };
            var nonEmptyDepts = users
                        .Select(u => u.Department)
                        .Distinct()
                        .ToList();
            var query = depts
                            .Except(nonEmptyDepts);
            return query.ToList();
        }
    }
}
