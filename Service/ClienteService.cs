
using DB.Models;
using Repository;

namespace Service
{
    public class ClienteService : IService<Cliente>
    {
        private readonly ClienteRepository _clienteRepository;
        public ClienteService(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }


        public async Task<List<Cliente>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }
        //crear cliente
        public async Task<Cliente> Create(Cliente entity)
        {
            return await _clienteRepository.Create(entity);
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _clienteRepository.GetById(id);
        }

        public async Task<Cliente> Update(Cliente entity)
        {
            return await _clienteRepository.Update(entity);
        }

        public async Task<Cliente> Delete(int id)
        {
            return await _clienteRepository.Delete(id);
        }
        // Activar un cliente
        public async Task<bool> Activar(int id)
        {
            return await _clienteRepository.Activar(id);
        }

        // Desactivar un cliente
        public async Task<bool> Desactivar(int id)
        {
            return await _clienteRepository.Desactivar(id);
        }


    }
}
