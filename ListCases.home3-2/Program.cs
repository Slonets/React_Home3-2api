using DateAccess.Data;
using ListCases.home3_2;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//формуємо рядок підключення
string connection = builder.Configuration.GetConnectionString("CaseConnection") ?? throw new InvalidOperationException("Connection string 'WebAppLibraryContext' not found.");

//підключення бази даних через рядок підключення
builder.Services.AddDbContext<CaseDbContext>(options => options.UseSqlServer(connection));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Додаємо фейкові дані
app.SeedData();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
