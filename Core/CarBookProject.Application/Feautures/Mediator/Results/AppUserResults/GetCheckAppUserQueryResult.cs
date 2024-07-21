using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Feautures.Mediator.Results.AppUserResults
{
	public class GetCheckAppUserQueryResult
	{
		public int Id { get; set; }
		public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
		public bool IsExist { get; set; }
	}
}
