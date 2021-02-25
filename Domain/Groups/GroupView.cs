using System;

namespace Domain.Groups
{
	public class GroupView
	{
		public Guid Id { get; set; }
		/// <summary>
		/// Group name
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Students count
		/// </summary>
		public int Students { get; set; }

		public GroupView(Group group)
		{
			Id = group.Id;
			Name = group.Name;
			Students = group.Students.Count;
		}

		public GroupView()
		{

		}
	}
}
