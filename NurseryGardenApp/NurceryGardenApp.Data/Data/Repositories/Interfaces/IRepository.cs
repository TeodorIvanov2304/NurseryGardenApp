namespace NurseryGardenApp.Data.Data.Repositories.Interfaces
{
	public interface IRepository<TType,TId> where TType : class where TId : struct
	{
		TType? GetById(TId id);
		Task<TType?> GetByIdAsync(TId id);
		IEnumerable<TType> GetAll();
		Task<IEnumerable<TType>> GetAllAsync();
		IQueryable<TType> GetAllAttached();
		Task<bool> FindByNameAsync(string name);
		void Add(TType item);
		Task AddAsync(TType item);
		void AddRange(TType[] items);
		Task AddRangeAsync(TType[] items);

		bool Delete(TId id, bool softDelete = false);
		Task<bool> DeleteAsync(TId id, bool softDelete = false);


		bool Update(TId id, TType item);
		Task<bool> UpdateAsync(TId id, TType item);


		int SaveChanges();
		Task<int> SaveChangesAsync();
	}
}
