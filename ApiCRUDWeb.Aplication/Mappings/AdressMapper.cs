using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCRUDWeb.Aplication.DTOs;
using ApiCRUDWeb.Aplication.Interfaces;
using ApiCRUDWeb.Domain.Entities;

namespace ApiCRUDWeb.Aplication.Mappings
{
	internal class AdressMapper : IAdressMapper
	{
		public Adress MapToAdress(AdressDTO adressDTO)
		{
			return new Adress
				(
					adressDTO.Country,
					adressDTO.State,
					adressDTO.City,
					adressDTO.Neighborhood,
					adressDTO.PublicPlace,
					adressDTO.Complement
				);
		}

		public AdressDTO MapToAdressDTO(Adress adress)
		{
			return new AdressDTO
			{
				Country = adress.Country,
				State = adress.State,
				City = adress.City,
				Neighborhood = adress.Neighborhood,
				PublicPlace = adress.PublicPlace,
				Complement = adress.Complement
			}; 
		}
	}
}
