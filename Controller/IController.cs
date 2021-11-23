using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
