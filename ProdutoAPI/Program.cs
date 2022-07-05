using Microsoft.EntityFrameworkCore;
using ProdutoAPI.Models;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Produtos") ?? "Data Source=DbProdutos.db";

// Add services to the container.
builder.Services.AddControllers();


builder.Services.AddSqlite<ProdutoContexto>(connectionString);


//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "TodoApi", Version = "v1" });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1"));


}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();