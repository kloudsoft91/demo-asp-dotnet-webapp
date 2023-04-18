using System.Configuration;
using Google.Protobuf.WellKnownTypes;
using ParkingWebApplication.Data;
using ParkingWebApplication.Models;

var builder = WebApplication.CreateBuilder(args);
string dbConnectionString = "";

try
{
    builder.Services.AddControllersWithViews();

    builder.Services.AddMvc();
    builder.Services.Add(new ServiceDescriptor(typeof(ParkingDBContext), new ParkingDBContext()));
}
catch (DatabaseConnectionException exc)
{
    dbConnectionString = exc._connectionString;
}
finally
{
    var app = builder.Build();

    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    if (dbConnectionString != "")
    {
        app.UseExceptionHandler("/Home/DatabaseError");
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
}