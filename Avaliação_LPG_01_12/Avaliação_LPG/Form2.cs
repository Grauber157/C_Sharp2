using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Avaliação_LPG
{
    public partial class Form2 : Form
    {
        private Form2 form2;
        private int? id_selecionado = null;

        public Form2()
        {
            InitializeComponent();

            //Formatação da tabela
            listView1.View = View.Details;
            listView1.LabelEdit = true;
            listView1.AllowColumnReorder = true;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            //Formatação das colunas e linhas
            listView1.Columns.Add("Nome", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("Cargo", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("CPF", 150, HorizontalAlignment.Left);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        //BOTÃO VOLTAR
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }

        //BOTÃO CADASTRAR 
        private void button2_Click(object sender, EventArgs e)
        {
            //Variavel que guarda os dados de conexão para conectar com o BdD
            string connectionString = "datasource=127.0.0.1; port=3306; username=root; password=; database=petshop;";
            //Variavel que guarda o codigo a ser execultado no servidor ('querry')
            string querry = "INSERT INTO usuario(`Nome`, `Tipo_Usuario`, `CPF`) VALUES ('" + textBox1.Text + "', '" + comboBox1.Text + "', '" + textBox2.Text + "')";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(querry, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                MessageBox.Show("Usuario Cadastrado com sucesso!");
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //BOTÃO ATUALIZAR
        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=petshop;";
            string query = "UPDATE `usuario` SET `nome` = '" + textBox1.Text + "', `tipo_usuario` = '" + comboBox1.Text + "' WHERE cpf = '" + textBox2.Text + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                MessageBox.Show("Usuário Atualizado com sucesso!");
                databaseConnection.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //BOTÃO DELETAR
        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=petshop;";
            string query = "DELETE FROM `usuario` WHERE cpf = '" + textBox2.Text + "' ";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;

            try
            {
                //Caixa de dialogo para escolher
                DialogResult res = MessageBox.Show("Tem certeza que deseja excluir o registro?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (res == DialogResult.Yes)
                {
                    databaseConnection.Open();
                    MySqlDataReader myReader = commandDatabase.ExecuteReader();
                    MessageBox.Show("Usuário Deletado com sucesso!");
                }

                databaseConnection.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //BOTÃO PROCURAR
        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=petshop;";
            string query = "SELECT * FROM usuario WHERE nome LIKE '" + textBox4.Text + "%'";


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    listView1.Items.Clear();
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2) };
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

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //EVENTO DA LISTVIEW1
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            System.Windows.Forms.ListView.SelectedListViewItemCollection itens_selecionados = listView1.SelectedItems;

            foreach (ListViewItem item in itens_selecionados)
            {
                id_selecionado = Convert.ToInt32(item.SubItems[0].Text);

                textBox1.Text = item.SubItems[0].Text;
                textBox2.Text = item.SubItems[1].Text;
                //comboBox1.Text = item.SubItems[2].Text;
                


            }
        }
    }
}
