

////using Microsoft.AspNetCore.Authentication.JwtBearer;
////using Microsoft.AspNetCore.Cors.Infrastructure;
////using Microsoft.EntityFrameworkCore;
////using Microsoft.EntityFrameworkCore.Migrations;
////using Microsoft.IdentityModel.Tokens;
////using PhotoSmart.Api;
////using PhotoSmart.Core;
////using PhotoSmart.Core.IRepositories;
////using PhotoSmart.Core.IServices;
////using PhotoSmart.Data;
////using PhotoSmart.Data.Repositories;
////using PhotoSmart.Service.Services;
////using System.Configuration;
////using System.Text;

////var builder = WebApplication.CreateBuilder(args);



////builder.Services.AddAuthentication(options =>
////{
////    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
////    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
////})
////.AddJwtBearer(options =>
////{
////    options.TokenValidationParameters = new TokenValidationParameters
////    {
////        ValidateIssuer = true,
////        ValidateAudience = true,
////        ValidateLifetime = true,
////        ValidateIssuerSigningKey = true,
////        ValidIssuer = builder.Configuration["Jwt:Issuer"],
////        ValidAudience = builder.Configuration["Jwt:Audience"],
////        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
////    };
////});

////// ����� ������ �������-�������
////builder.Services.AddAuthorization(options =>
////{
////    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
////    options.AddPolicy("EditorOrAdmin", policy => policy.RequireRole("Editor", "Admin"));
////    options.AddPolicy("ViewerOnly", policy => policy.RequireRole("Viewer"));
////});
////// Add services to the container.
////builder.Services.AddScoped<IEventRepository, EventRepository>();
////builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();
////builder.Services.AddScoped<IUserRepository, UserRepository>();
////builder.Services.AddScoped<IGuestRepository, GuestRepository>();

////builder.Services.AddScoped<IEventService, EventService>();
////builder.Services.AddScoped<IPhotoService, PhotoService>();
////builder.Services.AddScoped<IUserService,UserService>();
////builder.Services.AddScoped<IGuestService,GuestService>();

////builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
////builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();


////builder.Services.AddControllers();
////// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
////builder.Services.AddOpenApi();
////var connetionString = builder.Configuration.GetConnectionString("PhotoSmartContext");  
//////var connetionString = "server=localhost;database=photo_share_db;user=root;password=1234;";
////builder.Services.AddDbContext<PhotoSmartContext>(options =>
////    options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString),options=>options.CommandTimeout(60)));

////builder.Services.AddAutoMapper(typeof(MappingPostProfile), typeof(MappingProfile));

//////services.AddAutoMapper(typeof(MappingProfile), typeof(MappingPostProfile));
////builder.Services.AddCors(options =>
////{
////    options.AddPolicy("AllowAllOrigins", builder =>
////    {
////        builder.AllowAnyOrigin()
////               .AllowAnyMethod()
////               .AllowAnyHeader();
////    });
////});


////var app = builder.Build();

////// Configure the HTTP request pipeline.
////if (app.Environment.IsDevelopment())
////{
////    app.UseDeveloperExceptionPage();
////    app.MapOpenApi();//??

////}
////else
////{
////    app.UseExceptionHandler("/Home/Error");
////    app.UseHsts();
////}

//////app.UseHttpsRedirection();

////app.UseRouting();
////app.UseAuthentication();
////app.UseAuthorization();
////app.MapControllers();

////app.Run();


//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;
//using PhotoSmart.Api;
//using PhotoSmart.Core.IRepositories;
//using PhotoSmart.Core.IServices;
//using PhotoSmart.Core;
//using PhotoSmart.Data.Repositories;
//using PhotoSmart.Data;
//using PhotoSmart.Service.Services;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddScoped<IEventRepository, EventRepository>();
//builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IGuestRepository, GuestRepository>();
//builder.Services.AddScoped<IAuthRepository, AuthRepository>();

//builder.Services.AddScoped<IEventService, EventService>();
//builder.Services.AddScoped<IPhotoService, PhotoService>();
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IGuestService, GuestService>();
//builder.Services.AddScoped<IAuthService, AuthService>();

//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

//builder.Services.AddAutoMapper(typeof(MappingPostProfile), typeof(MappingProfile));

//builder.Services.AddControllers();

//// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

//builder.Services.AddSwaggerGen();

//var connetionString = builder.Configuration.GetConnectionString("PhotoSmartContext");
//builder.Services.AddDbContext<PhotoSmartContext>(options =>
//    options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString), options => options.CommandTimeout(60)));


////services.AddAutoMapper(typeof(MappingProfile), typeof(MappingPostProfile));
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAllOrigins", builder =>
//    {
//        builder.AllowAnyOrigin()
//               .AllowAnyMethod()
//               .AllowAnyHeader();
//    });
//});

////// ����� JWT Authentication
////builder.Services.AddAuthentication(options =>
////{
////    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
////    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
////})
////.AddJwtBearer(options =>
////{

////    options.TokenValidationParameters = new TokenValidationParameters
////    {
////        ValidateIssuer = true,
////        ValidateAudience = true,
////        ValidateLifetime = true,
////        ValidateIssuerSigningKey = true,
////        ValidIssuer = builder.Configuration["Jwt:Issuer"],
////        ValidAudience = builder.Configuration["Jwt:Audience"],
////        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
////    };
////});

//// ����� ������ �������-�������
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
//    options.AddPolicy("EditorOrAdmin", policy => policy.RequireRole("Editor", "Admin"));
//    options.AddPolicy("ViewerOnly", policy => policy.RequireRole("Viewer"));
//});


//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//    app.UseDeveloperExceptionPage();
//    app.UseSwagger(); // ���� ���
//    app.UseSwaggerUI(c => // ���� ���
//    {
//        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhotoSmart API V1");
//        c.RoutePrefix = string.Empty; // ��� ���� �-Swagger �-root
//    });

//}
//else
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}

////app.UseHttpsRedirection();
//app.UseRouting();
//app.UseAuthentication();//before UseAuthorization
//app.UseAuthorization();
//app.MapControllers();

//app.Run();



using Amazon.S3.Model;
using Amazon.S3;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PhotoSmart.Api;
using PhotoSmart.Core.IRepositories;
using PhotoSmart.Core.IServices;
using PhotoSmart.Core;
using PhotoSmart.Data.Repositories;
using PhotoSmart.Data;
using PhotoSmart.Service.Services;
using System.Text;



using Amazon.Extensions.NETCore.Setup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IGuestRepository, GuestRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGuestService, GuestService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

builder.Services.AddAutoMapper(typeof(MappingPostProfile), typeof(MappingProfile));

builder.Services.AddControllers();

builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddSingleton<IAmazonS3>(serviceProvider =>
{
    var options = serviceProvider.GetRequiredService<IOptions<AWSOptions>>().Value;

    // ����� Credentials ����� ����
    var credentials = new Amazon.Runtime.BasicAWSCredentials(
    builder.Configuration["AWS:AccessKey"],
        builder.Configuration["AWS:SecretKey"]
    );

    // ����� Region
    var region = Amazon.RegionEndpoint.GetBySystemName(builder.Configuration["AWS:Region"]);

    return new AmazonS3Client(credentials, region);
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();
//Console.WriteLine(builder.Configuration["ConnectionStrings:PhotoSmartContext"]);
//var connectionString = builder.Configuration["ConnectionStrings:PhotoSmartContext"];
//builder.Services.AddDbContext<PhotoSmartContext>(options =>
//    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), options => options.CommandTimeout(60)));

var connectionString = builder.Configuration.GetConnectionString("PhotoSmartContext");
builder.Services.AddDbContext<PhotoSmartContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), options => options.CommandTimeout(60)));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Add JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// Add role-based authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("EditorOrAdmin", policy => policy.RequireRole("Editor", "Admin"));
    // options.AddPolicy("ViewerOnly", policy => policy.RequireRole("Viewer"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhotoSmart API V1");
        c.RoutePrefix = string.Empty; // To access Swagger at the root
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();


