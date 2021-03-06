using AutoMapper;
using Login.Application.ViewModel;
using Login.Domain.Entities;

namespace Login.Application.AutoMapper
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<Client, ClientViewModel>();
        }
    }
}
