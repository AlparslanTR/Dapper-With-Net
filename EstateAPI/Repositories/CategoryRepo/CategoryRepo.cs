using Dapper;
using EstateAPI.Data;
using EstateAPI.Dtos.Category;
using System.Net;

namespace EstateAPI.Repositories.CategoryRepo
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _context;
        private const string QueryCategoryList = "Select * from Category";
        private const string QueryCategoryAdd = "Insert into Category (Name,Status) values (@Name,@Status)";
        private const string QueryCategoryUpdate = "Update Category Set Name = @Name, Status=@Status where Id =@id";
        private const string QueryCategoryDelete = "Delete from Category where Id =@id";
        private const string QueryCategoryById = "SELECT Id, Name, Status FROM Category WHERE Id = @id";


        public CategoryRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<List<CategoryListDto>>> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<CategoryListDto>(QueryCategoryList);
                if (values is null || !values.Any())
                {
                    return ResponseDto<List<CategoryListDto>>.CreateFail("Hiçbir Veri Bulunamadı", HttpStatusCode.NotFound);
                }
                return ResponseDto<List<CategoryListDto>>.CreateSuccess(values.ToList(), "Başarılı", HttpStatusCode.OK);
            }
        }

        public async Task<ResponseDto<CategoryCreateDto>> Create(CategoryCreateDto categoryCreateDto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", categoryCreateDto.name);
            parameters.Add("@Status", categoryCreateDto.status);

            using (var connection = _context.CreateConnection())
            {
                var affectedRows = await connection.ExecuteAsync(QueryCategoryAdd, parameters);

                if (affectedRows > 0)
                {
                    return ResponseDto<CategoryCreateDto>.CreateSuccess(categoryCreateDto, $"{categoryCreateDto.name} Adlı Kategori Başarıyla Eklendi", HttpStatusCode.OK);
                }
                else
                {
                    return ResponseDto<CategoryCreateDto>.CreateFail("Veri Eklenirken Hata Oluştu", HttpStatusCode.BadRequest);
                }
            }
        }

        public async Task<ResponseDto<CategoryUpdateDto>> Update(CategoryUpdateDto categoryUpdateDto)
        {
            using (var connection = _context.CreateConnection())
            {
                int? category = await connection.ExecuteAsync(QueryCategoryUpdate, categoryUpdateDto);
                if (category is null)
                {
                    return ResponseDto<CategoryUpdateDto>.CreateFail("Geçersiz Id",HttpStatusCode.NotFound);
                }
                return ResponseDto<CategoryUpdateDto>.CreateSuccess(categoryUpdateDto,"Kategori Güncelleme İşlemi Başarılı",HttpStatusCode.OK);
            }
        }

        public async Task<ResponseDto<CategoryDeleteDto>> Delete(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var category = await connection.QueryFirstOrDefaultAsync<CategoryDeleteDto>(QueryCategoryById, new { id });
                if (category is null)
                {
                    return ResponseDto<CategoryDeleteDto>.CreateFail("Geçersiz Id", HttpStatusCode.NotFound);
                }
                int affectedRows = await connection.ExecuteAsync(QueryCategoryDelete, new { id });

                if (affectedRows == 0)
                {
                    return ResponseDto<CategoryDeleteDto>.CreateFail("Kategori Silme İşleminde Hata Oluştu", HttpStatusCode.InternalServerError);
                }
                return ResponseDto<CategoryDeleteDto>.CreateSuccess(category, $"{category.name} Adlı Kategori Silindi", HttpStatusCode.OK);
            }
        }

        public async Task<ResponseDto<CategoryListDto>> GetById(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var category = await connection.QueryFirstOrDefaultAsync<CategoryListDto>(QueryCategoryById, new { id });
                if (category is null)
                {
                    return ResponseDto<CategoryListDto>.CreateFail("Geçersiz Id",HttpStatusCode.NotFound);
                }
                return ResponseDto<CategoryListDto>.CreateSuccess(category, $"{category.name} Adlı Kategori Getirildi", HttpStatusCode.OK);            
            }
        }
    }
}
