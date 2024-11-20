using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SchoolSystemTask.Helpers;
using SchoolSystemTask.Models;
using SchoolSystemTask.Repositories;
using SchoolSystemTask.services;

namespace SchoolSystemTask;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add DbContext with SQLite connection
        builder.Services.AddDbContext<MyDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Add API controllers support
        builder.Services.AddControllers();

        // Add session services
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromDays(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        // Add authentication using cookies
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options => { options.LoginPath = "/Home/LoginPage"; });

        // Add authorization with role policies
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
            options.AddPolicy("UserPolicy", policy => policy.RequireRole("User"));
        });

        // Add PayPal
        builder.Services.AddScoped<PayPalService>();

        // Add Repositories
        builder.Services.AddScoped<UserRepository>();
        builder.Services.AddScoped<TeacherRepository>();
        builder.Services.AddScoped<ClassesRepository>();
        builder.Services.AddScoped<StudentsRepository>();
        builder.Services.AddScoped<ExamsRepository>();
        builder.Services.AddScoped<StudentNoteRepository>();
        builder.Services.AddScoped<NoteTypesRepository>();
        builder.Services.AddScoped<AbsenceRepository>();
        builder.Services.AddScoped<AssignmentSubmissionRepository>();
        builder.Services.AddScoped<ActionHistoryRepository>();

        // Solve possible object cycle was detected
        builder.Services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        });

        builder.Services.AddSingleton<PayPalService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        // Enable session middleware
        app.UseSession();

        // Enable middleware for authentication and authorization
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=HomePage}/{id?}");

        // Maps API controller routes
        app.MapControllers();

        app.Run();
    }
}