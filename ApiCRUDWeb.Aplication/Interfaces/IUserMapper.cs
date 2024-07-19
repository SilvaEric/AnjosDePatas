using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCRUDWeb.Aplication.DTOs;
using ApiCRUDWeb.Domain.Entities;

namespace ApiCRUDWeb.Aplication.Interfaces
{
	public interface IUserMapper
	{
		User MapToUser(UserDTO User);
		UserDTO MapToUserDTO(User User);
	}
}
