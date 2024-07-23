﻿using ApiCRUDWeb.Aplication.DTOs;

namespace ApiCRUDWeb.Aplication.Interfaces
{
	public interface IAdressService
	{
		Task<AdressDTO> AddAdress(AdressDTO adressDTO, Guid userId);
	}
}