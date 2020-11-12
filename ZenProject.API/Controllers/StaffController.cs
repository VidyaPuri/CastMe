using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ZenProject.API.Models;
using ZenProject.Data;
using ZenProject.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace ZenProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepository _teamMemberRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public StaffController(IStaffRepository teamMemberRepository,
                                    IMapper mapper, 
                                    LinkGenerator linkGenerator)
        {
            _teamMemberRepository = teamMemberRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<StaffModel[]>> Get()
        {
            try
            {
                var results = await _teamMemberRepository.GetAllAsync();

                return _mapper.Map<StaffModel[]>(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<StaffModel>> Get(int id)
        {
            try
            {
                var staffMember = await _teamMemberRepository.GetStaffMemberAsync(id);
                if (staffMember == null) return NotFound();

                return _mapper.Map<StaffModel>(staffMember);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPost]
        public async Task<ActionResult<StaffModel>> Create(StaffModel model)
        {
            try
            {
                // To -Do check if there is a Team Member with the same first and last name in the db

                // Create new team member
                var staffMember = _mapper.Map<Staff>(model);
                _teamMemberRepository.Add(staffMember);

                var location = _linkGenerator.GetPathByAction("Get", "Staff", new { StaffId = staffMember.StaffId });

                if (await _teamMemberRepository.SaveChangesAsync())
                {
                    return Created(location, _mapper.Map<StaffModel>(staffMember));
                }

                return BadRequest();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }


        [HttpPut("{Id:int}")]
        public async Task<ActionResult<StaffModel>> Put(int id, StaffModel staffMember)
        {
            try
            {
                var existingTeamMember = await _teamMemberRepository.GetStaffMemberAsync(id);
                if (existingTeamMember == null) return NotFound($"Could not find the team member by the name {staffMember.FirstName} {staffMember.LastName}");

                existingTeamMember.EditDate = DateTime.Now;
                _mapper.Map(staffMember, existingTeamMember);

                if(await _teamMemberRepository.SaveChangesAsync())
                {
                    return _mapper.Map<StaffModel>(existingTeamMember);
                }

                return BadRequest("Failed to update the team member");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult<StaffModel>> Delete(int id)
        {
            try
            {
                var existingTeamMember = await _teamMemberRepository.GetStaffMemberAsync(id);
                if (existingTeamMember == null) return NotFound($"Could not find the team member!");

                _teamMemberRepository.Delete(existingTeamMember);

                if (await _teamMemberRepository.SaveChangesAsync())
                {
                    return Ok();
                }

                return BadRequest("Failed to delete this team member");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}