using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ClienteRepository : IRepository<Cliente>
    {
        private readonly SolFacturacionContext _context;
        public ClienteRepository(SolFacturacionContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetAll()
        {
            //throw new NotImplementedException();
            return await _context.Clientes.ToListAsync();
        }
        /// Agregar un nuevo cliente
        public async Task<Cliente> Create(Cliente entity)
        {
            // Obtener el último cliente registrado
            var ultimoCliente = await _context.Clientes
                .OrderByDescending(c => c.IdCliente) // Ordena de mayor a menor
                .FirstOrDefaultAsync();

            int nuevoNumero = 1; // Si no hay clientes, empezar en 1

            if (ultimoCliente != null)
            {
                // Extraer el número del último CódigoCliente (Ej: "C0005" -> 5)
                string ultimoCodigo = ultimoCliente.CodigoCliente.Substring(1); // Quita la 'C'
                if (int.TryParse(ultimoCodigo, out int numero))
                {
                    nuevoNumero = numero + 1; // Sumar 1 al número
                }
            }

            // Asignar el nuevo código al cliente (Ej: C0006)
            entity.AsignarCodigoCliente(nuevoNumero);

            entity.FechaCreacion = DateTime.UtcNow;
            entity.FechaModificacion = null;

            await _context.Clientes.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }


        public async Task<Cliente> GetById(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Cliente> Update(Cliente entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Cliente> Delete(int id)
        {
            Cliente cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
            return null;
        }

        public async Task<bool> Activar(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;

            cliente.Condicion = true;
            cliente.FechaModificacion = DateTime.UtcNow;



            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Desactivar(int id)
        {
           
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;

            cliente.Condicion = false;
            cliente.FechaModificacion = DateTime.UtcNow;  // Actualizamos la fecha de modificación

            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();

            return true;
        }



    }
}
