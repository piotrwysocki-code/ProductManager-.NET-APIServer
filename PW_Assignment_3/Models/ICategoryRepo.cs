using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PW_Assignment_3.Models
{
    public interface ICategoryRepo 
    {
        IQueryable<Category> Categories { get; }

        Category this[int id] { get; }

        Category AddCategory(Category category);

        bool RemoveCategory(int id);

        Category UpdateCategory(Category category);

        public void saveDbChanges();
    }
}
