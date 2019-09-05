using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WizerTest.Data;
using WizerTest.Data.Entities;
using WizerTest.Services.Repository.Interfaces;

namespace WizerTest.Services.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private LibraryDbContext _categoryContext;

        public CategoryRepository(LibraryDbContext categoryContext)
        {
            _categoryContext = categoryContext;
        }
        public Category CreateCategory(Category category)
        {
            _categoryContext.Categories.Add(category);
            _categoryContext.SaveChanges();

            return category;
        }

        public Category DeleteCategory(Category category)
        {
            _categoryContext.Remove(category);
            _categoryContext.SaveChanges();

            return category;
        }

        public ICollection<Category> GetCategories()
        {
            return _categoryContext.Categories.OrderBy(b => b.Id).ToList();
        }

        public Category GetCategory(int categoryId)
        {
            return _categoryContext.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
        }


        public Category UpdateCategory(Category category)
        {
            _categoryContext.Categories.Update(category);
            _categoryContext.SaveChanges();
            return category;
        }
    }
}
