using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_directory.Models
{
    internal class ModelDirectory: IModel
    {
        ServerContext db=new ServerContext();


        public BindingList<Server> GetData()
        {
            db.Servers.Load();
            return db.Servers.Local.ToBindingList();
        }
    }
}
