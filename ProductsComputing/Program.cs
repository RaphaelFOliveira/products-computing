using ProductsComputing.Data.Converter.Contract;
using ProductsComputing.Data.Converter.Implementation;
using ProductsComputing.Data.VO;
using ProductsComputing.Infra.Data;
using ProductsComputing.Model;
using ProductsComputing.Repository.Contract;
using ProductsComputing.Repository.Implementation;
using ProductsComputing.Services.Contract;
using ProductsComputing.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["Database:SqlServer"]);
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped(typeof(IConvertProduct<Product, ProductVO>), typeof(ConvertProduct));
builder.Services.AddScoped(typeof(IConvertProduct<ProductVO, Product>), typeof(ConvertProduct));
builder.Services.AddScoped(typeof(IConvertProduct<Product, ProductUpdateVO>), typeof(ConvertProduct));
builder.Services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));



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
