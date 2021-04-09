using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EindopdrachtBackEnd.DTO;
using EindopdrachtBackEnd.Models;
using EindopdrachtBackEnd.Repositories;

namespace EindopdrachtBackEnd.Services
{
    public interface IAnimeService
    {
        Task<AnimeDTO> AddAnime(AnimeDTO anime);
        Task<Anime> GetAnime(Guid animeId);
        Task<List<Anime>> GetAnimes();
        Task<DeviceDTO> GetDevice(int deviceId);
        Task<List<DeviceDTO>> GetDevices();
        Task<GenreDTO> GetGenre(int genreId);
        Task<List<GenreDTO>> GetGenres();
        Task<StreamingServiceDTO> GetStreamingService(int streamingServiceId);
        Task<List<StreamingServiceDTO>> GetStreamingServices();
        Task<StudioDTO> GetStudio(int studioId);
        Task<List<StudioDTO>> GetStudios();
    }

    public class AnimeService : IAnimeService
    {
        private IAnimeRepository _animeRepository;
        private IDeviceRepository _deviceRepository;
        private IGenreRepository _genreRepository;
        private IStudioRepository _studioRepository;
        private IStreamingServiceRepository _streamingServiceRepository;
        private IMapper _mapper;

        public AnimeService(IMapper mapper, IAnimeRepository animeRepository, IDeviceRepository deviceRepository, IGenreRepository genreRepository, IStudioRepository studioRepository, IStreamingServiceRepository streamingServiceRepository)
        {
            _mapper = mapper;
            _animeRepository = animeRepository;
            _deviceRepository = deviceRepository;
            _genreRepository = genreRepository;
            _studioRepository = studioRepository;
            _streamingServiceRepository = streamingServiceRepository;
        }

        // GET ANIME
        public async Task<Anime> GetAnime(Guid animeId)
        {
            try
            {
                return await _animeRepository.GetAnime(animeId);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Anime>> GetAnimes()
        {
            return await _animeRepository.GetAnimes();
        }

        // GET GENRES
        public async Task<GenreDTO> GetGenre(int genreId)
        {
            return _mapper.Map<GenreDTO>(await _genreRepository.GetGenre(genreId));
        }

        public async Task<List<GenreDTO>> GetGenres()
        {
            return _mapper.Map<List<GenreDTO>>(await _genreRepository.GetGenres());
        }

        // GET STUDIOS
        public async Task<StudioDTO> GetStudio(int studioId)
        {
            return _mapper.Map<StudioDTO>(await _studioRepository.GetStudio(studioId));
        }

        public async Task<List<StudioDTO>> GetStudios()
        {
            return _mapper.Map<List<StudioDTO>>(await _studioRepository.GetStudios());
        }

        // GET STREAMINGSERVICES
        public async Task<StreamingServiceDTO> GetStreamingService(int streamingServiceId)
        {
            return _mapper.Map<StreamingServiceDTO>(await _streamingServiceRepository.GetStreamingService(streamingServiceId));
        }

        public async Task<List<StreamingServiceDTO>> GetStreamingServices()
        {
            return _mapper.Map<List<StreamingServiceDTO>>(await _streamingServiceRepository.GetStreamingServices());
        }

        // GET DEVICE
        public async Task<DeviceDTO> GetDevice(int deviceId)
        {
            return _mapper.Map<DeviceDTO>(await _deviceRepository.GetDevice(deviceId));
        }

        public async Task<List<DeviceDTO>> GetDevices()
        {
            return _mapper.Map<List<DeviceDTO>>(await _deviceRepository.GetDevices());
        }

        // ADD ANIME
        public async Task<AnimeDTO> AddAnime(AnimeDTO anime)
        {
            try
            {
                Anime newAnime = _mapper.Map<Anime>(anime);
                newAnime.AnimeId = new Guid();
                newAnime.AnimeStreamingServices = new List<AnimeStreamingService>();
                foreach (var streamingServiceId in anime.AnimeStreamingServices)
                {
                    newAnime.AnimeStreamingServices.Add(new AnimeStreamingService() { StreamingServiceId = streamingServiceId });
                }
                await _animeRepository.AddAnime(newAnime);
                return anime;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

    }
}
