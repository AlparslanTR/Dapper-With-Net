using EstateAPI.Dtos.Contact;

namespace EstateAPI.Services.Email
{
    public interface IEmailService
    {
        Task SendMail(ContactDto contact);
    }
}
