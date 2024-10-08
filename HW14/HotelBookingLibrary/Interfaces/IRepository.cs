using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingLibrary.Interfaces
{
	public interface IRepository<T>
	{
		Task Add(T entity);
		Task Update(T entity);
		Task Delete(T entity);
		Task<T> Get(int id);
		Task<IEnumerable<T>> GetAll();
		Task<IEnumerable<T>> GetAllById(int id);
	}
}
