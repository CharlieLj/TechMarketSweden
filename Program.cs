using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TechMarketSweden.Data;

var builder = WebApplication.CreateBuilder(args);

// L�gg till databaskoppling f�r TechMarketSweden
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// L�gg till MVC-tj�nster
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seeda databasen vid uppstart
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();

    // K�r migreringar automatiskt
    context.Database.Migrate();
}

// Middleware-konfiguration
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Standard routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
