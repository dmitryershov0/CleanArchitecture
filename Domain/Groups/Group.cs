using Domain.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Groups
{
	public class Group
	{
		[Key]
		public Guid Id { get; set; }
		[Required, MaxLength(25)]
		public string Name { get; set; }

		public virtual List<Student> Students { get; set; }
		public Group()
		{
			Students = new List<Student>();
		}
	}
}
