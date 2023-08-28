using AspNetCore.Services.Models;

namespace AspNetCore.Services.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClients();
        Task CreateClient(Client client);
        Task UpdateClients(Client client);
        Task DeleteClient(int id);
    }
}
