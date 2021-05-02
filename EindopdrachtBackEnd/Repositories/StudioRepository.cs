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


        // GET ALL STUDIOS

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


        // GET ONE STUDIO BY ID

        public async Task<Studio> GetStudio(int studioId)
        {
            try
            {
                return await _context.Studios.Where(o => o.StudioId == studioId).SingleOrDefaultAsync();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }


        // REMOVE ONE STUDIO BY ID

        public async Task DeleteStudio(int studio)
        {
            try
            {
                var deletedObject = _context.Studios.Where(o => o.StudioId == studio).First();
                _context.Studios.Remove(deletedObject);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }


        // UPDATE ONE STUDIO BY ID

        public async Task<Studio> UpdateStudio(int studioId, string update)
        {
            try
            {
                var updateItem = _context.Studios.Where(o => o.StudioId == studioId).First();
                updateItem.Name = update;
                await _context.SaveChangesAsync();
                return updateItem;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
