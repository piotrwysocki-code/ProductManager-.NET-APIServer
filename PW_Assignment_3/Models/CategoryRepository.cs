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

        public Category AddCategory(Category category)
        {
            Category temp = (Category)_dbContext.Categories.Where(x => x.CategoryId == category.CategoryId).FirstOrDefault();
            if (temp != null)
            {
                _dbContext.Remove(temp);
                _dbContext.Categories.Add(category);
            }
            else
            {
                _dbContext.Categories.Add(category);
            }
            _dbContext.SaveChanges();
            return category;
        }

        public bool RemoveCategory(int id)
        {
            Category p = (Category)_dbContext.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            _dbContext.Categories.Remove(p);
            
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
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
                _dbContext.Categories.Add(category);
            }
            else
            {
                _dbContext.Categories.Add(category);
            }
            _dbContext.SaveChanges();
            return category;
        }

        public void saveDbChanges()
        {
            _dbContext.SaveChanges();
        }

    }

}
