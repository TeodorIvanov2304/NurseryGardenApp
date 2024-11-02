using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NurseryGardenApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryGardenApp.Data.Data.Configuration
{
	public class ClassConfiguration : IEntityTypeConfiguration<Class>
	{
		public void Configure(EntityTypeBuilder<Class> builder)
		{
			throw new NotImplementedException();
		}
	}
}
