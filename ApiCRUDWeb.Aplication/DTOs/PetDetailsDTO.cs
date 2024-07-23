using System.ComponentModel.DataAnnotations;

namespace ApiCRUDWeb.Aplication.DTOs
{
	public class PetDetailsDTO
	{
		[Required]
		[StringLength(30, MinimumLength = 4, ErrorMessage = "A Cor predominante deve conter entre 4 a 30 caracteres")]
		public string PredominantColor { get; set; }
		[Required]
		[StringLength(100, MinimumLength = 4, ErrorMessage = "A(s) Cor(es) não predominante(es) deve conter entre 4 a 100 caracteres")]
		public string NonPredominantColor { get; set; }
		[Required]
		[Range(0.05, 2.00, ErrorMessage = "A altura deve conter entre 0,05m a 2,00m")]
		public double Heigth { get; set; }
		[Required]
		[StringLength(20, MinimumLength = 4, ErrorMessage = "O Tipo de Pelo deve conter entre 4 a 20 caracteres")]
		public string Fur { get; set; }
		[Required]
		[StringLength(20, MinimumLength = 4, ErrorMessage = "A Cor dos olhos deve conter entre 4 a 20 caracteres")]
		public string EyesColor { get; set; }
		[Required]
		[StringLength(20, MinimumLength = 4, ErrorMessage = "A Cor da língua deve conter entre 4 a 20 caracteres")]
		public string TongueColor { get; set; }
	}
}
