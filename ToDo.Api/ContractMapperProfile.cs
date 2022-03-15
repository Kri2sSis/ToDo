using AutoMapper;
using ToDo.Api.Contracts;

namespace ToDo.Api
{
    public class ContractMapperProfile : Profile
    {
        public ContractMapperProfile()
        {
            CreateMap<User, Core.Repositories.User>().ReverseMap();
        }

    }
}
