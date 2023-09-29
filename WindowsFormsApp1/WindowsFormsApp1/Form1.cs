using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Adicionar biblioteca 'MySql.Data.MySqlClient'
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //Construtor
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
            listView1.Columns.Add("ID", 30, HorizontalAlignment.Left);
            listView1.Columns.Add("Nome", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("CPF", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Email", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Telefone", 100, HorizontalAlignment.Left);

        }

        //CADASTRAR
        private void button1_Click(object sender, EventArgs e)
        {
            //Variavel que guarda os dados de conexão para conectar com o BdD
            string connectionString = "datasource=127.0.0.1; port=3306; username=root; password=; database=teste;";
            //Variavel que guarda o codigo a ser execultado no servidor ('querry')
            string querry = "INSERT INTO usuario(`id`, `nome`, `cpf`, `email`, `telefone`) VALUES (NULL, '"+textBox2.Text+"', '"+textBox3.Text+"', '"+textBox4.Text+"', '"+textBox5.Text+"')";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(querry, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                MessageBox.Show("Usuário Cadastrado com sucesso!");
                databaseConnection.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        //PESQUISAR
        private void button2_Click(object sender, EventArgs e)
        {
            //Variavel que guarda os dados de conexão para conectar com o BdD
            string connectionString = "datasource=127.0.0.1; port=3306; username=root; password=; database=teste;";
            //Variavel que guarda o codigo a ser execultado no servidor ('querry')
            string querry = "SELECT * FROM usuario;";

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
                        string[] row = {reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)};
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
    }
}
