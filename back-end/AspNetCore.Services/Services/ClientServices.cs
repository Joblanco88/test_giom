using AspNetCore.Services.Context;
using AspNetCore.Services.Interfaces;
using AspNetCore.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Services.Services
{
    public class ClientServices : IClientRepository
    {
        private readonly AppDbContext _context;
        public ClientServices(AppDbContext context) => _context = context;
        public async Task<IEnumerable<Client>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }
        public async Task CreateClient(Client client)
        {
            //Validação simples para evitar duplicados dependendo da regra de negócio
            //var clientExists = await _context.Clients.FindAsync(client.Name);
            //if (clientExists != null)
            //    throw new InvalidOperationException("Esse cliente já existe no cadastro!");
            var addedClient = await _context.Clients.AddAsync(client);

            await _context.SaveChangesAsync();
        }
        public async Task UpdateClients(Client client)
        {
            var clientToUpdate = _context.Clients.Find(client.Id);

            if (clientToUpdate == null) 
                throw new InvalidOperationException("Não existe o cliente solicitado para atualização!");

            clientToUpdate.Email = client.Email;
            clientToUpdate.Phone = client.Phone;
            clientToUpdate.Name = client.Name;
            clientToUpdate.Address = client.Address;

            await _context.SaveChangesAsync();
        }
        public async Task DeleteClient(int id)
        {
            var clientToDelete = await _context.Clients.SingleAsync(cl => cl.Id == id);

            //if (clientToDelete == null) 
            //    throw new InvalidOperationException("Cliente não encontrado!");

            _context.Clients.Remove(clientToDelete);

            await _context.SaveChangesAsync();
        }
    }
}
