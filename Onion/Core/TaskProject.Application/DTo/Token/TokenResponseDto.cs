using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject.Application.DTo.Token
{
    public class TokenResponseDto
    {
        public TokenResponseDto(string token, DateTime expiredDate)
        {
            Token = token;
            ExpiredDate = expiredDate;
        }

        public string Token { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}
