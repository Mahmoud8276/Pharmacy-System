using Pharmacy.System.Core.Dtos.AppUserDtos;
using System;
using System.Text.Json.Serialization;

namespace Pharmacy.System.Core.Dtos.AccountDtos
{
    public class LoginDetailsDto
    {
        public UserDetailsDto User { get; set; }
        public string AccessToken { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
