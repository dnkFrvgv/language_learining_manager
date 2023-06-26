using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Application.Core
{
    public class MappingProfile : Profile
    {
      public MappingProfile()
      { 
        CreateMap<Domain.Entities.Language, Domain.Entities.Language>();
      }
    }
}