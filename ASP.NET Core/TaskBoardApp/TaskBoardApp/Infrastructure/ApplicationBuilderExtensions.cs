using System.Runtime.CompilerServices;

namespace TaskBoardApp.Infrastructure
{
	public static class ApplicationBuilderExtensions
	{
		public static IApplicationBuilder UseExeptHe(this IApplicationBuilder app, IWebHostEnvironment env)
			{
				if (env.IsDevelopment())
				{
					app.UseMigrationsEndPoint();
				}
				else
				{
					app.UseExceptionHandler("/Home/Error");

					app.UseHsts();
				}
				return app;
			}
		public static IApplicationBuilder UseEndpoint(this IApplicationBuilder app)
			=> app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});

	}
}