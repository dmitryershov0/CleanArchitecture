using Domain.Students;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
	public interface IStudentService
	{
		Task<IEnumerable<StudentView>> Search(string text, int page, int pageSize);

		Task<IEnumerable<StudentView>> GetAll();

		Task<StudentView> CreateUpdate(StudentCreateView item);

		Task<bool> Delete(Guid Id);
	}
}
