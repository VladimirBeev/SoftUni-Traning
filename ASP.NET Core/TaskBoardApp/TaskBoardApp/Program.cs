using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Infrastructure;

var builder = WebApplication
	.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services
	.AddDbContext<ApplicationDbContext>(options => options
		.UseSqlServer(connectionString));

builder.Services
	.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
	.AddDefaultIdentity<IdentityUser>(options => options
		.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();


var app = builder.Build();

app.UseExeptHe(app.Environment);

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoint();

app.MapRazorPages();

app.Run();
