using EstateAPI.Dtos.Estate;

namespace EstateAPI.Repositories.EstateRepo
{
    public interface IEstateRepo
    {
        Task<ResponseDto<List<EstateListDto>>> GetAll();
        Task<ResponseDto<List<EstateListWithCategoryDto>>> GetAllWithCategory();
        Task<ResponseDto<List<EstateListWithEmployeeDto>>> GetAllWithEmployee();
        Task<ResponseDto<EstateCreateDto>> Create(EstateCreateDto createDto);
        Task<ResponseDto<EstateUpdateDto>> Update(EstateUpdateDto updateDto);
        Task<ResponseDto<EstateListDto>> GetById(int id);
        Task<ResponseDto<EstateDeleteDto>> Delete(int id);
    }
}
