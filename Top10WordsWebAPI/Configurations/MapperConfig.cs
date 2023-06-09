using AutoMapper;
using Top10Words.BL.Models;
using Top10Words.DAL.Entities;
using Top10WordsWebAPI.ViewModels;

namespace Top10WordsWebAPI.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<FileViewModel,
                BookDTO>();
           CreateMap<Book,
                DisplayBookDTO>();
        }
    }
}
