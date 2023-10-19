using EstateAPI.Dtos.Contact;

namespace EstateUI.Services.Email
{
    public interface IEmailService
    {
        Task SendMail(ContactDto contact);
    }
}
