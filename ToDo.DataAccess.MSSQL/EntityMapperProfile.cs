using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DataAccess.MSSQL.Entities;

namespace ToDo.DataAccess.MSSQL
{
    public class EntityMapperProfile : Profile
    {
        public EntityMapperProfile()
        {
            CreateMap<User, Core.Repositories.User>()
                .ForMember(x => x.ToDoBoards, opt => opt.MapFrom(x => x.ToDoBoard))
                .ReverseMap();
            CreateMap<ToDoBoard, Core.Repositories.ToDoBoard>()
                .ReverseMap();
        }
    }
}
