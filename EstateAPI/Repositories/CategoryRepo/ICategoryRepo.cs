using EstateAPI.Dtos.Category;

namespace EstateAPI.Repositories.CategoryRepo
{
    public interface ICategoryRepo
    {
        Task<ResponseDto<List<CategoryListDto>>> GetAll();
        Task<ResponseDto<CategoryCreateDto>> Create(CategoryCreateDto categoryCreateDto);
        Task<ResponseDto<CategoryUpdateDto>> Update(CategoryUpdateDto categoryUpdateDto);
        Task<ResponseDto<CategoryDeleteDto>>Delete(int id);
        Task <ResponseDto<CategoryListDto>> GetById(int id);
    }
}
