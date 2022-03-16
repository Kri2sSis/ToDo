using AutoMapper;
using ToDo.Api.Contracts;

namespace ToDo.Api
{
    public class ContractMapperProfile : Profile
    {
        public ContractMapperProfile()
        {
            CreateMap<UserForCreate, Core.Repositories.User>().ReverseMap();
            CreateMap<UserForGet, Core.Repositories.User>()
                .ForMember(x => x.ToDoBoards, opt => opt.MapFrom(x => x.ToDoBoards))
                .ReverseMap();
            CreateMap<ToDoBoard, Core.Repositories.ToDoBoard>().ReverseMap();
        }

    }
}
