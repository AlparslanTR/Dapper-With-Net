namespace EstateAPI.Dtos.Estate
{
    public record EstateListWithEmployeeDto(int id, string title, decimal price, string city, string district, string employeeName)
    {
    }
}
