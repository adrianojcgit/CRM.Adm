using CRM.Adm.Domain.Entities;
using CRM.Adm.Domain.Interfaces;
using CRM.Adm.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Adm.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Create(Cliente cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> GetById(int? id)
        {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _context.Clientes.AsNoTracking().Take(10).ToListAsync();
        }

        public async Task<Cliente> Remove(Cliente cliente)
        {
            _context.Remove(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> Update(Cliente cliente)
        {
            _context.Update(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }
    }
}
