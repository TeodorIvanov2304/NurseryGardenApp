using Microsoft.EntityFrameworkCore;
using NurseryGardenApp.Data.Data.Repositories.Interfaces;
using NurseryGardenApp.Data.Models;
using static NurseryGardenApp.Common.ErrorMessages;

namespace NurseryGardenApp.Data.Data.Repositories
{
	public class BaseRepository<TType, TId> : IRepository<TType, TId> where TType : class where TId : struct
	{

		private readonly NurseryGardenDbContext _dbContext;
		private readonly DbSet<TType> _dbSet;

		public BaseRepository(NurseryGardenDbContext dbContext)
		{
			this._dbContext = dbContext;
			this._dbSet = dbContext.Set<TType>(); 
		}

		public void Add(TType item)
		{
			//Try/Catch?
			this._dbSet.Add(item);
			SaveChanges();
		}

		public async Task AddAsync(TType item)
		{
			//Try/Catch?
			await this._dbSet.AddAsync(item);
			await SaveChangesAsync();
		}

		public void AddRange(TType[] items)
		{
			this._dbSet.AddRange(items);
			this._dbContext.SaveChanges();
		}

		public async Task AddRangeAsync(TType[] items)
		{
			await this._dbSet.AddRangeAsync(items);
			await this._dbContext.SaveChangesAsync();
		}

		public bool Delete(TId id, bool softDelete = false)
		{
			TType? entity = this.GetById(id);

			if (entity is null)
			{
				return false;
			}

			if (softDelete)
			{
				if (entity is Product productEntity)
				{
					productEntity.IsDeleted = true;  
					_dbSet.Update(entity);  
					SaveChanges();  
					return true;
				}

			}
			else
			{
				_dbSet.Remove(entity);
			}

			SaveChanges();
			return true;
		}

		public async Task<bool> DeleteAsync(TId id, bool softDelete = false)
		{
			TType? entity = await this.GetByIdAsync(id);

			if (entity is null)
			{
				return false;
			}

			if (softDelete)
			{
				if (entity is Product productEntity)
				{
					productEntity.IsDeleted = true;
					await UpdateAsync(id, entity);
					await SaveChangesAsync();
					return true;
				}

			}
			else
			{
				_dbSet.Remove(entity);
			}

			await SaveChangesAsync();
			return true;
		}

		public async Task<bool> FindByNameAsync(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException($"{NameCannotBeEmptyException}", nameof(name));
			}

			return await _dbSet
						.Where(e => EF.Property<string>(e, "Name") == name)
						.AnyAsync();
		}

		public IEnumerable<TType> GetAll()
		{
			return this._dbSet.ToList();
		}

		public async Task<IEnumerable<TType>> GetAllAsync()
		{
			return await this._dbSet.ToListAsync();
		}

		public IQueryable<TType> GetAllAttached()
		{
			return this._dbSet.AsQueryable();
		}

		public TType? GetById(TId id)
		{
			TType? entity = _dbSet.Find(id);
			return entity;
		}

		public async Task<TType?> GetByIdAsync(TId id)
		{
			TType? entity = await _dbSet.FindAsync(id);
			return entity;
		}

		public int SaveChanges()
		{
			return this._dbContext.SaveChanges();
		}

		public async Task<int> SaveChangesAsync()
		{
			return await this._dbContext.SaveChangesAsync();
		}

		public bool Update(TId id, TType item)
		{
			try
			{
				this._dbSet.Attach(item);
				_dbContext.Entry(item).State = EntityState.Modified;
				this._dbContext.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<bool> UpdateAsync(TId id, TType item)
		{
			try
			{
				this._dbSet.Attach(item);
				_dbContext.Entry(item).State = EntityState.Modified;
				await this._dbContext.SaveChangesAsync();
				return true;
			}
			catch
			{

				return false;
			}
		}
	}
}
