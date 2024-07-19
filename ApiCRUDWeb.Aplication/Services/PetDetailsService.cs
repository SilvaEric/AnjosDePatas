using ApiCRUDWeb.Aplication.DTOs;
using ApiCRUDWeb.Aplication.Interfaces;
using ApiCRUDWeb.Domain.Entities;
using ApiCRUDWeb.Domain.Interfaces;

namespace ApiCRUDWeb.Aplication.Services
{
	public class PetDetailsService : IPetDetailsService
	{
		private readonly IPetDetailsMapper _mapper;
		private readonly IPetDetailsRepository _repository;

		public PetDetailsService(IPetDetailsMapper mapper, IPetDetailsRepository repository)
		{
			_mapper = mapper;
			_repository = repository;
		}

		public async Task<PetDetailsDTO> AddPetDetails(PetDetailsDTO petDetailsDTO, Guid petId)
		{
			var petDetails = _mapper.MapToPetDetails(petDetailsDTO);

			var petDetailsAdded = await _repository.AddPetDetails(petDetails, petId);

			return _mapper.MapToPetDetailsDTO(petDetailsAdded);
		}

		public async Task<PetDetailsDTO> UpdatePetDetails(PetDetailsDTO petDetailsDTO)
		{
			var petDetails = _mapper.MapToPetDetails(petDetailsDTO);

			var petDetailsUpdated = await _repository.UpdatePetDetails(petDetails);

			return _mapper.MapToPetDetailsDTO(petDetailsUpdated);
		}
	}
}
