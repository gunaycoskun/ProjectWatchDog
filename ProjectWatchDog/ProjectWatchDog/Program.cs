using WatchDog;
using WatchDog.src.Enums;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddWatchDogServices(opt =>
{
    opt.IsAutoClear = false;
    opt.SetExternalDbConnString = "Server=localhost;Port=5432;Database=TestWatchDog;User Id=postgres;Password=Lzlzpy06;";
    opt.SqlDriverOption = WatchDogSqlDriverEnum.PostgreSql;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseWatchDogExceptionLogger();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseWatchDog(opt =>
{
    opt.WatchPageUsername = "admin";
    opt.WatchPagePassword = "Qwerty@123";
});
app.Run();
