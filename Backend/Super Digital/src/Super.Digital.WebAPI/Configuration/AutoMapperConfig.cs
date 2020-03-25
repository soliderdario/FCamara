using AutoMapper;
using Super.Digital.Domain.Model;
using Super.Digital.WebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super.Digital.WebAPI.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AccountModel, AccountViewModel>().ReverseMap();

            CreateMap<CreateAccountModel, CreateAccountViewModel>().ReverseMap();


        }
    }
}
