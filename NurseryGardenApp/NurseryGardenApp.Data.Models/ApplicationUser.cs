using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static NurseryGardenApp.Common.EntityValidationConstants;

namespace NurseryGardenApp.Data.Models
{
	public class ApplicationUser : IdentityUser
	{	

		[PersonalData]
		[MaxLength(ApplicationUserFirstNameMaxLength)]
		[Comment("The first name of the user")]
        public string? FirstName { get; set; }

		[PersonalData]
		[MaxLength(ApplicationUserLastNameMaxLength)]
		[Comment("The last name of the user")]
		public string? LastName { get; set; }

    }
}
