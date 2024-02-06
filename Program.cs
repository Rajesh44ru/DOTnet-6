using CollegeApp.MyLogging;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TestWEBAPI.Configuration;
using TestWEBAPI.Repository;

//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Information()
//    .WriteTo.File("Log/log.txt",rollingInterval:RollingInterval.Minute)
//    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddLog4Net();

#region serilog
//builder.Host.UseSerilog(); // <-- Add this line //override the built in logger
//builder.Logging.AddSerilog(); // <-- Add this line // use this for built in log and serilog


// Add services to the container.
//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();
//builder.Logging.AddDebug();
#endregion


builder.Services.AddDbContext<CollegeDB>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("CollegeAppDBConnection")));

builder.Services.AddControllers(
    //options=>options.ReturnHttpNotAcceptable=true
    )
    .AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMyLogger, LogToDB>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped(typeof(ICollegeRepository<>), typeof(CollegeRepository<>));


builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
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
