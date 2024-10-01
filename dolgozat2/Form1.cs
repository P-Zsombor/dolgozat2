using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dolgozat2
{
    public partial class Form1 : Form
    {
        dbHandler db;
        public Form1()
        {
            InitializeComponent();
            Start();
        }
        void Start()
        {
            read();
            db = new dbHandler();
            button1.Click += (s, e) =>
            {
                db.addOne(textBox1.Text, Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value));
                read();
            };
            button2.Click += (s, e) =>
            {
                List<pekaru> list = db.readAll();
                if (listBox1.SelectedIndex >= 0)
                {
                    db.deletOne(list[listBox1.SelectedIndex].id);
                    Text = list[listBox1.SelectedIndex].id.ToString();
                    read();
                }
            };
            listBox1.SelectedIndexChanged += (s, e) =>
            {
                List<pekaru> list = db.readAll();
                textBox1.Text = list[listBox1.SelectedIndex].nev;
                numericUpDown1.Value = list[listBox1.SelectedIndex].db;
                numericUpDown2.Value = list[listBox1.SelectedIndex].ar;
            };
        }
        void read()
        {
            db = new dbHandler();
            List<pekaru> list = db.readAll();
            listBox1.Items.Clear();
            foreach (pekaru item in list)
            {
                listBox1.Items.Add(item.nev);
            }
        }
    }
}
