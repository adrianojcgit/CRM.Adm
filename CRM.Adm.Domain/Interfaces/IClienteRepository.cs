using CRM.Adm.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Adm.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClientes();
        Task<Cliente> GetById(int? id);
        Task<Cliente> Create(Cliente cliente);
        Task<Cliente> Update(Cliente cliente);
        Task<Cliente> Remove(Cliente cliente);
    }
}
