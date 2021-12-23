using Server_directory.Models;
using Server_directory.Views;
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
            _view.CreateNew(_model.GetDataCreate());
        }

        public void Refresh()
        {
            _view.Refresh(_model.GetData());
        }
        public void Delete()
        {
            _view.Delete(_model.GetDataDelete());
        }
        public void Update()
        {
            _view.Update(_model.GetDataUpdate());
        }
    }
}
