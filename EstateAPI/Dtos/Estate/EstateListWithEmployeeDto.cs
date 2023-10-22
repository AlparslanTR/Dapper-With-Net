namespace EstateAPI.Dtos.Estate
{
    public record EstateListWithEmployeeDto(int id, string title, decimal price, int cityId, string employeeName)
    {
    }
}
