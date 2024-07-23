using ApiCRUDWeb.Aplication.DTOs;
using ApiCRUDWeb.Aplication.Interfaces;
using ApiCRUDWeb.Domain.Entities;

namespace ApiCRUDWeb.Aplication.Mappings
{
	internal class PetDetailsMapper : IPetDetailsMapper
	{
		public PetDetails MapToPetDetails(PetDetailsDTO petDetailsDTO)
		{
			return new PetDetails
			(
				petDetailsDTO.PredominantColor,
				petDetailsDTO.NonPredominantColor,
				petDetailsDTO.Heigth,
				petDetailsDTO.Fur,
				petDetailsDTO.EyesColor,
				petDetailsDTO.TongueColor
			);
		}

		public PetDetailsDTO MapToPetDetailsDTO(PetDetails petDetails)
		{
			return new PetDetailsDTO
			{
				PredominantColor = petDetails.PredominantColor,
				NonPredominantColor = petDetails.NonPredominantColor,
				Heigth = petDetails.Heigth,
				Fur = petDetails.Fur,
				EyesColor = petDetails.EyesColor,
				TongueColor = petDetails.TongueColor
			};
		}
	}
}
