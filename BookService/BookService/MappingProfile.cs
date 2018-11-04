using AutoMapper;
using BookApi.Views;
using Logic;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Book, BookView>().ReverseMap();
            //CreateMap<Book, BookView>()
            //    .ForMember(dest => dest.Authors,
            //               opts => opts.MapFrom(src => GetAuthors(src.BookId)));
        }
    }
}
