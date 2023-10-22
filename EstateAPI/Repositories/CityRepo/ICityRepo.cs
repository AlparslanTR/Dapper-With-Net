using EstateAPI.Dtos.City;

namespace EstateAPI.Repositories.CityRepo
{
    public interface ICityRepo
    {
        Task<ResponseDto<List<CityListWithEstateCountDto>>> GetAllWithEstateCount();
        Task<ResponseDto<List<CityListDto>>> GetAll();
    }
}
