using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static NurseryGardenApp.Common.EntityValidationConstants;

namespace NurseryGardenApp.Data.Models
{
	//В този клас можем да правим разширения на Asp.Net IdentityUser
	public class ApplicationUser : IdentityUser
	{	
		//Атрибута казва на Identity кои данни са GDPR 
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
