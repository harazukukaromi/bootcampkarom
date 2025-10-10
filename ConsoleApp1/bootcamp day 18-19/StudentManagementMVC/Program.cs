using Microsoft.EntityFrameworkCore;
using StudentManagementMVC.Data;
using StudentManagementMVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Entity Framework and configure SQLite database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? 
                     "Data Source=studentmanagement.db"));

// Register business layer service
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Apply database migrations automatically
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
