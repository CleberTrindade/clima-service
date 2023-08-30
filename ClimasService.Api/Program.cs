using ClimasService.Application.ExtenalService;
using ClimasService.Application.Mappers;
using ClimasService.Infrastructure.ExternalService.BrasilApi.Intefaces;
using ClimasService.Infrastructure.ExternalService.BrasilApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClimaService, ClimaService>();
builder.Services.AddScoped<IBrasilApiService, BrasilApiService>();

builder.Services.AddAutoMapper(typeof(ClimaMapper));

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c => {
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
