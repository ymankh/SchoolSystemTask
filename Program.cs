using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SchoolSystemTask.Helpers;
using SchoolSystemTask.Models;
using SchoolSystemTask.Repositories;

namespace SchoolSystemTask
{
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


            // Register Swagger services
            builder.Services.AddSwaggerGen();

            // Add session services
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(30); // Session timeout
                options.Cookie.HttpOnly = true; // Make the session cookie HttpOnly for security
                options.Cookie.IsEssential = true; // Make the session cookie essential
            });

            // Add authentication using cookies
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Home/LoginPage";
                });

            // Add authorization with role policies
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
                options.AddPolicy("UserPolicy", policy => policy.RequireRole("User"));
            });


            // Add Repositories
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<TeacherRepository>();
            builder.Services.AddScoped<ClassesRepository>();
            builder.Services.AddScoped<StudentsRepository>();
            builder.Services.AddScoped<ExamsRepository>();
            builder.Services.AddScoped<StudentNoteRepository>();
            builder.Services.AddScoped<NoteTypesRepository>();
            builder.Services.AddScoped<AbsenceRebasatory>();

            // Solve possible object cycle was detected
            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();

            //Enable middleware to serve swagger - ui(HTML, JS, CSS, etc.)
            // Specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "School System Task API V1");
                c.RoutePrefix = string.Empty; // This serves Swagger UI at the root (e.g., https://localhost:{port}/)
            });
            app.UseStaticFiles();



            app.UseRouting();

            // Enable session middleware in the request pipeline
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
}