using Domain.Groups;
using Domain.Repositories.SubRepo;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.EntityFrameworkDataAccess.Repositories.SubRepo
{
	public class GroupRepository : Repository<Group>, IGroupRepository
	{

		public GroupRepository(AppliactionDbContext context) : base(context)
		{
		}
	}
}
