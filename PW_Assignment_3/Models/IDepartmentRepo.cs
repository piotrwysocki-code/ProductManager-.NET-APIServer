using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PW_Assignment_3.Models
{

    public interface IDepartmentRepo
    {
        IQueryable<Department> Departments { get; }

        Department this[int id] { get; }

        Department AddDepartment(Department department);

        Department AddDepartmentByName(string name);

        bool RemoveDepartment(int id);

        Department UpdateDepartment(Department department);

        public void saveDbChanges();
    }
}
