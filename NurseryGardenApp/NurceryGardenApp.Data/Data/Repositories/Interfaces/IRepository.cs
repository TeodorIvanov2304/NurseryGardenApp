namespace NurseryGardenApp.Data.Data.Repositories.Interfaces
{
	public interface IRepository<TType,TId> where TType : class where TId : struct
	{
		TType GetById(TId id);
		Task<TType> GetByIdAsync(TId id);
		IEnumerable<TType> GetAll();
		Task<IEnumerable<TType>> GetAllAsync();


		void Add(TType item);
		Task AddAsync(TType item);


		//If we want soft delete, we have to pass (id,true)
		bool Delete(TId id, bool softDelete = false);
		Task<bool> DeleteAsync(TId id, bool softDelete = false);


		bool Update(TType item);
		Task<bool> UpdateAsync(TType item);


		int SaveChanges();
		Task<int> SaveChangesAsync();
	}
}
