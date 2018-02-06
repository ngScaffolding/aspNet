using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ngScaffolding.Services
{
    public class AppSettingsService : IAppSettingsService
    {
        public string AuthEndpoint { get; set; }
        public string AuthAudience { get; set; }
        public string UserInfoEndpoint { get; set; }
    }
}
