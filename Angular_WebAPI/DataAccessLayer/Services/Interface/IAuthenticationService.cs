using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services.Interface
{
    public interface IAuthenticateService
    {
        bool CheckAuthentication(string userName, string password);
    }
}
