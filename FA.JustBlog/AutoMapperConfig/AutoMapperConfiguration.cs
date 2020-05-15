using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Models;

namespace FA.JustBlog.AutoMapperConfig
{
    public class AutoMapperConfiguration
    {
        public static IMapper Mapper { get; private set; }

        public static MapperConfiguration MapperConfiguration { get; private set; }

        public static void Init()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                // Mapping domain entities to view entities
                cfg.CreateMap<Post, PostViewModel>();
                cfg.CreateMap<Category, CategoryViewModel>();

                // Mapping view entities to domain entities
                cfg.CreateMap<PostViewModel, Post>();
                cfg.CreateMap<CategoryViewModel, Category>();
            });

            Mapper = MapperConfiguration.CreateMapper();
        }
    }
}