using SportsZoneWebAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SportsZoneWebAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<bool> IsAvail(int catergoryID);
        public Task<IEnumerable<CategoryResponseDTO>> GetAllCategories();
        public Task<CategoryResponseDTO> GetCategoryByCategoryID(int categoryID);
        public Task AddNewCategory(CategoryRequestDTO categoryRequestDTO);
        public Task UpdateCategory(CategoryRequestDTO categoryRequestDTO);
        public Task DeleteCategoryByCategoryID(int categoryID);
    }
}
