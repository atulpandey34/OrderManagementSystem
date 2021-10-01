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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IjwtAuth jwtAuth;
        private readonly OMSDBContext _dbContext;
        private readonly IAuthenticateService authenticateService;

        private readonly List<Member> lstMember = new List<Member>()
        {
            new Member{Id=1, Name="Kirtesh" },
            new Member {Id=2, Name="Nitya" },
            new Member{Id=3, Name="pankaj"}
        };

        public MembersController(IjwtAuth jwtAuth, OMSDBContext dbContext, IAuthenticateService authenticateService)
        {
            this.jwtAuth = jwtAuth;
            this._dbContext = dbContext;
            this.authenticateService = authenticateService;
        }
        //// GET: api/<MembersController>
        //[HttpGet]
        //public IEnumerable<EmployeeViewModel> AllMembers()
        //{
        //    var _emplst = _dbContext.tblEmployees.
        //                    Join(_dbContext.tblSkills, e => e.SkillID, s => s.SkillID,
        //                    (e, s) => new EmployeeViewModel
        //                    {
        //                        EmployeeID = e.EmployeeID,
        //                        EmployeeName = e.EmployeeName,
        //                        PhoneNumber = e.PhoneNumber,
        //                        Skill = s.Title,
        //                        YearsExperience = e.YearsExperience
        //                    }).ToList();
        //    IList<EmployeeViewModel> emplst = _emplst;
        //    return emplst;
        //}


        /// <summary>
        /// GET api/Members/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Member MemberByid(int id)
        {
            return lstMember.Find(x => x.Id == id);
        }

        [AllowAnonymous]
        // POST api/<MembersController>
        [HttpPost("authentication")]
        public IActionResult Authentication([FromBody] UserCredential userCredential)
        {
            Result res = new Result();

            if (string.IsNullOrEmpty(userCredential.UserName) || string.IsNullOrEmpty(userCredential.Password))
            {
                res.header.success = false;
                res.header.message = "Username or Password is empty";
            }
            else
            {
                bool userexist = authenticateService.CheckAuthentication(userCredential.UserName, userCredential.Password);

                if (userexist)
                {
                    var token = jwtAuth.GetToken(userCredential.UserName);
                    res.header.success = true;
                    res.header.message = "Authentication Success";
                    res.data = new { token = token };

                }
                else
                {
                    res.header.success = false;
                    res.header.message = "Authentication Failure";
                }

            }

            return Ok(res);
        }


    }
}
