using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Server_directory.Views;
using Server_directory.Controller;
using DevExpress.XtraEditors;
using Server_directory.Models;

namespace Server_directory
{
    public partial class Form1 : XtraForm, IView
    {
        public static Server server;
        public IController Controller { get; set; }       
        public Form1()
        {
            InitializeComponent();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Black");
            server = new Server();

            //Сетка автоматически создает GridView, который представляет базовые данные в виде двухмерной таблицы.
            GridView gridView1 = gridControl1.MainView as GridView;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Controller.Refresh();
        }
        public void GetIndex()//перехват Id выбраной строки
        {
            int rowHandle = gridView1.FocusedRowHandle;//получение индекса выделенной строки
            server.Id = (int)gridView1.GetRowCellValue(rowHandle, "Id");
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)//Добавить
        {
            if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "")
            {
                ModelDirectory.TbSity = textBox1.Text;
                ModelDirectory.TbIp = textBox2.Text;
                ModelDirectory.TbEmail = textBox3.Text;
                Controller.CreateNew();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                MessageBox.Show("Данные добавлены!");
            }
            else MessageBox.Show("Не все поля заполнены!");
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)//Редактировать
        {
            if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "")
            {
                GetIndex();
                ModelDirectory.TbSity = textBox1.Text;
                ModelDirectory.TbIp = textBox2.Text;
                ModelDirectory.TbEmail = textBox3.Text;
                Controller.Update();
                MessageBox.Show("Данные успешно изменены!");
            }
            else MessageBox.Show("Не все поля заполнены!");
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)//Удалить
        {
            GetIndex();
            Controller.Delete();
            MessageBox.Show("Данные успешно удалены!");
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var grid = sender as GridView;
            if (grid.IsDataRow(e.FocusedRowHandle))
            {
                Server item = grid.GetFocusedRow() as Server;
                server.Id = item.Id;
                textBox1.Text = item.Sity;
                textBox2.Text = item.Ip;
                textBox3.Text = item.Email;
            }
        }
        public void Refresh(BindingList<Server> data)
        {
            gridControl1.DataSource = data;
        }
        public void CreateNew(BindingList<Server> data)
        {
            gridControl1.DataSource = data;
        }
        public void Delete(BindingList<Server> data)
        {
            gridControl1.DataSource = data;
        }
        public void Update(BindingList<Server> data)
        {
            gridControl1.DataSource = data;
        }

    }
}
