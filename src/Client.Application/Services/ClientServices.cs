using AutoMapper;
using Login.Application.Interfaces;
using Login.Application.ViewModel;
using Login.Domain.Entities;
using Login.Domain.Interfaces;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Login.Application.Services
{
    public class ClientServices : IClientServices
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;

        public ClientServices(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public string RegisterClient(ClientViewModel client)
        {
            var entity = _mapper.Map<Client>(client);
            var validator = _clientRepository.ValidatePayload(entity);
            if (validator.Count > 0)
            {
                return "Error on account creation, try again";
            }
            _clientRepository.RegisterClient(entity);
            var creationCheck = _clientRepository.GetClientByCpf(client.Cpf);
            return creationCheck != null ? "Created!" : "Error on account creation, try again";

        }

        public ClientViewModel GetClientByCpf(string cpf)
        {
            var model = _clientRepository.GetClientByCpf(cpf);
            var entity = _mapper.Map<ClientViewModel>(model);
            if (entity == null || entity.Deleted)
            {
                return null;
            }
            return entity;
        }
        public bool DeleteClientByCpf(string login)
        {
            var entity = _clientRepository.GetClientByCpf(login);
            entity.Deleted = true;

            _clientRepository.DeleteClient(entity);
            var accountDeletationCheck = _clientRepository.GetClientById(entity.Id);
            return accountDeletationCheck != null && accountDeletationCheck.Deleted ? true : false;

        }
        public ClientViewModel UpdateClient(ClientViewModel account)
        {
            var entity = _mapper.Map<Client>(account);
            var validate = _clientRepository.ValidateUpdate(entity);
            if (validate)
            {
                entity.Age = account.Age;
                entity.Email = account.Email;
                entity.Name = account.Name;
                _clientRepository.UpdateClient(entity);
                return account;
            }
            return null;
            
            

        }
    }
}
