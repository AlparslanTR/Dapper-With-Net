using Azure;
using Dapper;
using EstateAPI.Data;
using EstateAPI.Dtos.Category;
using EstateAPI.Dtos.Estate;
using System.Net;

namespace EstateAPI.Repositories.EstateRepo
{
    public class EstateRepo : IEstateRepo
    {
        private readonly AppDbContext _context;
        private const string QueryEstateList = "Select Id, Title, Price, City, District, CategoryId FROM Estate";
        private const string QueryEstateListWithCategory =
        "Select E.Id, E.Title, E.Price, E.City, E.District, C.Name as CategoryName from Estate as E inner join Category as C on E.CategoryId = C.Id";
        private const string QueryEstateAdd =
        "Insert into Estate (Title,Price,CoverImage,City,District,Address,Description,CategoryId,EmployeeId) values (@Title, @Price,@CoverImage,@City,@District,@Address,@Description,@CategoryId,@EmployeeId)";
        private const string QueryEstateListWithEmployee = 
        "Select E.Id, E.Title, E.Price, E.City, E.District, U.Name as EmployeeName from Estate as E inner join Employee as U on E.EmployeeId = U.Id";
        private const string QueryEstateUpdate =
        "Update Estate set Title =@Title, Price =@Price, CoverImage =@CoverImage, City =@City, District = @District, Address =@Address, Description=@Description, CategoryId = @CategoryId, EmployeeId=@EmployeeId where Id=@id";
        private const string QueryEstateGetById = "Select Id,Title,Price,City,District,CategoryId from Estate where Id=@id";
        private const string QueryEstateDelete = "Delete from Estate where Id=@id";

        public EstateRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<List<EstateListDto>>> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var estates = await connection.QueryAsync<EstateListDto>(QueryEstateList);
                if (estates is null || !estates.Any())
                {
                    return ResponseDto<List<EstateListDto>>.CreateFail("Hiçbir Veri Bulunamadı",HttpStatusCode.NotFound);
                }
                return ResponseDto<List<EstateListDto>>.CreateSuccess(estates.ToList(), "Başarılı ", HttpStatusCode.OK);
            }
        }

        public async Task<ResponseDto<List<EstateListWithCategoryDto>>> GetAllWithCategory()
        {
            using (var connection = _context.CreateConnection())
            {
                var estates = await connection.QueryAsync<EstateListWithCategoryDto>(QueryEstateListWithCategory);
                if (estates is null || !estates.Any())
                {
                    return ResponseDto<List<EstateListWithCategoryDto>>.CreateFail("Hiçbir Veri Bulunamadı", HttpStatusCode.NotFound);
                }
                return ResponseDto<List<EstateListWithCategoryDto>>.CreateSuccess(estates.ToList(), "Başarılı ", HttpStatusCode.OK);
            }
        }

        public async Task<ResponseDto<EstateCreateDto>> Create(EstateCreateDto createDto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Title",createDto.title);
            parameters.Add("@Price",createDto.price);
            parameters.Add("@CoverImage", createDto.coverImage);
            parameters.Add("@City", createDto.city);
            parameters.Add("@District", createDto.district);
            parameters.Add("@Address", createDto.address);
            parameters.Add("@Description", createDto.description);
            parameters.Add("@CategoryId", createDto.categoryId);
            parameters.Add("@EmployeeId", createDto.employeeId);

            using (var connection = _context.CreateConnection())
            {
                var affectedRows = await connection.ExecuteAsync(QueryEstateAdd, parameters);
                if (affectedRows > 0)
                {
                    return ResponseDto<EstateCreateDto>.CreateSuccess(createDto, $"{createDto.title} Adlı Varlık Başarıyla Eklendi", HttpStatusCode.OK);
                }
                else
                {
                    return ResponseDto<EstateCreateDto>.CreateFail("Veri Eklenirken Hata Oluştu",HttpStatusCode.BadRequest);
                }
            }
        }

        public async Task<ResponseDto<List<EstateListWithEmployeeDto>>> GetAllWithEmployee()
        {
            using (var connection = _context.CreateConnection())
            {
                var employee = await connection.QueryAsync<EstateListWithEmployeeDto>(QueryEstateListWithEmployee);
                if (employee is null || !employee.Any())
                {
                    return ResponseDto<List<EstateListWithEmployeeDto>>.CreateFail("Hiçbir Veri Bulunamadı", HttpStatusCode.NotFound);
                }
                return ResponseDto<List<EstateListWithEmployeeDto>>.CreateSuccess(employee.ToList(), "Başarılı", HttpStatusCode.OK);
            }
        }

        public async Task<ResponseDto<EstateUpdateDto>> Update(EstateUpdateDto updateDto)
        {
            using (var connection = _context.CreateConnection())
            {
                int? estate = await connection.ExecuteAsync(QueryEstateUpdate, updateDto);
                if (estate is null)
                {
                    return ResponseDto<EstateUpdateDto>.CreateFail("Geçersiz Id", HttpStatusCode.NotFound);
                }
                return ResponseDto<EstateUpdateDto>.CreateSuccess(updateDto, $"{updateDto.title} Adlı Varlık Güncellenmiştir", HttpStatusCode.OK);
            }
        }

        public async Task<ResponseDto<EstateListDto>> GetById(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var estate = await connection.QueryFirstOrDefaultAsync<EstateListDto>(QueryEstateGetById, new{id});
                if (estate is null)
                {
                    return ResponseDto<EstateListDto>.CreateFail("Geçersiz Id", HttpStatusCode.NotFound);
                }
                return ResponseDto<EstateListDto>.CreateSuccess(estate,$"{estate.title} Adlı Varlık Getirildi",HttpStatusCode.OK);
            }
        }

        public async Task<ResponseDto<EstateDeleteDto>> Delete(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var estate = await connection.QueryFirstOrDefaultAsync<EstateDeleteDto>(QueryEstateGetById, new {id});
                if (estate is null)
                {
                    return ResponseDto<EstateDeleteDto>.CreateFail("Geçersiz Id", HttpStatusCode.NotFound);
                }
                int affectedRows = await connection.ExecuteAsync(QueryEstateDelete, new {id});
                if (affectedRows == 0)
                {
                    return ResponseDto<EstateDeleteDto>.CreateFail("Varlık Silme İşleminde Hata Oluştu", HttpStatusCode.InternalServerError);
                }
                return ResponseDto<EstateDeleteDto>.CreateSuccess(estate, $"{estate.title} Adlı Varlık Silinmiştir", HttpStatusCode.OK);
            }
        }
    }
}
