using System.Windows.Forms;

namespace Server_directory.Controller
{
    public interface IController
    {
        void CreateNew();
        void Delete();
        void Update();
        void Refresh();
        Form CreateForm();
    }
}
