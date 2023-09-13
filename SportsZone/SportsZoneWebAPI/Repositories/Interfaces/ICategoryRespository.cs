using SportsZoneWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Repositories.Interfaces
{
    public interface ICategoryRespository
    {
        public Task<IEnumerable<Category>> GetAllCategories();
        public Task<Category> GetCategoryByCategoryID(int categoryID);
        public Task AddNewCategory(Category category);
        public Task UpdateCategory(Category category);
        public Task DeleteCategoryByCategoryID(int categoryID);
        public Task DeleteAllCategories();

    }
}
