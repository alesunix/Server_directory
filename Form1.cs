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

namespace Server_directory
{
    public partial class Form1 : Form
    {
        ServerContext db;
        public Form1()
        {
            InitializeComponent();
            db = new ServerContext();

            //Сетка автоматически создает GridView, который представляет базовые данные в виде двухмерной таблицы.
            GridView gridView1 = gridControl1.MainView as GridView;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            db.Servers.Load();
            gridControl1.DataSource = db.Servers.Local.ToBindingList();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)//Добавить
        {
            if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "")
            {
                Server server = new Server();
                server.Sity = textBox1.Text;
                server.Ip = textBox2.Text;
                server.Email = textBox3.Text;
                db.Servers.Add(server);
                db.SaveChanges();
                MessageBox.Show("Данные добавлены!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                db.Servers.Load();
                gridControl1.DataSource = db.Servers.Local.ToBindingList();
            }
            else MessageBox.Show("Не все поля заполнены!");
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)//Редактировать
        {           
            int rowHandle = gridView1.FocusedRowHandle;//получение индекса выделенной строки
            int number = (int)gridView1.GetRowCellValue(rowHandle, "Id");

            var item = db.Servers
        .Where(c => c.Id == number)
        .FirstOrDefault();

            // Внести изменения
            item.Sity = textBox1.Text;
            item.Ip = textBox2.Text;
            item.Email = textBox3.Text;
            // Сохранить изменения
            db.SaveChanges();
            gridControl1.DataSource = db.Servers.Local.ToBindingList();
            MessageBox.Show("Данные успешно изменены!");
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)//Удалить
        {
            int rowHandle = gridView1.FocusedRowHandle;//получение индекса выделенной строки
            int number = (int)gridView1.GetRowCellValue(rowHandle, "Id");

            var item = db.Servers
                .Where(o => o.Id == number)
                .FirstOrDefault();

            db.Servers.Remove(item);
            db.SaveChanges();
            gridControl1.DataSource = db.Servers.Local.ToBindingList();
            MessageBox.Show("Данные успешно удалены!");
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Server server = new Server();
            var grid = sender as GridView;
            if (grid.IsDataRow(e.FocusedRowHandle))
            {
                var item = grid.GetFocusedRow() as Server;
                server.Id = item.Id;
                textBox1.Text = item.Sity;
                textBox2.Text = item.Ip;
                textBox3.Text = item.Email;
            }
        }
    }
}
