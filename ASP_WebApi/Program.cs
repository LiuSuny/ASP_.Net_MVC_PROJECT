using ASP_WebApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//next we want to tell our builder that we need to use entityframework.core(sort of dependence injection )
builder.Services.AddDbContext<ApplicationDBConnection>(option => 
option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); //using option to tell our connection that we want to use sql server note: we purposely added defaultConnect1 on jason appsetting is different
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
