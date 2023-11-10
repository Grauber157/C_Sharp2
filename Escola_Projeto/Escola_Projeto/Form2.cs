using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escola_Projeto
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public int esc { get; set; }
      

        //Botão de RETORNO para Form1
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 formMenu = new Form1();
            this.Hide();
            formMenu.Show();
        }

        //Botão CADASTRAR ALUNO
        private void button2_Click(object sender, EventArgs e)
        {
            esc = 1;
            Form2_1 formMenu = new Form2_1(this);
            this.Hide();
            formMenu.Show();
        }
        //Botão ATUALIZAR ALUNO
        private void button3_Click(object sender, EventArgs e)
        {
            esc = 2;
            Form2_1 formMenu = new Form2_1(this);
            this.Hide();
            formMenu.Show();
        }
        //Botão DELETAR ALUNO
        private void button4_Click(object sender, EventArgs e)
        {
            esc = 3;
            Form2_1 formMenu = new Form2_1(this);
            this.Hide();
            formMenu.Show();
        }

    }
}
