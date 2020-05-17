using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.ViewModels;
using System.Collections.Generic;

namespace FA.JustBlog.ExternalConfig
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
                cfg.CreateMap<Tag, TagViewModel>();
                cfg.CreateMap<Comment, CommentViewModel>();
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<List<Category>, List<CategoryViewModel>>();

                // Mapping view entities to domain entities
                cfg.CreateMap<PostViewModel, Post>();
                cfg.CreateMap<TagViewModel, Tag>();
                cfg.CreateMap<CommentViewModel, Comment>();
                cfg.CreateMap<CategoryViewModel, Category>();
                cfg.CreateMap<List<CategoryViewModel>, List<Category>>();
            });

            Mapper = MapperConfiguration.CreateMapper();
        }
    }
}