namespace EstateAPI.Dtos.Estate
{
    public record EstateCreateDto(string title, decimal price, string coverImage, int cityId, string address,string description, string type, int categoryId, int employeeId)
    {
    }
}
