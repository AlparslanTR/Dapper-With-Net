namespace EstateAPI.Dtos.Employee
{
    public record EmployeeCreateDto(int id, string name, string email ,string password, string title, string phone, string imageUrl, bool status)
    {
    }
}
