using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindopdrachtBackEnd.Data;
using EindopdrachtBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace EindopdrachtBackEnd.Repositories
{
    public interface IAnimeRepository
    {
        Task<Anime> AddAnime(Anime anime);
        Task<Anime> GetAnime(Guid animeId);
        Task<List<Anime>> GetAnimes();
    }

    public class AnimeRepository : IAnimeRepository
    {
        private IAnimeContext _context;

        public AnimeRepository(IAnimeContext context)
        {
            _context = context;
        }

        public async Task<List<Anime>> GetAnimes()
        {
            return await _context.Animes.Include(s => s.AnimeStreamingServices).Include(s => s.Studio).Include(s => s.Genre).ToListAsync();
        }

        public async Task<Anime> AddAnime(Anime anime)
        {
            await _context.Animes.AddAsync(anime);
            await _context.SaveChangesAsync();
            return anime;
        }

        public async Task<Anime> GetAnime(Guid animeId)
        {
            return await _context.Animes.Where(s => s.AnimeId == animeId)
            .Include(s => s.Genre)
            .Include(s => s.Studio)
            .Include(s => s.AnimeStreamingServices)
            .ThenInclude(s => s.StreamingService).SingleOrDefaultAsync();
        }

    }
}
