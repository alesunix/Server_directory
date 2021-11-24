using Server_directory.Models;
using Server_directory.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_directory.Controller
{
    internal class Controller : IController
    {
        IView _view;
        IModel _model;
        public Controller()
        {
            _view = new Form1() { Controller = this };
            _model = new ModelDirectory();
        }

        public static IController Instance()
        {
            return new Controller();
        }
        public Form CreateForm()
        {
            this.Refresh();
            return (Form)_view;
        }

        public void CreateNew()
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            _view.Refresh(_model.GetData());
        }
        public void Delete()
        {
            throw new NotImplementedException();
        }
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
