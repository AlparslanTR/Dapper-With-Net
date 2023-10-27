using EstateAPI.Dtos.Employee;

namespace EstateAPI.Repositories.EmployeeRepo
{
    public interface IEmployeeRepo
    {
        Task<ResponseDto<List<EmployeeListDto>>> GetAll();
    }
}
