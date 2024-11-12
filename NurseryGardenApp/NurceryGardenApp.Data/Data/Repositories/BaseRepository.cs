using Microsoft.EntityFrameworkCore;
using NurseryGardenApp.Data.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryGardenApp.Data.Data.Repositories
{
	public class BaseRepository<TType, TId> : IRepository<TType, TId> where TType : class where TId : struct
	{

		private readonly NurseryGardenDbContext _dbContext;
		private readonly DbSet<TType> _dbSet;

        public BaseRepository(NurseryGardenDbContext dbContext, DbSet<TType> dbSet)
        {
			this._dbContext = dbContext;
			this._dbSet = dbSet;
        }

        public void Add(TType item)
		{
			throw new NotImplementedException();
		}

		public Task AddAsync(TType item)
		{
			throw new NotImplementedException();
		}

		public bool Delete(TId id, bool softDelete = false)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteAsync(TId id, bool softDelete = false)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TType> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<TType>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public TType GetById(TId id)
		{
			throw new NotImplementedException();
		}

		public Task<TType> GetByIdAsync(TId id)
		{
			throw new NotImplementedException();
		}

		public int SaveChanges()
		{
			throw new NotImplementedException();
		}

		public Task<int> SaveChangesAsync()
		{
			throw new NotImplementedException();
		}

		public bool Update(TType item)
		{
			throw new NotImplementedException();
		}

		public Task<bool> UpdateAsync(TType item)
		{
			throw new NotImplementedException();
		}
	}
}
