namespace EstateAPI.Dtos.Employee
{
    public record EmployeeListDto(int id, string name, string email, string password, string title,string phone, string imageUrl, bool status)
    {
    }
}
