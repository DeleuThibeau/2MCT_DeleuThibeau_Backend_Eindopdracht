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
        Task<Studio> GetStudio(int studioId);
        Task<List<Studio>> GetStudios();
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
    }
}
