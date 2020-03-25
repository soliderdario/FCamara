using AutoMapper;
using Super.Digital.Domain.Model;
using Super.Digital.WebAPI.ViewModel;

namespace Super.Digital.WebAPI.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AccountModel, AccountViewModel>().ReverseMap();
            CreateMap<EntryModel, EntryViewModel> ().ReverseMap();
            CreateMap<AccountEntryModel, AccountEntryViewModel>()
                .ForMember(dest => dest.Number, act => act.MapFrom(src => src.Account.Number));
        }
    }
}
