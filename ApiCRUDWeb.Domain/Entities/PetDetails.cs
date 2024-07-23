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
		public Pet Pet { get; set; }

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
			PredominantColor = predominantColor;
			NonPredominantColor = nonPredominantColor;
			Heigth = heigth;
			Fur = fur;
			EyesColor = eyesColor;
			TongueColor = tongueColor;
		}
	}
}