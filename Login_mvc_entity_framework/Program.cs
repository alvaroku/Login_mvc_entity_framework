using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Login_mvc_entity_framework.Areas.Identity.Data;
using Login_mvc_entity_framework.Models;

var builder = WebApplication.CreateBuilder(args);

//para login
string connString = ConfigurationExtensions.GetConnectionString(builder.Configuration, "DefaultConnectionString");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connString)
);

builder.Services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>();;

//


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//para verificar la creaci�n de las tablas
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.EnsureCreated();
    }
    catch (System.Exception pException)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(pException, "An error ocurred creating the data base.");
    }
}
//

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
app.UseAuthentication();;

app.UseAuthorization();

/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
*/
//para login
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});
app.Run();
