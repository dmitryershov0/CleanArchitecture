using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Groups;
using Domain.Repositories.SubRepo;

namespace Domain.Services
{
	public class GroupService : IGroupService
	{
		private readonly IGroupRepository _groupRepository;
		private readonly IStudentRepository _studentRepository;
		public GroupService(IGroupRepository groupRepository, IStudentRepository studentRepository)
		{
			_groupRepository = groupRepository;
			_studentRepository = studentRepository;
		}

		public async Task AddStudent(Guid studentId, Guid groupId)
		{
			var student = await _studentRepository.Get(studentId);
			var group = await _groupRepository.Get(groupId);
			group.Students.Add(student);
			await _groupRepository.Update(group);
		}

		public async Task<GroupView> CreateUpdate(GroupUpdateView item)
		{
			GroupView result;
			if (item.Id == Guid.Empty)
			{
				result = new GroupView(await _groupRepository.Add(new Group { Name = item.Name }));
			}
			else
			{
				var entity = await _groupRepository.Get(item.Id);
				if (entity == null)
				{
					throw new ArgumentNullException(nameof(item));
				}
				entity.Name = item.Name;
				result = new GroupView(await _groupRepository.Update(entity));
			}
			return result;
		}

		public async Task<bool> Delete(Guid id)
		=> await _groupRepository.Delete(id);

		public async Task<IEnumerable<GroupView>> FindByName(string name)
		{
			var entities = await _groupRepository.FindBy(x => x.Name.CompareTo(name) == 0);
			return entities.Select(x => new GroupView(x)).ToArray();
		}

		public async Task<IEnumerable<GroupView>> GetAll()
		=> (await _groupRepository.GetAll()).Select(x => new GroupView(x)).ToArray();
	}
}
