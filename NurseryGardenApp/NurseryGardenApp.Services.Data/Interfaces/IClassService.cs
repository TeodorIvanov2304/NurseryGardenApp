using NurseryGardenApp.Data.Models;

namespace NurseryGardenApp.Services.Data.Interfaces
{
	public interface IClassService
	{
		Task<IEnumerable<Class>> GetAllClassesAsync();
	}
}
