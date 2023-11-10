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
    public partial class Form2_1 : Form
    {

        private Form2 form2;

        public Form2_1(Form2 form2)
        {
            InitializeComponent();
            this.form2 = form2;

        }

        private void Form2_1_Load(object sender, EventArgs e)
        {
            //Form2 form2 = new Form2();

            MessageBox.Show(form2.esc.ToString());

            switch (form2.esc)
            {
                case 1:
                    groupBox1.Visible = true;
                    groupBox2.Visible = false;
                    groupBox3.Visible = false;
                    break;

                case 2:
                    groupBox1.Visible = false;
                    groupBox2.Visible = true;
                    groupBox3.Visible = false;
                    break;

                case 3:
                    groupBox1.Visible = false;
                    groupBox2.Visible = false;
                    groupBox3.Visible = true;
                    break;
            }
          
        }

        //Botão de RETORNO para Form2
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 formMenu = new Form2();
            this.Hide();
            formMenu.Show();
        }

        //Botão para CALCULO MÉDIA
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

        //Botão CADASTRAR
        private void button3_Click(object sender, EventArgs e)
        {
            //Variavel que guarda os dados de conexão para conectar com o BdD
            string connectionString = "datasource=127.0.0.1; port=3306; username=root; password=; database=escola;";
            //Variavel que guarda o codigo a ser execultado no servidor ('querry')
            string querry = "INSERT INTO aluno(`RA`, `Nome`, `CPF`, `Endereco`, `Telefone`, `Email`, `Curso`, `NotaBim1`, `NotaBim2`, `NotaBim3`, `NotaBim4`, `Media`) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox11.Text + "', '" + textBox10.Text + "', '" + textBox9.Text + "', '" + textBox8.Text + "', '" + textBox12.Text + "')";

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
