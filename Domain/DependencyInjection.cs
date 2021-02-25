using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddDomain(this IServiceCollection services)
		{
			services.AddScoped<IGroupService, GroupService>();
			services.AddScoped<IStudentService, StudentService>();
			return services;
		}
	}
}
