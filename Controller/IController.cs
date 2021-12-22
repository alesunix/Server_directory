using System.Windows.Forms;

namespace Server_directory.Controller
{
    public interface IController
    {
        void CreateNew(TextBox textBox1, TextBox textBox2, TextBox textBox3);
        void Delete();
        void Update();
        void Refresh();
        Form CreateForm();
    }
}
