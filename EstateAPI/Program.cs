using EstateAPI.Data;
using EstateAPI.Repositories.CategoryRepo;
using EstateAPI.Repositories.EmployeeRelationComment;
using EstateAPI.Repositories.EstateRepo;
using EstateAPI.Services.Email;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<AppDbContext>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IEstateRepo, EstateRepo>();
builder.Services.AddScoped<IRelationCommentRepo, RelationCommentRepo>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.Configure<IEmailService>(builder.Configuration.GetSection("EmailSetting"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
