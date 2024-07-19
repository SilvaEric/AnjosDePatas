using System.Formats.Tar;
using ApiCRUDWeb.Domain.Validations;

namespace ApiCRUDWeb.Domain.Entities
{
	public class PetDetails
	{
		public Guid Id { get; private set;  }
		public Guid PetId { get; private set; }
		public string PredominantColor { get; private set; } 
		public string NonPredominantColor { get;private set; }
		public double Heigth { get; private set; }
		public string Fur { get; private set; }
		public string EyesColor { get; private set; }
		public string TongueColor { get; private set; }
		public Pet Pet { get; private set; }

		public PetDetails(string predominantColor, string nonPredominantColor,
			double heigth, string fur, string eyesColor,
			string tongueColor)
		{
			ValidateDomain(predominantColor, nonPredominantColor, heigth, fur,
				eyesColor, tongueColor);
		}
		public void Update(string predominantColor, string nonPredominantColor,
			double heigth, string fur, string eyesColor,
			string tongueColor)
		{
			ValidateDomain(predominantColor, nonPredominantColor, heigth, fur, 
				eyesColor, tongueColor);
		}
		public void ValidateDomain(string predominantColor, string nonPredominantColor,
			double heigth, string fur, string eyesColor,
			string tongueColor)
		{
			DomainExceptionValidation.When(predominantColor.Length > 30, "A Cor predominante deve ter no maximo 30 caracteres");
			DomainExceptionValidation.When(nonPredominantColor.Length > 100, "As Cores Não predominante devem ter no maximo 100 caracteres");
			DomainExceptionValidation.When(heigth <= 0.0, "A altura deve ser superior a 0");
			DomainExceptionValidation.When(fur.Length > 20, "A pelagem deve ter no maximo 20 caracteres");
			DomainExceptionValidation.When(eyesColor.Length > 20, "A cor dos olhos deve ter no maximo 20 caracteres");
			DomainExceptionValidation.When(tongueColor.Length > 20, "A cor da lingua deve ter no maximo 20 caracteres");

			PredominantColor = predominantColor;
			NonPredominantColor = nonPredominantColor;
			Heigth = heigth;
			Fur = fur;
			EyesColor = eyesColor;
			TongueColor = tongueColor;
		}
	}
}