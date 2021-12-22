using System.ComponentModel;
using System.Data.Entity;
using System.Windows.Forms;

namespace Server_directory.Models
{
    internal class ModelDirectory: IModel
    {
        ServerContext db = new ServerContext();
        public BindingList<Server> GetData()
        {
            db.Servers.Load();
            return db.Servers.Local.ToBindingList();
        }
        public BindingList<Server> GetDataCreate(TextBox textBox1, TextBox textBox2, TextBox textBox3)
        {
            Server server = new Server();
            server.Sity = textBox1.Text;
            server.Ip = textBox2.Text;
            server.Email = textBox3.Text;
            db.Servers.Add(server);
            db.SaveChanges();            
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            db.Servers.Load();
            return db.Servers.Local.ToBindingList();
        }
    }
}
