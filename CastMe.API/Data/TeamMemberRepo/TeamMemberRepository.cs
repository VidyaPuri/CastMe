using CastMe.Data;
using CastMe.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastMe.API.Data
{
    public class TeamMemberRepository : ITeamMemberRepository
    {
        private readonly AppDbContext _appDbContext;

        public TeamMemberRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _appDbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _appDbContext.Remove(entity);
        }

        public async Task<TeamMember[]> GetAllAsync()
        {
            IQueryable<TeamMember> teamMembers = _appDbContext.TeamMembers;
            return await teamMembers.ToArrayAsync();
        }

        public async Task<TeamMember> GetTeamMemberAsync(int id)
        {
            IQueryable<TeamMember> teamMember = _appDbContext.TeamMembers
                                                    .Where(tm => tm.TeamMemberId == id);

            return await teamMember.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _appDbContext.SaveChangesAsync()) > 0;
        }
    }
}
