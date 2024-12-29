using AutoMapper;
using BlogAppDomain.Entities;

namespace BlogAppApplication.Common.Models;

public class LookupDto
{
    public int Id { get; init; }

    public string? Title { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Post, LookupDto>();
            CreateMap<Category, LookupDto>();
        }
    }
}
