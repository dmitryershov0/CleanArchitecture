using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Groups
{
	public class GroupUpdateView
	{
		public Guid Id { get; set; }
		[Required, MaxLength(25)]
		public string Name { get; set; }
	}
}
