using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PW_Assignment_3.Models
{
    public class CategoryRepository : ICategoryRepo
    {
        private Site_DBContext _dbContext;

        public CategoryRepository(Site_DBContext ctext)
        {
            _dbContext = ctext;
        }
        public IQueryable<Category> Categories => _dbContext.Categories;

        public Category this[int id] => (Category)_dbContext.Categories.Where(x => x.CategoryId == id).FirstOrDefault() != null ? (Category)_dbContext.Categories.Where(x => x.CategoryId == id).FirstOrDefault() : null;

        public Category AddCategoryByName(string category)
        {
            Category temp = new Category();
            temp.CategoryName = category;
            int maxId = (_dbContext.Categories.Select(x => (int?)x.CategoryId).Max() ?? 0) + 1;
            temp.CategoryId = maxId;

            try
            {
                _dbContext.Categories.Add(temp);
                _dbContext.SaveChanges();

            }
            catch (DbUpdateException ex)
            {
                return null;
            }
        

            return temp;
        }

        public Category AddCategory(Category category)
        {
            Category temp = category;
            int maxId = (int)_dbContext.Categories.Max(x => x.CategoryId);
            temp.CategoryId = maxId + 1;
            try
            {
                _dbContext.Categories.Add(temp);
                _dbContext.SaveChanges();

            }
            catch (DbUpdateException ex)
            {
                return null;
            }

            return temp;
        }


        public bool RemoveCategory(int id)
        {
            Category p = (Category)_dbContext.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            
            try
            {
                _dbContext.Categories.Remove(p);

                _dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

        public Category UpdateCategory(Category category)
        {
            Category temp = (Category)_dbContext.Categories.Where(x => x.CategoryId == category.CategoryId).FirstOrDefault();
            if (temp != null)
            {
                _dbContext.Remove(temp);
                _dbContext.Add(category);
            }
            else
            {
                AddCategory(category);
            }
            try
            {
                _dbContext.SaveChanges();

            }
            catch(DbUpdateException e)
            {
                Console.WriteLine("error" + e);
            }

            return category;
        }

        public void saveDbChanges()
        {
            _dbContext.SaveChanges();
        }

    }

}
