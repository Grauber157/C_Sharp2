using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Escola_Projeto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            //Formatação da tabela
            listView1.View = View.Details;
            listView1.LabelEdit = true;
            listView1.AllowColumnReorder = true;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            //Formatação das colunas e linhas
            listView1.Columns.Add("RA", 30, HorizontalAlignment.Left);
            listView1.Columns.Add("Nome", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("CPF", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Endereço", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Telefone", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Email", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Curso", 100, HorizontalAlignment.Left);

            listView1.Columns.Add("Nota1", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Nota2", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Nota3", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Nota4", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Média", 50, HorizontalAlignment.Left);

            //Formatação da tabela 2
            listView2.View = View.Details;
            listView2.LabelEdit = true;
            listView2.AllowColumnReorder = true;
            listView2.FullRowSelect = true;
            listView2.GridLines = true;

            //Formatação das colunas e linhas 2
            listView2.Columns.Add("Codigo", 100, HorizontalAlignment.Left);
            listView2.Columns.Add("Nome", 200, HorizontalAlignment.Left);
            listView2.Columns.Add("Carga Horária", 100, HorizontalAlignment.Left);
            listView2.Columns.Add("Periodo", 150, HorizontalAlignment.Left);
        }
        //INSTANCIAMENTO DE CLASSES
        Aluno aluno = new Aluno();
        Curso curso = new Curso();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Botão para escolher mostrar ALUNO
        private void button1_Click(object sender, EventArgs e)
        {
            //Mudança na visibilidade do conteúdo quando Botão escolhido for apertado
            listView1.Visible = true;
            listView2.Visible = false;
            label3.Visible = true;
            label4.Visible = false;

            textBox1.Visible = true;
            textBox2.Visible = false;
            button3.Visible = true;
            button4.Visible = false;
            button7.Visible = true;
            button8.Visible = false;

        }

        //Botão para escolher mostrar CURSO
        private void button2_Click(object sender, EventArgs e)
        {
            //Mudança na visibilidade do conteúdo quando Botão escolhido for apertado
            listView1.Visible = false;
            listView2.Visible = true;
            label3.Visible = false;
            label4.Visible = true;

            textBox1.Visible = false;
            textBox2.Visible = true;
            button3.Visible = false;
            button4.Visible = true;
            button7.Visible = false;
            button8.Visible = true;

        }

        //Botão Pesquisar Aluno
        private void button7_Click(object sender, EventArgs e)
        {
            //Variavel que guarda os dados de conexão para conectar com o BdD
            string connectionString = "datasource=127.0.0.1; port=3306; username=root; password=; database=escola;";
            //Variavel que guarda o codigo a ser executado no servidor ('querry')
            string querry = "SELECT * FROM aluno WHERE nome LIKE '" + textBox1.Text + "%'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(querry, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            //ESTRUTURA DE CONDIÇÃO//
            //CONDIÇÃO DE CONCLUSÃO
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    listView1.Items.Clear();

                    //While para adquirir cada linha de registro na tabela do BD
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11) };
                        var listViewItem = new ListViewItem(row);
                        listView1.Items.Add(listViewItem);
                    }
                }

                else
                {
                    MessageBox.Show("Não existem registros no banco");
                }

                databaseConnection.Close();
            }

            //CONDIÇÃO DE EXCEÇÃO
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Botão Pesquisar Curso
        private void button8_Click(object sender, EventArgs e)
        {
            //Variavel que guarda os dados de conexão para conectar com o BdD
            string connectionString = "datasource=127.0.0.1; port=3306; username=root; password=; database=escola;";
            //Variavel que guarda o codigo a ser execultado no servidor ('querry')
            string querry = "SELECT * FROM curso WHERE nome LIKE '" + textBox2.Text + "%'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(querry, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            //ESTRUTURA DE CONDIÇÃO//
            //CONDIÇÃO DE CONCLUSÃO
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    listView2.Items.Clear();

                    //While para adquirir cada linha de registro na tabela do BD
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        var listViewItem = new ListViewItem(row);
                        listView2.Items.Add(listViewItem);

                    }

                }

                else
                {
                    MessageBox.Show("Não existem registros no banco");
                }


                databaseConnection.Close();

            }

            //CONDIÇÃO DE EXCEÇÃO
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        //Botão Gerenciar Alunos
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }

        //Botão Gerenciar Cursos
        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
        }

    }

    public class Aluno
    {
        public string ra, nome, cpf, endereco, telefone, email, curso;
        public double notaBim1, notaBim2, notaBim3, notaBim4, media;

        //Metodo para calculo da media
        public double Media(double n1, double n2, double n3, double n4)
        {
            media = (n1+n2+n3+n4)/4;
            return media;
        }

    }

    public class Curso
    {
        public string codigo, nome, cargaHoraria, periodo;

    }
}
