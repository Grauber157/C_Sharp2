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

        //Botão RETORNO para Form1
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 formMenu = new Form1();
            this.Hide();
            formMenu.Show();
        }

        //Botão de Cadastro
        private void button3_Click(object sender, EventArgs e)
        {
            //Variavel que guarda os dados de conexão para conectar com o BdD
            string connectionString = "datasource=127.0.0.1; port=3306; username=root; password=; database=escola;";
            //Variavel que guarda o codigo a ser execultado no servidor ('querry')
            string querry = "INSERT INTO curso(`Codigo`, `Nome`, `CargaHoraria`, `Periodo`) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "')";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(querry, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                MessageBox.Show("Curso Cadastrado com sucesso!");
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
