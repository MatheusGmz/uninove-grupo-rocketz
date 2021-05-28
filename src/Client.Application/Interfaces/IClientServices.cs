using Login.Application.ViewModel;

namespace Login.Application.Interfaces
{
    public interface IClientServices
    {
        ClientViewModel GetClientByCpf(string cpf);
        string RegisterClient(ClientViewModel clientViewModel);
        bool DeleteClientByCpf(string cpf);
        ClientViewModel UpdateClient(ClientViewModel clientViewModel);
        
    }
}
