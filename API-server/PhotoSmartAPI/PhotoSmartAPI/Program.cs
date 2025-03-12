//namespace PhotoSmart.API
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            // Add services to the container.

//            builder.Services.AddControllers();
//            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//            builder.Services.AddOpenApi();

//            var app = builder.Build();

//            // Configure the HTTP request pipeline.
//            if (app.Environment.IsDevelopment())
//            {
//                app.MapOpenApi();
//            }

//            app.UseHttpsRedirection();

//            app.UseAuthorization();


//            app.MapControllers();

//            app.Run();
//        }
//    }
//}



//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PhotoSmart.Core.IRepositories;
using PhotoSmart.Core.IServices;
using PhotoSmart.Data;
using PhotoSmart.Data.Repositories;
using PhotoSmart.Service.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
//services.AddDbContext<PhotoSmartContext>(options =>
//       options.UseMySql("YourConnectionStringHere", new MySqlServerVersion(new Version(8, 0, 21))));
//var connectionString = "server=localhost;database=photo_smart_db;user=root;password=1234";
var connectionString = builder.Configuration.GetConnectionString("PhotoSmartDB");
builder.Services.AddDbContext<PhotoSmartContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
    mysqlOptions => mysqlOptions.CommandTimeout(60)));



// Add services to the container.
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<AlbumService>();
builder.Services.AddScoped<PhotoService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
//    mysqlOptions => mysqlOptions.CommandTimeout(60));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.MapOpenApi();//??
    
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
