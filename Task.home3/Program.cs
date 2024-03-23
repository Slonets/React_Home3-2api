using DateAccess.Date;
using Microsoft.EntityFrameworkCore;
using Task.home3;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("TaskConnection") ?? throw new InvalidOperationException("Connection string 'WebAppLibraryContext' not found.");


//���������� ���� ����� ����� ����� ����������
builder.Services.AddDbContext<TaskDbContext>(options =>
{
    options.UseSqlServer(connection);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//�� ������ ������� � ������ ������
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.SeedData();

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
