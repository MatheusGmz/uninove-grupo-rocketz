using AutoMapper;
using Login.Application.ViewModel;
using Login.Domain.Entities;

namespace Login.Application.AutoMapper
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<ClientViewModel, Client>();
        }
    }
}
