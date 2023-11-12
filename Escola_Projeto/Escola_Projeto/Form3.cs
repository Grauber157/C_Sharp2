using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Escola_Projeto
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public int esc { get; set; }


        //Botão RETORNO para Form1
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 formMenu = new Form1();
            this.Hide();
            formMenu.Show();
        }

        //Botão CADASTRAR CURSO
        private void button2_Click_1(object sender, EventArgs e)
        {
            esc = 1;
            Form3_1 formMenu = new Form3_1(this);
            this.Hide();
            formMenu.Show();
        }
        //Botão ATUALIZAR CURSO
        private void button3_Click(object sender, EventArgs e)
        {
            esc = 2;
            Form3_1 formMenu = new Form3_1(this);
            this.Hide();
            formMenu.Show();
        }
        //Botão DELETAR CURSO
        private void button4_Click(object sender, EventArgs e)
        {
            esc = 3;
            Form3_1 formMenu = new Form3_1(this);
            this.Hide();
            formMenu.Show();
        }
    }
}
