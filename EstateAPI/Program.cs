using EstateAPI.Data;
using EstateAPI.Repositories.CategoryRepo;
using EstateAPI.Repositories.CityRepo;
using EstateAPI.Repositories.EmployeeRelationComment;
using EstateAPI.Repositories.EmployeeRepo;
using EstateAPI.Repositories.EstateRepo;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Projenin son a�amalar�n da izinler dinamik hale getirilecek.
builder.Services.AddSingleton<AppDbContext>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IEstateRepo, EstateRepo>();
builder.Services.AddScoped<IRelationCommentRepo, RelationCommentRepo>();
builder.Services.AddScoped<ICityRepo, CityRepo>();
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();

// FileForm ile dosya y�kleme yaparken limitlerini buradan belirleyebilirsiniz.
builder.Services.Configure<FormOptions>(settings =>
{
    settings.ValueLengthLimit = int.MaxValue;
    settings.MultipartBodyLengthLimit = int.MaxValue;
    settings.MultipartHeadersLengthLimit = int.MaxValue;
});

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
