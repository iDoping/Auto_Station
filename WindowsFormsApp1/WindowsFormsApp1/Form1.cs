using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            FbConnection fbConn = new FbConnection();
            cs.DataSource = "localhost";    // имя компьютера, на котором находится база данных 
            cs.UserID = "SYSDBA";           // имя пользователя, который может производить манипуляции с базой 
            cs.Password = "masterkey";      // паоль пользователя, который может производить манипуляции с базой 
            cs.Database = "E:\\WindowsFormsApp1\\WindowsFormsApp1\\bd\\DRIVED.fdb";  // путь к файлу базы данных            // cs.Port = 3050;                 // порт подключения к базе 
            cs.Charset = "win1251";         // кодировка символов 
            string ConnString = cs.ToString();
            fbConn.ConnectionString = ConnString;
            fbConn.Open();
            DataTable dt = new DataTable();
            FbDataAdapter da = new FbDataAdapter();
            FbCommand cmd = new FbCommand("select * from new_table", fbConn);
            cmd.CommandType = CommandType.Text;
            FbDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            fbConn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            FbConnection fbConn = new FbConnection();
            cs.DataSource = "localhost";    // имя компьютера, на котором находится база данных 
            cs.UserID = "SYSDBA";           // имя пользователя, который может производить манипуляции с базой 
            cs.Password = "masterkey";      // паоль пользователя, который может производить манипуляции с базой 
            cs.Database = "E:\\WindowsFormsApp1\\WindowsFormsApp1\\bd\\DRIVED.fdb";  // путь к файлу базы данных            // cs.Port = 3050;                 // порт подключения к базе 
            cs.Charset = "win1251";         // кодировка символов 
            string ConnString = cs.ToString();
            fbConn.ConnectionString = ConnString;
            fbConn.Open();
            DataTable dt = new DataTable();
            FbDataAdapter da = new FbDataAdapter();
            FbCommand cmd = new FbCommand("select Name,Surname,LastName,pasport_num,pasport_serial_num,place_num,price from new_table where Flight_id ='"+textBox1.Text+"';", fbConn);
            cmd.CommandType = CommandType.Text;
            FbDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView2.DataSource = dt;
            fbConn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Return back to the Flight!");
        }
    }
}
