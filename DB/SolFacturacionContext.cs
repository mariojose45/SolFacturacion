using DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class SolFacturacionContext: DbContext
    {
        public SolFacturacionContext(DbContextOptions<SolFacturacionContext> options) : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }

    }

}
