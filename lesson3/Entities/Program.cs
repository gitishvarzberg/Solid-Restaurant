using lesson3;
using Restaurant.Core;
using Restaurant.Core.Repositories;
using Restaurant.Core.Restaurant;
using Restaurant.Core.Services;
using Restaurant.Data;
using Restaurant.Data.Repositories;
using Restaurant.Service.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
options.JsonSerializerOptions.WriteIndented = true;

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDoseRepository,DoseRepository>();
builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>(); 

builder.Services.AddScoped<IDoseService,DoseService>();
builder.Services.AddScoped<IEmployeeService,EmployeeService>(); 
builder.Services.AddScoped<IOrderService,OrderService>();

builder.Services.AddDbContext<DataContext>();
builder.Services.AddAutoMapper(typeof(MappingProfile));


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
