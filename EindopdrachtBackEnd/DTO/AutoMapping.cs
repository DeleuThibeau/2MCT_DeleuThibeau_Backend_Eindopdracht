using System;
using AutoMapper;
using EindopdrachtBackEnd.Models;

namespace EindopdrachtBackEnd.DTO
{
    public class AutoMapping : Profile
    {
        public AutoMapping(){
            
            CreateMap<Genre,GenreDTO>();
            CreateMap<StreamingService, StreamingServiceDTO>();
            CreateMap<Studio, StudioDTO>();
            CreateMap<Anime, AnimeDTO>();
            CreateMap<Anime, AllAnimeDTO>();
            CreateMap<AnimeDTO, Anime>().ForMember(x => x.AnimeStreamingServices,opt => opt.Ignore());

        }
    }
}
