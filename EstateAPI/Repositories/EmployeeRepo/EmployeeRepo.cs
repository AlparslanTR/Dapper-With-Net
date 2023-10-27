using Dapper;
using EstateAPI.Data;
using EstateAPI.Dtos.City;
using EstateAPI.Dtos.Employee;
using System.Net;

namespace EstateAPI.Repositories.EmployeeRepo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly AppDbContext _context;
        private const string QueryListEmployee = "Select * from Employee";

        public EmployeeRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<List<EmployeeListDto>>> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var employees = await connection.QueryAsync<EmployeeListDto>(QueryListEmployee);
                if (employees == null || !employees.Any())
                {
                    return ResponseDto<List<EmployeeListDto>>.CreateFail("Hiçbir Veri Bulunamadı", HttpStatusCode.NotFound);
                }
                return ResponseDto<List<EmployeeListDto>>.CreateSuccess(employees.ToList(), "Başarılı", HttpStatusCode.OK);
            }
        }
    }
}
