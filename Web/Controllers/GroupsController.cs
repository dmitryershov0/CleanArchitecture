using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Groups;
using Microsoft.AspNetCore.Authorization;
using Domain.Services;
using System;

namespace Web.Controllers
{
	[Produces("application/json")]
	[ApiController]
	[Authorize]
	[Route("[controller]")]
	public class GroupsController : ControllerBase
	{
		private readonly IGroupService _service;
		public GroupsController(IGroupService service) 
		{
			_service = service;
		}
		/// <summary>
		/// Find groups
		/// </summary>
		/// <param name="name">Group name</param>
		/// <returns></returns>
		[HttpGet("[action]")]
		public async Task<IEnumerable<GroupView>> FindByName(string name)
			=> await _service.FindByName(name);

		/// <summary>
		/// Get all groups
		/// </summary>
		/// <returns></returns>
		[HttpGet("[action]")]
		public async Task<IEnumerable<GroupView>> GetAll()
			=> await _service.GetAll();

		/// <summary>
		/// Delete group
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("[action]")]
		public async Task<bool> Delete(Guid id)
			=> await _service.Delete(id);

		/// <summary>
		/// Create or update group
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		[HttpPost("[action]")]
		public async Task<GroupView> CreateUpdate(GroupUpdateView item)
			=> await _service.CreateUpdate(item);

		/// <summary>
		/// Add student to group
		/// </summary>
		/// <param name="studentId"></param>
		/// <param name="groupId"></param>
		/// <returns></returns>
		[HttpGet("[action]")]
		public async Task AddToGroup(Guid studentId, Guid groupId)
			=> await _service.AddStudent(studentId, groupId);

	}
}
