using Domain.Repositories.SubRepo;
using Infrastructure.EntityFrameworkDataAccess.Repositories.SubRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.EntityFrameworkDataAccess
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddDbContext<AppliactionDbContext>(options =>
					options.UseLazyLoadingProxies()
					.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
						b => b.MigrationsAssembly(typeof(AppliactionDbContext).Assembly.FullName)));
			services.AddScoped<IStudentRepository, StudentRepository>();
			services.AddScoped<IGroupRepository, GroupRepository>();
			return services;
		}
	}
}
