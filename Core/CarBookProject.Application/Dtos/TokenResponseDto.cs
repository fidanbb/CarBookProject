using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Dtos
{
	public class TokenResponseDto
	{
        public TokenResponseDto(string token,DateTime expiredDate)
        {
            Token = token;
            ExpireDate = expiredDate;
        }

        public string Token { get; set; }
        public  DateTime ExpireDate { get; set; }
    }
}
