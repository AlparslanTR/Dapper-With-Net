using Dapper;
using EstateAPI.Data;
using EstateAPI.Dtos.Contact;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;


namespace EstateAPI.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        private const string QueryContactCreate = "Insert into Contact (Name, Email, Message) values(@Name, @Email,@Message)";

        public EmailService(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task SendMail(ContactDto contact)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Gönderen: ", contact.email));
            email.To.Add(new MailboxAddress("Alıcı :", _configuration["EmailSetting:EmailName"]));
            email.Body = new TextPart("plain")
            {
                Text = $"Ad: {contact.name}\nE-posta: {contact.email} \nMesaj: {contact.message}"
            };

            using var client = new SmtpClient();
            client.Connect(_configuration["EmailSetting:EmailHost"], Convert.ToInt32(_configuration["EmailSetting:EmailPort"]), true);
            client.Authenticate(_configuration["EmailSetting:EmailUsername"], _configuration["EmailSetting:EmailPassword"]);
            client.Send(email);
            client.Disconnect(true);

            var parameters = new DynamicParameters();
            parameters.Add("@Name", contact.name);
            parameters.Add("@Email", contact.email);
            parameters.Add("@Message", contact.message);

            using (var connection = _context.CreateConnection())
            {
                var value =await connection.ExecuteAsync(QueryContactCreate, parameters);
            }
            

        }
    }
}
