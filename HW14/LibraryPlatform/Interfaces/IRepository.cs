namespace LibraryPlatform.Interfaces
{
	public interface IRepository<T>
	{
		Task Add(T entity);
		Task<IEnumerable<T>> GetAll();
		Task Update(T entity);
		Task Delete(T entity);
	}
}
