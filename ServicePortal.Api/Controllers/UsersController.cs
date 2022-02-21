using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ServicePortal.Api.Models.Services;
using ServicePortal.Models;

namespace ServicePortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                return Ok(await userRepository.GetUsers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserData>> GetUser(int id)
        {
            try
            {
                var result = await userRepository.GetUser(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserData>> CreateUser(UserData user)
        {
            try
            {
                if (user == null)
                    return BadRequest();

                var createdUser = await userRepository.AddUser(user);

                return CreatedAtAction(nameof(GetUser),
                    new { id = createdUser.UserId }, createdUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserData>> UpdateUser(int id, UserData user)
        {
            try
            {
                if (id != user.UserId)
                    return BadRequest("Employee ID mismatch");

                var userToUpdate = await userRepository.GetUser(id);

                if (userToUpdate == null)
                    return NotFound($"Employee with Id = {id} not found");

                return await userRepository.UpdateUser(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<UserData>> DeleteUser(int id)
        {
            try
            {
                var userToDelete = await userRepository.GetUser(id);

                if (userToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                return await userRepository.DeleteUser(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
