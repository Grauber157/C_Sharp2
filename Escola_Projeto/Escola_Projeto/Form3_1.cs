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
    public partial class Form3_1 : Form
    {
        private Form3 form3;
        private int? id_selecionado = null;

        public Form3_1(Form3 form3)
        {
            InitializeComponent();
            this.form3 = form3;

            //Formatação da tabela 2
            listView1.View = View.Details;
            listView1.LabelEdit = true;
            listView1.AllowColumnReorder = true;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            //Formatação das colunas e linhas 2
            listView1.Columns.Add("Codigo", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Nome", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("Carga Horária", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Periodo", 150, HorizontalAlignment.Left);

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

        //Esconde os forms de acordo com a escolha feita no form3
        private void Form3_1_Load(object sender, EventArgs e)
        {
            switch (form3.esc)
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

        //Botão RETORNO para Form3
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form3 formMenu = new Form3();
            this.Hide();
            formMenu.Show();
        }



        //---AREA GROUPBOX1 CURSO---//
        //Botão de Cadastro GP1
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



        //---AREA GROUPBOX2 CURSO---//
        //Evento ListView GP2
        private void listView1_ItemSelectionChanged_1(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            System.Windows.Forms.ListView.SelectedListViewItemCollection itens_Selecionados = listView1.SelectedItems;
            foreach (ListViewItem item in itens_Selecionados)
            {
                id_selecionado = Convert.ToInt32(item.SubItems[0].Text);

                textBox9.Text = item.SubItems[0].Text;
                textBox10.Text = item.SubItems[1].Text;
                textBox8.Text = item.SubItems[2].Text;
                textBox7.Text = item.SubItems[3].Text;

            }
        }
        //Botão Pesquisa GP2
        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=escola;";
            //string query = "SELECT * FROM usuario";
            string query = "SELECT * FROM curso WHERE nome LIKE '" + textBox11.Text + "%'";


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

                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
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
        
        //Botão Atualizar GP2
        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=escola;";
            string query = "UPDATE `curso` SET `nome` = '" + textBox10.Text + "',`cargaHoraria` = '" + textBox8.Text + "',`periodo` = '" + textBox7.Text + "' WHERE codigo = '" + textBox9.Text + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                MessageBox.Show("Curso Atualizado com sucesso!");
                databaseConnection.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        //---AREA GROUPBOX3 CURSO---//
        //Evento ListView2 GP3
        private void listView2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            System.Windows.Forms.ListView.SelectedListViewItemCollection itens_Selecionados = listView2.SelectedItems;
            foreach (ListViewItem item in itens_Selecionados)
            {
                id_selecionado = Convert.ToInt32(item.SubItems[0].Text);

                textBox5.Text = item.SubItems[0].Text;
            }
        }
        //Botão Pesquisa GP3
        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=escola;";
            //string query = "SELECT * FROM usuario";
            string query = "SELECT * FROM curso WHERE nome LIKE '" + textBox6.Text + "%'";


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
                    listView2.Items.Clear();
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

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Botão Deletar GP3
        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=escola;";
            string query = "DELETE FROM `curso` WHERE codigo = '" + textBox5.Text + "' ";

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
                    MessageBox.Show("Curso Deletado com sucesso!");
                }

                databaseConnection.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
