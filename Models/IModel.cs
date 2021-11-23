using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_directory.Models
{
    internal interface IModel
    {
        BindingList<Server> GetData();
    }
}
