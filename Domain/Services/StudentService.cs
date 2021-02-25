using Domain.Repositories.SubRepo;
using Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services
{
	public class StudentService : IStudentService
	{
		private readonly IStudentRepository _studentRepository;
		public StudentService(IStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;
		}
		public async Task<StudentView> CreateUpdate(StudentCreateView item)
		{
			StudentView result;
			if (item.Id == Guid.Empty)
			{
				result = new StudentView(await _studentRepository.Add(new Student
				{
					FirstName = item.FirstName,
					SecondName = item.SecondName,
					Gender = item.Gender,
					MiddleName = item.MiddleName,
					UniqueId = item.UniqueId
				})) ;
			}
			else
			{
				var entity = await _studentRepository.Get(item.Id);
				if (entity == null)
				{
					throw new ArgumentNullException(nameof(item));
				}
				entity.FirstName = item.FirstName;
				entity.SecondName = item.SecondName;
				entity.MiddleName = item.MiddleName;
				entity.Gender = item.Gender;
				entity.UniqueId = item.UniqueId;
				result = new StudentView(await _studentRepository.Update(entity));
			}
			return result;
		}

		public async Task<bool> Delete(Guid id)
		=> await _studentRepository.Delete(id);

		public async Task<IEnumerable<StudentView>> GetAll()
		=> (await _studentRepository.GetAll()).Select(x => new StudentView(x)).ToArray();

		public async Task<IEnumerable<StudentView>> Search(string text, int page, int pageSize)
		{
			var entities = await _studentRepository.GetAll();
			entities = entities.Where(x => string.Concat(x.SecondName, " ", x.FirstName, " ", x.MiddleName)
				.ToLower().Contains(text.ToLower())|| x.Groups.FirstOrDefault(y => y.Name.ToLower()
				  .Contains(text.ToLower())) != null);

			var result = entities.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.Select(x=>new StudentView(x))
				.ToArray();

			return result;
		}
	}
}
