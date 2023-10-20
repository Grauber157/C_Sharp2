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

namespace Escola_Projeto
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Instanciamento da Classe Aluno
            Aluno aluno = new Aluno();
            double n1, n2, n3, n4;

            //Declaração de parâmetros para entrar na função 'Media()'
            n1 = Convert.ToDouble(textBox11.Text);
            n2 = Convert.ToDouble(textBox10.Text);
            n3 = Convert.ToDouble(textBox9.Text);
            n4 = Convert.ToDouble(textBox8.Text);

            textBox12.Text = Convert.ToString(aluno.Media(n1, n2, n3, n4));
            button3.Visible = true;

        }
        //Botão de RETORNO para Form1
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 formMenu = new Form1();
            this.Hide();
            formMenu.Show();
        }

        //Botão Cadastrar
        private void button3_Click(object sender, EventArgs e)
        {
            //Variavel que guarda os dados de conexão para conectar com o BdD
            string connectionString = "datasource=127.0.0.1; port=3306; username=root; password=; database=escola;";
            //Variavel que guarda o codigo a ser execultado no servidor ('querry')
            string querry = "INSERT INTO aluno(`RA`, `Nome`, `CPF`, `Endereco`, `Telefone`, `Email`, `Curso`, `NotaBim1`, `NotaBim2`, `NotaBim3`, `NotaBim4`, `Media`) VALUES ('"+ textBox1.Text +"', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox11.Text + "', '" + textBox10.Text + "', '" + textBox9.Text + "', '" + textBox8.Text + "', '" + textBox12.Text + "')";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(querry, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                MessageBox.Show("Aluno Cadastrado com sucesso!");
                databaseConnection.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
