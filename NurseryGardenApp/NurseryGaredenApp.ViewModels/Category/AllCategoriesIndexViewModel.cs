using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NurseryGardenApp.ViewModels.Category
{
	public class AllCategoriesIndexViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public int? ClassId { get; set; }
        public string? ClassName { get; set; }
    }
}
