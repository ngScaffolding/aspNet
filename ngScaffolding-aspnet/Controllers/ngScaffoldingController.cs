using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ngScaffolding.Controllers
{
    public class ngScaffoldingController: Controller
    {
        protected bool IsAuthorised(string rolesCsv)
        {
            if (!string.IsNullOrEmpty(rolesCsv))
            {
                var roles = rolesCsv.Split(',');
                foreach (var role in roles)
                {
                    if (User.IsInRole(role))
                    {
                        return true;
                    }
                }

                return false;
            }
            else
            {
                // Everyone is invited to this party
                return true;
            }
        }
    }
}
