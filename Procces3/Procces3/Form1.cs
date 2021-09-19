using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procces3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string HAsh;
        private void button1_Click(object sender, EventArgs e)
        {
            Class1 class1 = new Class1();

            HAsh=class1.HASHIRING(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1 class1 = new Class1();
            if (HAsh == class1.first_deu())
            
                {
                    MessageBox.Show("Сообщение Верное", "", MessageBoxButtons.OK);
                }
            else
                {
                    MessageBox.Show("Сообщение неверное", "", MessageBoxButtons.OK);
                }

         }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1 class1 = new Class1();
            class1.Second_deu();
        }

       
    }
}
