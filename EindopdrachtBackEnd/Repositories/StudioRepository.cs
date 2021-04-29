using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindopdrachtBackEnd.Data;
using EindopdrachtBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace EindopdrachtBackEnd.Repositories
{
    public interface IStudioRepository
    {
        Task DeleteStudio(int studio);
        Task<Studio> GetStudio(int studioId);
        Task<List<Studio>> GetStudios();
        Task<Studio> UpdateStudio(int studioId, string update);
    }

    public class StudioRepository : IStudioRepository
    {
        private IAnimeContext _context;

        public StudioRepository(IAnimeContext context)
        {
            _context = context;
        }

        public async Task<List<Studio>> GetStudios()
        {
            try
            {
                return await _context.Studios.ToListAsync();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }

        public async Task<Studio> GetStudio(int studioId)
        {
            return await _context.Studios.Where(o => o.StudioId == studioId).SingleOrDefaultAsync();
        }

        public async Task DeleteStudio(int studio)
        {
            var dep = _context.Studios.Where(o => o.StudioId == studio).First();
            _context.Studios.Remove(dep);
            await _context.SaveChangesAsync();
        }

        public async Task<Studio> UpdateStudio(int studioId, string update)
        {
            var dep = _context.Studios.Where(o => o.StudioId == studioId).First();
            dep.Name = update;
            await _context.SaveChangesAsync();

            return dep;
        }
    }
}
