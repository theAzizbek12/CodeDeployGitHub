//using FluentAssertions.Common;
using Intranet.DBContexts;
using Intranet.Repository;
using Microsoft.EntityFrameworkCore;
//using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//public IConfiguration Configuration { get; }

void ConfigureServices(IServiceCollection services) 
{
    builder.Services.AddControllers();
    builder.Services.AddDbContext<StudentContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StudentDB")));
    builder.Services.AddTransient<IStudentRepository, StudentRepository>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
