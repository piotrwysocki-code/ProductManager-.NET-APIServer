using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PW_Assignment_3.Models
{
    public class DepartmentRepository : IDepartmentRepo
    {
        private Site_DBContext _dbContext;

        public DepartmentRepository(Site_DBContext ctext)
        {
            _dbContext = ctext;
        }
        public IQueryable<Department> Departments => _dbContext.Departments;

        public Department this[int id] => (Department)_dbContext.Departments.Where(x => x.DeptId == id).FirstOrDefault() != null ? (Department)_dbContext.Departments.Where(x => x.DeptId == id).FirstOrDefault() : null;

        public Department AddDepartment(Department dept)
        {
            Department temp = (Department)_dbContext.Departments.Where(x => x.DeptId == dept.DeptId).FirstOrDefault();

            try
            {
                if (temp != null)
                {
                    _dbContext.Remove(temp);
                    _dbContext.Departments.Add(dept);
                }
                else
                {
                    if (dept.DeptId == null || dept.DeptId == 0)
                    {
                        int maxId = (_dbContext.Departments.Select(x => (int?)x.DeptId).Max() ?? 0) + 1;
                        dept.DeptId = maxId + 1;
                    }

                    _dbContext.Departments.Add(dept);
                }
                _dbContext.SaveChanges();
                return dept;
            }catch(DbUpdateException ex)
            {
                Console.WriteLine(ex);
            }
         
            return null;
        }

        public Department AddDepartmentByName(string name)
        {
            Department temp = new Department();
            temp.DeptName = name;
            int maxId = (_dbContext.Departments.Select(x => (int?)x.DeptId).Max() ?? 0) + 1;

            temp.DeptId = maxId;

            if (temp != null)
            {
               // _dbContext.Remove(temp);
                _dbContext.Departments.Add(temp);
            }
            else
            {
                _dbContext.Departments.Add(temp);
            }
            _dbContext.SaveChanges();
            return temp;
        }

        public bool RemoveDepartment(int id)
        {
            Department p = (Department)_dbContext.Departments.Where(x => x.DeptId == id).FirstOrDefault();

            try
            {

                if (p != null)
                {
                    _dbContext.Departments.Remove(p);

                }

                _dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return false;
            }

            return true;
        }

        public Department UpdateDepartment(Department dept)
        {
            Department temp = (Department)_dbContext.Departments.Where(x => x.DeptId == dept.DeptId).FirstOrDefault();
            if (temp != null)
            {
                _dbContext.Remove(temp);
                _dbContext.Departments.Add(dept);
            }
            else
            {
                _dbContext.Departments.Add(dept);
            }
            _dbContext.SaveChanges();
            return dept;
        }

        public void saveDbChanges()
        {
            _dbContext.SaveChanges();
        }

    }

}
