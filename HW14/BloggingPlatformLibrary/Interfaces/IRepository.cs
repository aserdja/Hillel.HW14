namespace BloggingPlatformLibrary.Interfaces
{
	public interface IRepository<T>
	{
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		T Get(int id);
	}
}
