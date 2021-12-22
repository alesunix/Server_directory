using Server_directory.Controller;
using System.ComponentModel;

namespace Server_directory.Views
{
    internal interface IView
    {
        void Refresh(BindingList<Server> data);
        void CreateNew(BindingList<Server> data);
        IController Controller { get; set; }
    }
}
