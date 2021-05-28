using Login.Domain.Entities;
using System.Collections.Generic;

namespace Login.Domain.Interfaces
{
    public interface IClientRepository
    {
        Client GetClientById(int id);
        Client GetClientByEmail(string email);
        Client GetClientByCpf(string cpf);
        void RegisterClient(Client client);
        void DeleteClient(Client client);
        List<string> ValidatePayload(Client client);
        void UpdateClient(Client client);
        bool ValidateUpdate(Client client);
    }
}
