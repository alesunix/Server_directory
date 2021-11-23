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
        }

        public Form CreateForm()
        {
            return new Form1() { Controller = this };
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

        public static IController Instance()
        {
            IController controller = new Controller();
            return controller;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
