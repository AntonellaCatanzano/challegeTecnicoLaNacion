using ChallegeContactRecords.WebApi.Business.IServices;
using ChallegeContactRecords.WebApi.Business.Services;
// using ChallegeContactRecords.WebApi.Business.Services.Extensions;
using ChallegeContactRecords.WebApi.Repositories;
// using ChallegeContactRecords.WebApi.Repositories.Extensions;
using ChallegeContactRecords.WebApi.Repositories.IRepository;
using ContactRecords.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IContactRecordsRepository, ContactRecordsRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

builder.Services.AddTransient<IContactRecordsService, ContactRecordsService>();
builder.Services.AddTransient<IAddressService, AddressService>();
//  builder.Services.AddServicesRepository();
//  builder.Services.AddServicesBusiness();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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







