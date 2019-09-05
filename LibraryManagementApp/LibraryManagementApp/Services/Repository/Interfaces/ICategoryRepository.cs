using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WizerTest.Data.Entities;

namespace WizerTest.Services.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int categoryId);
        Category CreateCategory(Category category);
        Category UpdateCategory(Category category);
        Category DeleteCategory(Category category);
    }
}
