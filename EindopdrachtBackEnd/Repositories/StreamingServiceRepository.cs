using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindopdrachtBackEnd.Data;
using EindopdrachtBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace EindopdrachtBackEnd.Repositories
{
    public interface IStreamingServiceRepository
    {
        Task<StreamingService> GetStreamingService(int streamingServiceId);
        Task<List<StreamingService>> GetStreamingServices();
    }

    public class StreamingServiceRepository : IStreamingServiceRepository
    {
        private IAnimeContext _context;

        public StreamingServiceRepository(IAnimeContext context)
        {
            _context = context;
        }

        public async Task<List<StreamingService>> GetStreamingServices()
        {
            try
            {
                return await _context.StreamingServices.ToListAsync();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }

        public async Task<StreamingService> GetStreamingService(int streamingServiceId)
        {
            return await _context.StreamingServices.Where(o => o.StreamingServiceId == streamingServiceId).SingleOrDefaultAsync();
        }
    }
}
