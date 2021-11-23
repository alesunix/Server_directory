using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_directory
{
    class ServerContext: DbContext
    {
        public ServerContext() : base("DefaultConnection") { }
        public DbSet<Server> Servers { get; set; }
    }
}
