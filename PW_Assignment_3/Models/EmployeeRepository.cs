using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PW_Assignment_3.Models
{
    public class EmployeeRepository : IEmployeeRepo
    {
        private Site_DBContext _dbContext;

        public EmployeeRepository(Site_DBContext ctext)
        {
            _dbContext = ctext;
        }
        public IQueryable<Employee> Employees => _dbContext.Employees;

        public Employee this[int id] => (Employee)_dbContext.Employees.Where(x => x.employeeId == id).FirstOrDefault() != null ? (Employee)_dbContext.Employees.Where(x => x.employeeId == id).FirstOrDefault() : null;

        public Employee AddEmployee(Employee employee)
        {

            if(employee.deptId != null && !employee.deptId.Equals("")
                && employee.firstName != null && !employee.firstName.Equals("")
                && employee.lastName != null && !employee.lastName.Equals("")
                && employee.salary != null && !employee.salary.Equals("")
                && employee.province != null && !employee.province.Equals("")
                && employee.city != null && !employee.city.Equals(""))
            {
                Employee temp = (Employee)_dbContext.Employees.Where(x => x.employeeId == employee.employeeId).FirstOrDefault();

                if (temp != null)
                {
                    _dbContext.Remove(temp);
                    _dbContext.Employees.Add(employee);
                }
                else
                {
                    int maxId = (_dbContext.Employees.Select(x => (int?)x.employeeId).Max() ?? 0) + 1;
                    employee.employeeId = maxId;
                    _dbContext.Employees.Add(employee);
                }
                _dbContext.SaveChanges();
                return employee;
            }
            return null;          
        }

        public bool RemoveEmployee(int id)
        {
            Employee p = (Employee)_dbContext.Employees.Where(x => x.employeeId == id).FirstOrDefault();

            try
            {
                if(p != null)
                {
                    _dbContext.Employees.Remove(p);
                    _dbContext.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                return false;
            }

            return true;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            Employee temp = (Employee)_dbContext.Employees.Where(x => x.employeeId == employee.employeeId).FirstOrDefault();
            if (temp != null)
            {
                _dbContext.Remove(temp);
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
            }

            return temp;
        }

        public void saveDbChanges()
        {
            _dbContext.SaveChanges();
        }

    }

}
