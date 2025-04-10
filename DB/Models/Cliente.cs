using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Cliente
    {
        [Key]  // 🔹 Define la clave primaria
        public int IdCliente { get; set; }

        public TipoClienteEnum TipoCliente { get; set; } = TipoClienteEnum.Cliente;

        [Required] // Evita valores nulos
        public string Nombre { get; set; } = string.Empty;

        public TipoDocumentoEnum TipoDocumento { get; set; } = TipoDocumentoEnum.NIT;

        [Required]
        public string NumDocumento { get; set; } = string.Empty;

        public string Direccion { get; set; } = string.Empty;

        [Required]
        [Phone] // Valida formato de teléfono
        public string Telefono { get; set; } = "000000000";

        [Required]
        [EmailAddress] // Valida formato de email
        public string Email { get; set; } = "sincorreo@example.com";

        public string CodigoCliente { get; set; } = "000"; // Si es numérico, cambiar a int

        public DateTime FechaCreacion { get;  set; }

        public DateTime? FechaModificacion { get;  set; } // 🔹 Se asigna en el servidor

        public string UbicacionMaps { get; set; } = "No disponible";

        public bool Condicion { get; set; } = false; // 0 = inactivo, 1 = activo

        // Constructor para inicializar valores predeterminados
        public Cliente()
        {
            FechaCreacion = DateTime.UtcNow;
            FechaModificacion = null;
        }

        // 🔹 Método para asignar automáticamente el CódigoCliente
        public void AsignarCodigoCliente(int numero)
        {
            CodigoCliente = $"C{numero:D4}"; // Ejemplo: C0001, C0002...
        }
    }

    // Enum para TipoCliente
    public enum TipoClienteEnum
    {
        Cliente,   // 0
        Proveedor  // 1
    }

    // Enum para TipoDocumento
    public enum TipoDocumentoEnum
    {
        DPI,
        PASAPORTE,
        NIT
    }
}
