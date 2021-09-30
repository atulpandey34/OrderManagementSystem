using DataAccessLayer.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class AuthenticationService : IAuthenticateService
    {
        private readonly EmployeeContext _dbContext;
        public AuthenticationService(EmployeeContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public bool CheckAuthentication(string userName, string password)
        {
            bool _userexist = _dbContext.Users.Any(x => x.Email == userName && x.Password == password);
            return _userexist;
        }
    }
}
