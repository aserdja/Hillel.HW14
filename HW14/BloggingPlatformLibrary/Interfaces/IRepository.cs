namespace BloggingPlatformLibrary.Interfaces
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
