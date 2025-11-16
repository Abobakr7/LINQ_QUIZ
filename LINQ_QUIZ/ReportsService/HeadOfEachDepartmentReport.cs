using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ_QUIZ.DataBase;
using LINQ_QUIZ.Models;

namespace LINQ_QUIZ.ReportsService
{
    internal class HeadOfEachDepartmentReport
    {
        public IEnumerable<(Department department, User user)> GenerateHeadOfEachDepartmentReport()
        {
            IEnumerable<User> users = UserSource.GetAllUsers();
            var query = users
                            .GroupBy(u => u.Department)
                            .Select(grp => (grp.Key, grp.Where(u => u.Manager == null).FirstOrDefault()));
            return query.ToList();
        }
    }
}
