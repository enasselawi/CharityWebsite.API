using CharityWebsite.Core.Data;
using CharityWebsite.Core.Repository;
using CharityWebsite.Core.Service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;



namespace CharityWebsite.Infra.Service
{
    public class LoginService : ILoginService
    {

        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        
        }

        public string Auth(Userr userr)
        {
            var result = _loginRepository.Auth(userr);//username + roleid if matching or null if no match

            if (result == null)

            {

                return null;

            }

            else

            {

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey@ApiCharity123456"));// at least 256 bit 32byte 

                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>

             {

             new Claim(ClaimTypes.Email, result.Email),

             new Claim(ClaimTypes.Role, result.Roleid.ToString())

             };

                var tokeOptions = new JwtSecurityToken(

                                claims: claims,

                                expires: DateTime.Now.AddHours(24),

                                signingCredentials: signinCredentials

                        );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                return tokenString;

            }

        }
    }





    }
