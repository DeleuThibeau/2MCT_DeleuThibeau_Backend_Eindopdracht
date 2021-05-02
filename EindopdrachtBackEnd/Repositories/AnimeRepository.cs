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
        Task DeleteAnime(string name);
        Task<Anime> GetAnimeById(Guid animeId);
        Task<Anime> GetAnimeByName(string animeName);
        Task<List<Anime>> GetAnimes();
        Task<List<Anime>> UpdateAnime(string name, string update);
    }

    public class AnimeRepository : IAnimeRepository
    {
        private IAnimeContext _context;

        public AnimeRepository(IAnimeContext context)
        {
            _context = context;
        }


        // GET ALL ANIMES

        public async Task<List<Anime>> GetAnimes()
        {
            try
            {
                return await _context.Animes.ToListAsync();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

            
        }


        // GET ONE ANIME BY ID

        public async Task<Anime> GetAnimeById(Guid animeId)
        {
            try
            {
                return await _context.Animes.Where(s => s.AnimeId == animeId)
                    .Include(s => s.Genre)
                    .Include(s => s.Studio)
                    .Include(s => s.AnimeStreamingServices)
                    .ThenInclude(s => s.StreamingService).SingleOrDefaultAsync();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            
        }



        // GET ONE ANIME BY NAME

        public async Task<Anime> GetAnimeByName(string animeName)
        {
            try
            {
                return await _context.Animes.Where(s => s.Name == animeName)
                    .Include(s => s.Genre)
                    .Include(s => s.Studio)
                    .Include(s => s.AnimeStreamingServices)
                    .ThenInclude(s => s.StreamingService).SingleOrDefaultAsync();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }



        // ADD ONE ANIME (POST)

        public async Task<Anime> AddAnime(Anime anime)
        {
            try
            {
                await _context.Animes.AddAsync(anime);
                await _context.SaveChangesAsync();
                return anime;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }



        // DELETE ONE ANIME BY NAME

        public async Task DeleteAnime(string name)
        {

            try
            {
                var dep = _context.Animes.Where(o => o.Name == name).ToList();

                foreach (Anime anime in dep)
                {
                    _context.Animes.Remove(anime);
                }

                await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            
        }



        //UPDATE ONE ANIME BY NAME

        public async Task<List<Anime>> UpdateAnime(string name, string update)
        {

            try
            {
                var animes = _context.Animes.Where(o => o.Name == name).ToList();

                foreach (Anime anime in animes)
                {
                    anime.Name = update;
                }

                await _context.SaveChangesAsync();

            return animes;
            }
            catch (System.Exception ex)
            {

                throw ex;
            } 
        }
    }
}
