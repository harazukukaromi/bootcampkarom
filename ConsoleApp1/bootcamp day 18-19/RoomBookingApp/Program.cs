using Microsoft.EntityFrameworkCore;
using RoomBookingApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();

// Gunakan SQLite (atau SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=roombooking.db"));
// options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

var app = builder.Build();

// Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Routing default
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Rooms}/{action=Index}/{id?}");

app.Run();
