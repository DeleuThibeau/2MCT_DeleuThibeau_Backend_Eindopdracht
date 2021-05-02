using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindopdrachtBackEnd.Data;
using EindopdrachtBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace EindopdrachtBackEnd.Repositories
{
    public interface IGenreRepository
    {
        Task<Genre> GetGenre(int genreId);
        Task<List<Genre>> GetGenres();
    }

    public class GenreRepository : IGenreRepository
    {
        private IAnimeContext _context;

        public GenreRepository(IAnimeContext context)
        {
            _context = context;
        }


        // GET ALL GENRES
        public async Task<List<Genre>> GetGenres()
        {
            try
            {
                return await _context.Genres.ToListAsync();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }


        // GET ONE GENRE BY ID

        public async Task<Genre> GetGenre(int genreId)
        {
            
            try
            {
                return await _context.Genres.Where(o => o.GenreId == genreId).SingleOrDefaultAsync();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
