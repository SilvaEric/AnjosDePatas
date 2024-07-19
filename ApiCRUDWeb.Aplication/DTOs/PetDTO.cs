using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCRUDWeb.Aplication.DTOs
{
	public class PetDTO
	{
		[Required]
		public Guid UserId { get; set; }
		[Required]
		[StringLength(200, MinimumLength = 3, ErrorMessage = "O nome dever conter entre 3 a 200 caracteres")]
		public string PetName { get;  set; }
		[Required]
		public DateOnly DateOfBirh { get; set; }
		[Required]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "O nome dever conter entre 3 a 100 caracteres")]
		public string Breed { get; set; }

	}
}
