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

		/// <summary>
		/// Get all students
		/// </summary>
		/// <returns></returns>
		[HttpGet("[action]")]
		public async Task<IEnumerable<StudentView>> GetAll()
			=> await _service.GetAll();

		/// <summary>
		/// Delete student
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("[action]")]
		public async Task<bool> Delete(Guid id)
			=> await _service.Delete(id);

		/// <summary>
		/// Create or update student
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		[HttpPost("[action]")]
		public async Task<StudentView> CreateUpdate(StudentCreateView item)
			=> await _service.CreateUpdate(item);

		/// <summary>
		/// Search student
		/// </summary>
		/// <param name="text">search text</param>
		/// <param name="page">page number</param>
		/// <param name="pageSize">page size</param>
		/// <returns></returns>
		[HttpGet("[action]")]
		public async Task<IEnumerable<StudentView>> Search(string text, int page, int pageSize)
			=> await _service.Search(text, page, pageSize);
	}
}
