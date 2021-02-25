using Domain.Groups;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
	public interface IGroupService
	{
		Task<IEnumerable<GroupView>> FindByName(string name);
		Task AddStudent(Guid studentId, Guid groupId);

		Task<IEnumerable<GroupView>> GetAll();

		Task<GroupView> CreateUpdate(GroupUpdateView item);
		Task<bool> Delete(Guid Id);
	}
}
