using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MyDiskApp.Middleware;
using MyDiskApp.Services;
using MyDiskApp.Services.Interface;
using MyDiskEF;
using MyDiskServices.Helpers;
using MyDiskServices.Interfaces;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<UserContext>(option => option.UseSqlServer(connection));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.LoginPath = "/Account/login");

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAddUser, AddUserService>();
builder.Services.AddScoped<IGetUser, GetUserService>();
builder.Services.AddScoped<ILogin, LoginService>();
builder.Services.AddScoped<IUserIsExist, UserIsExistService>();
builder.Services.AddScoped<IAddFile, AddFileService>();
builder.Services.AddScoped<IGetAllFiles, GetAllFilesServices>();
builder.Services.AddScoped<IDeleteFile, DeleteFileService>();
builder.Services.AddScoped<ILoggy, LoggyService>();
builder.Services.AddScoped<IRecoverPassword, RecoverPasswordService>();
builder.Services.AddTransient<IHashPassword, HashPasswordService>();

var app = builder.Build();

app.UseDeveloperExceptionPage();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
