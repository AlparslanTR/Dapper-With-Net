namespace EstateAPI.Dtos.Estate
{
    public record EstateCreateDto(string title, decimal price, string coverImage, string city, string district, string address,string description, int categoryId, int employeeId)
    {
    }
}
