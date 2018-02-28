using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebSockets.Internal;
using ngScaffolding.Services;

namespace ngScaffolding.Services
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }

        public bool IsInRoles(string roles)
        {
            if (string.IsNullOrWhiteSpace(roles))
            {
                return true;
            }
            else
            {
                var allowedRoles = roles.Split(',');
                foreach (var allowedRole in allowedRoles)
                {
                    if (Roles.Contains(allowedRole.Trim(), StringComparer.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAppSettingsService _appSettingsService;

        public UserService(IHttpContextAccessor httpContextAccessor, IAppSettingsService appSettingsService)
        {
            _httpContextAccessor = httpContextAccessor;
            _appSettingsService = appSettingsService;
        }

        public async Task<UserModel> GetUser()
        {
            UserModel retVal = null;
            if (_httpContextAccessor.HttpContext.Request.Headers.Keys.Contains("Authorization"))
            {
                var bearer = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
                var token = bearer.Replace("Bearer ", "", StringComparison.CurrentCultureIgnoreCase);
                if (!string.IsNullOrEmpty(token))
                {
                    var userInfoClient = new UserInfoClient(_appSettingsService.UserInfoEndpoint);

                    var response = await userInfoClient.GetAsync(token);

                    var claims = response.Claims;

                    retVal = new UserModel();

                    if(claims.Any(c => c.Type == "sub")) retVal.Id = claims.First(c => c.Type == "sub").Value;
                    if(claims.Any(c => c.Type == "email")) retVal.Email = claims.First(c => c.Type == "email").Value;
                    if (claims.Any(c => c.Type == "name")) retVal.Name = claims.First(c => c.Type == "name").Value;
                    if (claims.Any(c => c.Type == "role")) retVal.Roles = claims.Where(claim => claim.Type == "role").Select(claim => claim.Value).ToList();
                }
            }

            return retVal;
        }
    }
}
