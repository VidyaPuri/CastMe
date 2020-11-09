using ZenProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZenProject.Data
{
    public interface ITeamMemberRepository
    {
        // general
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // TeamMember
        Task<TeamMember[]> GetAllAsync();
        Task<TeamMember> GetTeamMemberAsync(int id);
    }
}
