using System.ComponentModel.DataAnnotations;

namespace ApiCRUDWeb.Aplication.DTOs
{
	public class PetDTO
	{
		
		public Guid? PetId { get; set; }
		[Required]
		[StringLength(200, MinimumLength = 3, ErrorMessage = "O nome dever conter entre 3 a 200 caracteres")]
		public string PetName { get;  set; }
		[Required]
		public DateOnly DateOfBirh { get; set; }
		[Required]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "O nome dever conter entre 3 a 100 caracteres")]
		public string Breed { get; set; }

		public PetDetailsDTO? Details { get; set; }

	}
}
