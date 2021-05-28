﻿using AutoMapper;

namespace Login.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(x =>
            {
                x.AddProfile(new DomainToViewModel());
                x.AddProfile(new ViewModelToDomain());
            });
        }
    }
}
