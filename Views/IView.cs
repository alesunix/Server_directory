using Server_directory.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_directory.Views
{
    internal interface IView
    {
        void Refresh(BindingList<Server> data);
        IController Controller { get; set; }
    }
}
