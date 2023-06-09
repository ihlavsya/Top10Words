using Microsoft.EntityFrameworkCore;
using Top10Words.BL;
using Top10Words.DAL;
using Top10Words.DAL.EFCore;
using Top10Words.DAL.Entities;
using Top10Words.DAL.Repositories;
using Top10WordsWebAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddDbContext<Top10WordsContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(Top10WordsContext).Assembly.FullName)));

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddScoped<DbContext, Top10WordsContext>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IRepository<Book>, GenericRepository<Book>>();

builder.Services.AddControllers();
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
