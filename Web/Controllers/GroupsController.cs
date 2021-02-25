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

		[HttpGet("[action]")]
		public async Task<IEnumerable<GroupView>> FindByName(string name)
			=> await _service.FindByName(name);

		[HttpGet("[action]")]
		public async Task<IEnumerable<GroupView>> GetAll()
			=> await _service.GetAll();

		[HttpGet("[action]")]
		public async Task<bool> Delete(Guid id)
			=> await _service.Delete(id);

		[HttpPost("[action]")]
		public async Task<GroupView> CreateUpdate(GroupUpdateView item)
			=> await _service.CreateUpdate(item);

	}
}
