using KYC_Aggregation_API_Service.Services;
using KYC_Cache_Service.Caching;
using KYC_Cache_Service.Extensions;
using KYC_Data_Fetching_Service.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<KYCCachingContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("KYC_Aggregation_DB")));

builder.Services.AddScoped<KYCDataService>();

builder.Services.AddCacheServices(builder.Configuration);
builder.Services.AddExternalDataClients(builder.Configuration);

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
