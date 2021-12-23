using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace Server_directory.Models
{
    internal class ModelDirectory: IModel
    {
        ServerContext db = new ServerContext();
        public static string TbSity { get; set; }
        public static string TbIp { get; set; }
        public static string TbEmail { get; set; }
        public BindingList<Server> GetData()
        {
            db.Servers.Load();
            return db.Servers.Local.ToBindingList();
        }
        public BindingList<Server> GetDataCreate()
        {
            Server server = new Server();
            server.Sity = TbSity;
            server.Ip = TbIp;
            server.Email = TbEmail;
            db.Servers.Add(server);
            db.SaveChanges();                       
            db.Servers.Load();
            return db.Servers.Local.ToBindingList();
        }

        public BindingList<Server> GetDataDelete()
        {
            Server item = db.Servers.Where(c => c.Id == Form1.server.Id).FirstOrDefault();
            db.Servers.Remove(item);
            db.SaveChanges();
            db.Servers.Load();
            return db.Servers.Local.ToBindingList();
        }

        public BindingList<Server> GetDataUpdate()
        {
            Server item = db.Servers.Where(c => c.Id == Form1.server.Id).FirstOrDefault();
            // Внести изменения
            item.Sity = TbSity;
            item.Ip = TbIp;
            item.Email = TbEmail;
            // Сохранить изменения
            db.SaveChanges();
            db.Servers.Load();
            return db.Servers.Local.ToBindingList();
        }
    }
}
