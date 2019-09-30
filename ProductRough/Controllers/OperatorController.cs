using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using DataAccessLayer.ExtraModels;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductRough.ContextFolder;
using ProductRough.Models;

namespace ProductRough.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OperatorController : ControllerBase
    {

        private OperatorBL _objBL = new OperatorBL();
        private IConfiguration _config;

        private readonly ProductContext _context;
        public OperatorController(ProductContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }



        //////////post for checking operator exist or not

        [HttpPost]
        [Route("login")]

        public IActionResult VerfiyLogin([FromBody] Operator user)
        {
            string tokenString = null;
            var res = _objBL.VerifyLogin(user.Email/*, user.PassWord*/);

            if (res != null)
            {
                var roletype = res.Roles;
                var Operatorid = res.OperatorId;
                tokenString = GenerateJSONWebToken(res);
                return Ok(new { token = tokenString, roles = roletype, oprid = Operatorid });
            }
            else
            {
                return BadRequest(new { message = "the username and password is incorrect" });
            }

        }
        //// //token of verifylogin()
        private string GenerateJSONWebToken(Operator user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, user.Roles)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims: claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }







        //Post:api/Operator/Registrationuser(for adding new Users)

        [HttpPost]
        [Route("Registrationuser")]
        public async Task<ActionResult<Operator>> PostOperator(Operator newoperators)
        {
            _context.Operators.Add(newoperators);
            try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetProductItems", new { id = newoperators.OperatorId }, newoperators);
            }
            catch
            {
                return BadRequest(new { message = "User already registered please select another email" });
            }




        }


        //Post:api/Operator/Registrationadmin(for adding new Admin)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("Registrationadmin")]
        public async Task<ActionResult<Operator>> PostOperatoradmin(Operator newoperators)
        {
            _context.Operators.Add(newoperators);
            try
            {
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProductItems", new { id = newoperators.OperatorId }, newoperators);
            }
            catch
            {
                return BadRequest(new { message = "Admin email is already present use another one." });
            }

        }

        // GET: api/Operator(gettig operator)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operator>>> GetOperators()
        {
            return await _context.Operators.ToListAsync();
        }

        //Get:api/Operator(for getting operator by id)
        [HttpGet("Getoperator/{id}")]


        public IActionResult GetOperators([FromRoute] int id)
        {
            var operators = (from ope in _context.Operators
                             where ope.OperatorId == id
                             select ope).FirstOrDefault();


            if (operators == null)
            {
                return NotFound();
            }

            return Ok(operators);
        }


        // DELETE: api/Operator/id(delete operator by id)
        [HttpDelete("Deleteoperator/{id}")]

        public async Task<ActionResult<Operator>> Deleteoperators(int id)
        {
            var operators = await _context.Operators.FindAsync(id);
            if (operators == null)
            {
                return NotFound();
            }
            _context.Operators.Remove(operators);
            await _context.SaveChangesAsync();

            return operators;
        }

        ///////////////////////////////////////////////////////////////////////////////////
        ///LOCATION CRUD///////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////

        [HttpPost("addlocation")]
        public IActionResult AddLocation([FromBody]Location location  /*,int lid*/)
        {
            if (location.LocationId <= 0)
            {
                //var userid = _context.Locations.FirstOrDefault(l=>l.OperatorId==location.OperatorId);
                //if (userid==null) { 
                _context.Locations.Add(location);
                return Ok(_context.SaveChangesAsync());
            }
            else
            {

                _context.Entry(location).State = EntityState.Modified;
                return Ok(_context.SaveChangesAsync());
                //   // return BadRequest(new { message = "Address should be unique please update address" });
            }
        }

        [HttpPost("updatelocation")]
        public void UpdateLocation([FromBody]Location location)
        {
            _context.Locations.Update(location);
            _context.SaveChanges();
        }

        [HttpGet("getlocation/{userId}/{locationId}")]
        public Location GetLocation(int userId, int locationId)
        {
            return _context.Locations.FirstOrDefault(l => l.OperatorId == userId && l.LocationId == locationId);
        }

        [HttpGet("getlocationbyid/{userId}")]
        public Location GetLocations(int userId)
        {
            return _context.Locations.Where(l => l.OperatorId == userId).FirstOrDefault();
        }

        [HttpDelete("deletelocationbyid/{userId}/{locationId}")]
        public void DeleteLocation(int userId, int locationId)
        {
            var location = GetLocation(userId, locationId);
            _context.Locations.Remove(location);
            _context.SaveChanges();
        }
    }
}