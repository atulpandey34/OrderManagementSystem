using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    /// <summary>
    /// Interface
    /// </summary>
    public interface IjwtAuth
    {
        /// <summary>
        /// Authentication
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        string GetToken(string username);
    }
}
