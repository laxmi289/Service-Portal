using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicePortal.Api.Models.Services;
using ServicePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentController (IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetDepartments ()
        {
            try
            {
                return Ok(await departmentRepository.GetDepartments());
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error fetching data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddDepartment (Department dept)
        {
            try
            {
                if (dept == null)
                    return BadRequest();

                var createdDept = await departmentRepository.AddDepartment(dept);

                return StatusCode(StatusCodes.Status200OK, "Department added successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding data");
            }
        }
    }
}
