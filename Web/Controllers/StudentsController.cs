using Domain.Services;
using Domain.Students;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{
	[Produces("application/json")]
	[ApiController]
	[Authorize]
	[Route("[controller]")]
	public class StudentsController : ControllerBase
	{
		private readonly IStudentService _service;
		public StudentsController(IStudentService service)
		{
			_service = service;
		}

		[HttpGet("[action]")]
		public async Task<IEnumerable<StudentView>> GetAll()
			=> await _service.GetAll();

		[HttpGet("[action]")]
		public async Task<bool> Delete(Guid id)
			=> await _service.Delete(id);

		[HttpPost("[action]")]
		public async Task<StudentView> CreateUpdate(StudentCreateView item)
			=> await _service.CreateUpdate(item);

		[HttpGet("[action]")]
		public async Task<IEnumerable<StudentView>> Search(string text, int page, int pageSize)
			=> await _service.Search(text, page, pageSize);
	}
}
