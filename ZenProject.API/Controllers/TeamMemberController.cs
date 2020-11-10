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
    public class TeamMemberController : ControllerBase
    {
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public TeamMemberController(ITeamMemberRepository teamMemberRepository,
                                    IMapper mapper, 
                                    LinkGenerator linkGenerator)
        {
            _teamMemberRepository = teamMemberRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<TeamMemberModel[]>> Get()
        {
            try
            {
                var results = await _teamMemberRepository.GetAllAsync();

                return _mapper.Map<TeamMemberModel[]>(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<TeamMemberModel>> Get(int id)
        {
            try
            {
                var teamMember = await _teamMemberRepository.GetTeamMemberAsync(id);
                if (teamMember == null) return NotFound();

                return _mapper.Map<TeamMemberModel>(teamMember);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TeamMemberModel>> Create(TeamMemberModel model)
        {
            try
            {
                // To -Do check if there is a Team Member with the same first and last name in the db

                // Create new team member
                var teamMember = _mapper.Map<TeamMember>(model);
                _teamMemberRepository.Add(teamMember);

                var location = _linkGenerator.GetPathByAction("Get", "TeamMember", new { TeamMemberId = teamMember.TeamMemberId });

                if (await _teamMemberRepository.SaveChangesAsync())
                {
                    return Created(location, _mapper.Map<TeamMemberModel>(teamMember));
                }

                return BadRequest();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }


        [HttpPut("{Id:int}")]
        public async Task<ActionResult<TeamMemberModel>> Put(int id, TeamMemberModel teamMember)
        {
            try
            {
                var existingTeamMember = await _teamMemberRepository.GetTeamMemberAsync(id);
                if (existingTeamMember == null) return NotFound($"Could not find the team member by the name {teamMember.FirstName} {teamMember.LastName}");

                existingTeamMember.EditDate = DateTime.Now;
                _mapper.Map(teamMember, existingTeamMember);

                if(await _teamMemberRepository.SaveChangesAsync())
                {
                    return _mapper.Map<TeamMemberModel>(existingTeamMember);
                }

                return BadRequest("Failed to update the team member");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult<TeamMemberModel>> Delete(int id)
        {
            try
            {
                var existingTeamMember = await _teamMemberRepository.GetTeamMemberAsync(id);
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