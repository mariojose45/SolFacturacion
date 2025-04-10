using DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace SolFacturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;
        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
        {
            return Ok(await _clienteService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            return Ok(await _clienteService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            return Ok(await _clienteService.Create(cliente));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Cliente cliente)
        {
            return Ok(await _clienteService.Update(cliente));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clienteService.Delete(id);
            return Ok();
        }

        // 🔸 Activar cliente
        [HttpPut("activar/{id}")]
        public async Task<IActionResult> Activar(int id)
        {
            var result = await _clienteService.Activar(id);
            if (!result)
                return NotFound(); // Si no encontró el cliente

            return Ok(new { mensaje = "Cliente activado correctamente" });
        }

        // 🔸 Desactivar cliente
        [HttpPut("desactivar/{id}")]
        public async Task<IActionResult> Desactivar(int id)
        {
            var result = await _clienteService.Desactivar(id);  // Llama al servicio

            if (!result)
                return NotFound();  // Si no se encuentra el cliente, retorna un 404

            return Ok(new { mensaje = "Cliente desactivado correctamente" });  // Si todo sale bien, retorna un mensaje de éxito
        }

    }
}
