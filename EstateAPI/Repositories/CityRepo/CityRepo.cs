using Dapper;
using EstateAPI.Data;
using EstateAPI.Dtos.City;
using System.Net;

namespace EstateAPI.Repositories.CityRepo
{
    public class CityRepo : ICityRepo
    {
        private readonly AppDbContext _context;
        private const string QueryListCities = "Select * From City";
        private const string QueryCityListWithEstateCount =
        "Select City.Id As Id, City.Name As Name, Count(Estate.Id) As EstateCount From City Left Join Estate On City.Id = Estate.CityId Group By City.Id,City.Name";

        public CityRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<List<CityListWithEstateCountDto>>> GetAllWithEstateCount()
        {
            using (var connection = _context.CreateConnection())
            {
                var cities = await connection.QueryAsync<CityListWithEstateCountDto>(QueryCityListWithEstateCount);
                if (cities == null || !cities.Any())
                {
                    return ResponseDto<List<CityListWithEstateCountDto>>.CreateFail("Hiçbir Veri Bulunamadı", HttpStatusCode.NotFound);
                } 
                return ResponseDto<List<CityListWithEstateCountDto>>.CreateSuccess(cities.ToList(), "Başarılı", HttpStatusCode.OK);
            }
        }

        public async Task<ResponseDto<List<CityListDto>>> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var cities = await connection.QueryAsync<CityListDto>(QueryListCities);
                if (cities == null || !cities.Any())
                {
                    return ResponseDto<List<CityListDto>>.CreateFail("Hiçbir Veri Bulunamadı", HttpStatusCode.NotFound);
                }
                return ResponseDto<List<CityListDto>>.CreateSuccess(cities.ToList(), "Başarılı", HttpStatusCode.OK);
            }
        }
    }
}
