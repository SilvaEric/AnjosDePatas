using ApiCRUDWeb.Aplication.DTOs;
using ApiCRUDWeb.Aplication.Interfaces;
using ApiCRUDWeb.Domain.Interfaces;

namespace ApiCRUDWeb.Aplication.Services
{
	internal class AdressService : IAdressService
	{
		private readonly IAdressMapper _mapper;
		private readonly IAdressRepository _repository;

		public AdressService(IAdressMapper mapper, IAdressRepository repository)
		{
			_mapper = mapper;
			_repository = repository;
		}

		public async Task<AdressDTO> AddAdress(AdressDTO adressDTO, Guid userId)
		{
			var adress = _mapper.MapToAdress(adressDTO);

			var adressAdded = await _repository.AddAdress(adress, userId);

			return _mapper.MapToAdressDTO(adressAdded);
		}
		public async Task<AdressDTO> UpdateAdress(AdressDTO adressDTO, Guid userId)
		{
			var adress = _mapper.MapToAdress(adressDTO);

			var adressUpdated = await _repository.UpdateAdress(adress, userId);

			return _mapper.MapToAdressDTO(adressUpdated);
		}
	}
}
