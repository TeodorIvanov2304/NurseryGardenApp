using NurseryGardenApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryGardenApp.Services.Data.Interfaces
{
	public interface IClassService
	{
		Task<IEnumerable<Class>> GetAllClassesAsync();
	}
}
