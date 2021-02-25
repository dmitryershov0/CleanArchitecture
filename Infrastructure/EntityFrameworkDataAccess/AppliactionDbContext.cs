using Domain.Groups;
using Domain.Students;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.EntityFrameworkDataAccess
{
	public sealed class AppliactionDbContext : DbContext
	{
		public DbSet<Student> Students { get; set; }
		public DbSet<Group> Groups { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Student>()
				.HasIndex(u => u.UniqueId)
				.IsUnique();

			SeedData(builder);
		}
		private void SeedData(ModelBuilder builder)
		{
			builder.Entity<Student>()
				.HasData(new Student
				{
					Id = Guid.NewGuid(),
					Gender = GenderType.Female,
					SecondName = "Tests",
					FirstName = "test123",
				}); 
			builder.Entity<Student>()
				.HasData(new Student
				{
					Id = Guid.NewGuid(),
					Gender = GenderType.Male,
					SecondName = "adasda",
					FirstName = "1234",
				});
			builder.Entity<Student>()
				.HasData(new Student
				{
					Id = Guid.NewGuid(),
					Gender = GenderType.Female,
					SecondName = "asdasd11",
					FirstName = "sss",
					UniqueId = "ssssss"
				});
			builder.Entity<Group>()
				.HasData(new Group
				{
					Id = Guid.NewGuid(),
					Name = "TestGroup"
				});
			builder.Entity<Group>()
				.HasData(new Group
				{
					Id = Guid.NewGuid(),
					Name = "TestGroup"
				});
		}
		public AppliactionDbContext(DbContextOptions options) : base(options)
		{
			Database.EnsureCreated();
		}
	}
}
