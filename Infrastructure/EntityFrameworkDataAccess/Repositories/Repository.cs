using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.EntityFrameworkDataAccess.Repositories
{
	public class Repository<T> : IRepository<T>
		where T : class
	{
		private readonly AppliactionDbContext _context;
		private DbSet<T> _dbSet;

		public Repository(AppliactionDbContext context)
		{
			_context = context ??
				throw new ArgumentNullException(nameof(context));
			_dbSet = _context.Set<T>();
		}

		public async Task<T> Add(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item));
			}
			var result = await _dbSet.AddAsync(item);
			await _context.SaveChangesAsync();
			return result.Entity;
		}

		public async Task<bool> Delete(Guid id)
		{
			var item = await Get(id);
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item));
			}
			_dbSet.Remove(item);
			return (await _context.SaveChangesAsync()) == 1;
		}

		public async Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate)
			=> await _dbSet.AsNoTracking().Where(predicate).ToArrayAsync();


		public async Task<T> Get(Guid id)
			=> await _dbSet.FindAsync(id);

		public async Task<IEnumerable<T>> GetAll()
			=> await _dbSet.ToArrayAsync();

		public async Task<T> Update(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item));
			}
			var result = _dbSet.Update(item).Entity;
			await _context.SaveChangesAsync();
			return result;
		}
	}
}
