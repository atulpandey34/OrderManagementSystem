using DataAccessLayer;
using DataAccessLayer.DB;
using DataAccessLayer.Services;
using DataAccessLayer.Services.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;
using WebAPI.Model.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    /// <summary>
    /// Orders API
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IjwtAuth jwtAuth;
        private readonly OMSDBContext _dbContext;
        private readonly IAuthenticateService authenticateService;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="jwtAuth"></param>
        /// <param name="dbContext"></param>
        /// <param name="authenticateService"></param>
        public OrdersController(IjwtAuth jwtAuth, OMSDBContext dbContext, IAuthenticateService authenticateService)
        {
            this.jwtAuth = jwtAuth;
            this._dbContext = dbContext;
            this.authenticateService = authenticateService;
        }


    }
}
