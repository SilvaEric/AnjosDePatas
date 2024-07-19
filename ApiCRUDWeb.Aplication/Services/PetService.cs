using ApiCRUDWeb.Aplication.DTOs;
using ApiCRUDWeb.Aplication.Interfaces;
using ApiCRUDWeb.Domain.Entities;
using ApiCRUDWeb.Domain.Interfaces;

namespace ApiCRUDWeb.Aplication.Services
{
	public class PetService : IPetService
	{
		private readonly IPetMapper _mapper;
		private readonly IPetRepository _repository;

		public PetService(IPetMapper mapper, IPetRepository repository)
		{
			_mapper = mapper;
			_repository = repository;
		}
		public async Task<PetDTO> AddPet(PetDTO petDTO, Guid tutorId)
		{
			var pet =  _mapper.MapToPet(petDTO);
			var petAdded = await _repository.AddPet(pet, tutorId);
			return _mapper.MapToPetDTO(petAdded);
		}

		public async Task<List<PetDTO>> GetAllPets(Guid tutorId)
		{
			var pets = await _repository.GetAllPets(tutorId);
			var petsDTO = new List<PetDTO>();
			foreach(Pet pet in pets)
			{
				petsDTO.Add(_mapper.MapToPetDTO(pet));
			}
			return petsDTO;
		}

		public async Task<PetDTO> GetPet(Guid petId)
		{
			var pet = await _repository.GetPet(petId);
			return _mapper.MapToPetDTO(pet);
		}

		public async Task<PetDTO> UpdatePet(PetDTO input)
		{
			var pet = _mapper.MapToPet(input);
			var petUpdated = await _repository.UpdatePet(pet);
			return _mapper.MapToPetDTO(petUpdated);
		}
	}
}
