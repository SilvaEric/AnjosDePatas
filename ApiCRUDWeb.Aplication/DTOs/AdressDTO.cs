
using System.ComponentModel.DataAnnotations;

namespace ApiCRUDWeb.Aplication.DTOs
{
	public class AdressDTO
		
	{
		[Required]
		[StringLength(30, MinimumLength = 4, ErrorMessage = "O País deve conter entre 4 a 30 caracteres")]
		public string Country { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 4, ErrorMessage = "O Estado deve conter entre 4 a 50 caracteres")]
		public string State { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 4, ErrorMessage = "A cidade deve conter entre 4 a 50 caracteres")]
		public string City { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 4, ErrorMessage = "O bairro deve conter entre 4 a 50 caracteres")]
		public string Neighborhood { get;set; }
		[Required]
		[StringLength(150, MinimumLength = 4, ErrorMessage = "O logradouro deve conter entre 4 a 150 caracteres")]
		public string PublicPlace { get; set; }
		[Required]
		[StringLength(20, MinimumLength = 4, ErrorMessage = "O Complemento deve conter entre 4 a 20 caracteres")]
		public string Complement { get; set; }
	}
}
