using Server_directory.Controller;
using System.ComponentModel;

namespace Server_directory.Views
{
    internal interface IView
    {
        void Refresh(BindingList<Server> data);
        void CreateNew(BindingList<Server> data);
        void Delete(BindingList<Server> data);
        void Update(BindingList<Server> data);
        IController Controller { get; set; }
    }
}
