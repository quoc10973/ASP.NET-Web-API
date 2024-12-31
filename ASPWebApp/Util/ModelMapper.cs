using ASPWebApp.Entities;
using ASPWebApp.Model;
using AutoMapper;

namespace ASPWebApp.Util
{
    public class ModelMapper : Profile
    {
        public ModelMapper()
        {
            CreateMap<Book, BookDTO>().ReverseMap(); // Create a mapping between Book and BookDTO
            CreateMap<Account, AccountDTO>().ReverseMap(); // Create a mapping between Account and AccountDTO
        }
    }
}
