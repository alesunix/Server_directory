using System.ComponentModel;
using System.Windows.Forms;

namespace Server_directory.Models
{
    internal interface IModel
    {
        BindingList<Server> GetData();
        BindingList<Server> GetDataCreate(TextBox textBox1, TextBox textBox2, TextBox textBox3);
    }
}
