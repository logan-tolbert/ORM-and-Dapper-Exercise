using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary;
namespace DataAccessLibrary
{
    public interface IDepartmentRepository
    {
        public IEnumerable<DepartmentModel> GetAllDepartments();
        public void InsertDepartment(string newDepartmentName);
    }
}
