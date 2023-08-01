using AutoMapper;
using GGstore.ProductAPI.Data.ValueObjects;
using GGstore.ProductAPI.Model;

namespace GGstore.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<Genero, GeneroVO>();
                config.CreateMap<Plataforma, PlataformaVO>();
                config.CreateMap<Game, GameVO>()
                    .ForMember(dest => dest.Generos, opt => opt.MapFrom(src => src.GameGeneros.Select(gg => gg.Genero).ToList()))
                    .ForMember(dest => dest.Plataformas, opt => opt.MapFrom(src => src.GamePlataformas.Select(gp => gp.Plataforma).ToList()));
                config.CreateMap<GeneroVO, Genero>();
                config.CreateMap<PlataformaVO, Plataforma>();
                config.CreateMap<GameVO, Game>()
                    .ForMember(dest => dest.GameGeneros, opt => opt.Ignore())
                    .ForMember(dest => dest.GamePlataformas, opt => opt.Ignore());
            });
            return mappingConfig;
        }
    }
}
