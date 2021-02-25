using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Students
{
	public class StudentCreateView
	{
		public Guid Id { get; set; }
		[Required]
		public GenderType Gender { get; set; }
		[Required, MaxLength(40)]
		public string SecondName { get; set; }
		[Required, MaxLength(40)]
		public string FirstName { get; set; }
		[MaxLength(60)]
		public string MiddleName { get; set; }
		[MinLength(6), MaxLength(16)]
		public string UniqueId { get; set; }

	}
}
