using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCRUDWeb.Domain.Entities;

namespace ApiCRUDWeb.Domain.Interfaces
{
	public interface IAdressRepository
	{
		Task<Adress> AddAdress(Adress adress, Guid userId); 
	}
}
