using System;
using System.Linq;

namespace Domain.Students
{
	public class StudentView
	{
		public Guid Id { get; set; }

		public string FIO { get; set; }

		public string [] Groups { get; set; }

		public string UniqueId { get; set; }

		public StudentView(Student student)
		{
			Id = student.Id;
			FIO = string.Concat(student.SecondName, " ", student.FirstName, " ", student.MiddleName);
			Groups = student.Groups.Select(x => x.Name).ToArray();
			UniqueId = student.UniqueId;

		}
		public StudentView()
		{

		}
	}
}
