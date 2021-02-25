using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Repositories
{
	public interface IRepository<T>
	{
		Task<T> Get(Guid id);
		Task<T> Add(T item);
		Task<T> Update(T item);
		Task<bool> Delete(Guid Id);
		Task<IEnumerable<T>> GetAll();
		Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate);
	}
}
