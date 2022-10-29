using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PW_Assignment_3.Models
{ 

    public interface IEmployeeRepo
    {
        IQueryable<Employee> Employees { get; }

        Employee this[int id] { get; }

        Employee AddEmployee(Employee employee);

        bool RemoveEmployee(int id);

        Employee UpdateEmployee(Employee employee);

        public void saveDbChanges();
    }
}
