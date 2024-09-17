using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary;

namespace DataAccessLibrary
{
    public class DapperDepartmentRepo : IDepartmentRepository
    {
        private readonly IDbConnection _connection;

        public DapperDepartmentRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<DepartmentModel> GetAllDepartments()
        {
            return _connection.Query<DepartmentModel>("SELECT * FROM Departments");
        }

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
                new { departmentName = newDepartmentName });
        }
    }
}
