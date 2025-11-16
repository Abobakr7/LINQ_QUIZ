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

            // Implement the logic to get the list of empty departments
        }
    }
}
