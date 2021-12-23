using System.ComponentModel;

namespace Server_directory.Models
{
    internal interface IModel
    {
        BindingList<Server> GetData();
        BindingList<Server> GetDataCreate();
        BindingList<Server> GetDataDelete();
        BindingList<Server> GetDataUpdate();
    }
}
