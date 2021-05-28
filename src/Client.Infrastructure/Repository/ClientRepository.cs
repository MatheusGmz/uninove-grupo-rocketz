using Login.Domain.Entities;
using Login.Domain.Interfaces;
using Login.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Login.Infrastructure.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientContext _clientContext;

        public ClientRepository(ClientContext clientContext)
        {
            _clientContext = clientContext;
        }
        public Client GetClientById(int id)
        {
            return _clientContext.Accounts.Where(x => x.Id == id).FirstOrDefault();
        }
        public Client GetClientByEmail(string email)
        {
            return _clientContext.Accounts.Where(x => x.Email == email).FirstOrDefault();
        }
        public Client GetClientByCpf(string cpf)
        {
            return _clientContext.Accounts.Where(x => x.Cpf == cpf).FirstOrDefault();
        }
        public void RegisterClient(Client client)
        {
            client.Deleted = false;
            _clientContext.Add(client);
            _clientContext.SaveChanges();
        }
        public void DeleteClient(Client client)
        {
            _clientContext.Update(client);
            _clientContext.SaveChanges();
        }
        public void UpdateClient(Client client)
        {
            _clientContext.Update(client);
            _clientContext.SaveChanges();
        }
        public bool ValidateUpdate(Client client)
        {
            var checkCpf = GetClientByCpf(client.Cpf);
            var checkEmail = GetClientByEmail(client.Email);
            var error_list = new List<string>();
            if (checkCpf == null)
            {
                error_list.Add("- Cpf não existe");
            }
            if (checkEmail != null && client.Cpf != checkEmail.Cpf)
            {
                error_list.Add("- O e-mail já está cadastrado em outra conta!");
            }
            if (client.Cpf.Length != 11)
            {
                error_list.Add("- O  CPF deve conter 11 dígitos\n");
            }
            if (!long.TryParse(client.Cpf, out long i))
            {
                error_list.Add("- O  CPF deve conter apenas números\n");
            }
            if (Regex.IsMatch(client.Name, "^[0-9]"))
            {
                error_list.Add("- O nome não pode conter números\n");
            }
            var isValid = error_list.Count > 0 ?  false :  true;
            return isValid;
        }
        public List<string> ValidatePayload(Client client)
        {
            var error_list = new List<string>();
            if (GetClientByCpf(client.Cpf) != null)
            {
                error_list.Add("- Cliente já cadastrado\n");
            }
            if(GetClientByEmail(client.Email)!= null)
            {
                error_list.Add("- E-mail já cadastrado\n");
            }
            if (client.Cpf.Length != 11)
            {
                error_list.Add("- O  CPF deve conter 11 dígitos\n");
            }
            if (!long.TryParse(client.Cpf, out long i))
            {
                error_list.Add("- O  CPF deve conter apenas números\n");
            }
            if (Regex.IsMatch(client.Name, "^[0-9]"))
            {
                error_list.Add("- O nome não pode conter números\n");
            }  

            return error_list;
        }
    }
}
