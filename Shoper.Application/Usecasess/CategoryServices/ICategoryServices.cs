using ShoperApplication.Dtos.CategoryDtos;

namespace ShoperApplication.Usecasess.CategoryServices;

public interface ICategoryServices
{
    Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
    Task<GetByIdCategoryDto>GetByIdCategoryAsync(int id);
    Task CreateCategoryAsync(CreateCategoryDto model);
    Task UpdateCategoryAsync(UpdateCategoryDto model);
    Task DeleteCategoryAsync(int id);
    
}