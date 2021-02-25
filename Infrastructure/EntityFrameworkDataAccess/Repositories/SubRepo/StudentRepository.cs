using Domain.Repositories.SubRepo;
using Domain.Students;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.EntityFrameworkDataAccess.Repositories.SubRepo
{
	public class StudentRepository : Repository<Student>, IStudentRepository
	{
		public StudentRepository(AppliactionDbContext context)
			: base(context)
		{
		}

		public async Task<Student> GetByUniqueId(string uniqueId)
		=> (await FindBy(student => student.UniqueId.CompareTo(uniqueId) == 0)).FirstOrDefault();
		
	}
}
