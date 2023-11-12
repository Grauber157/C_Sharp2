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

namespace Escola_Projeto
{
    public partial class Form2_1 : Form
    {

        private Form2 form2;
        private int? id_selecionado = null;

        public Form2_1(Form2 form2)
        {
            InitializeComponent();
            this.form2 = form2;

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

            //Formatação da tabela2
            listView2.View = View.Details;
            listView2.LabelEdit = true;
            listView2.AllowColumnReorder = true;
            listView2.FullRowSelect = true;
            listView2.GridLines = true;
            //Formatação das colunas e linhas2
            listView2.Columns.Add("RA", 30, HorizontalAlignment.Left);
            listView2.Columns.Add("Nome", 150, HorizontalAlignment.Left);
            listView2.Columns.Add("CPF", 100, HorizontalAlignment.Left);
            listView2.Columns.Add("Endereço", 150, HorizontalAlignment.Left);
            listView2.Columns.Add("Telefone", 100, HorizontalAlignment.Left);
            listView2.Columns.Add("Email", 100, HorizontalAlignment.Left);
            listView2.Columns.Add("Curso", 100, HorizontalAlignment.Left);

            listView2.Columns.Add("Nota1", 50, HorizontalAlignment.Left);
            listView2.Columns.Add("Nota2", 50, HorizontalAlignment.Left);
            listView2.Columns.Add("Nota3", 50, HorizontalAlignment.Left);
            listView2.Columns.Add("Nota4", 50, HorizontalAlignment.Left);
            listView2.Columns.Add("Média", 50, HorizontalAlignment.Left);
        }

        private void Form2_1_Load(object sender, EventArgs e)
        {
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



        //---AREA GROUPBOX1 ALUNO---//
        //Botão Calcular Media GP1
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

            textBox12.Text = aluno.Media(n1, n2, n3, n4).ToString();
            button3.Enabled = true;

        }
        //Botão CADASTRAR GP1
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



        //---AREA GROUPBOX2 ALUNO---//
        //Evento ListView GP2
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            System.Windows.Forms.ListView.SelectedListViewItemCollection itens_Selecionados = listView1.SelectedItems;
            foreach (ListViewItem item in itens_Selecionados)
            {
                id_selecionado = Convert.ToInt32(item.SubItems[0].Text);

                textBox28.Text = item.SubItems[0].Text;
                textBox26.Text = item.SubItems[1].Text;
                textBox25.Text = item.SubItems[2].Text;
                textBox24.Text = item.SubItems[3].Text;
                textBox23.Text = item.SubItems[4].Text;
                textBox22.Text = item.SubItems[5].Text;
                textBox21.Text = item.SubItems[6].Text;
                textBox20.Text = item.SubItems[7].Text;
                textBox19.Text = item.SubItems[8].Text;
                textBox18.Text = item.SubItems[9].Text;
                textBox17.Text = item.SubItems[10].Text;
                textBox16.Text = item.SubItems[11].Text;
            }
        }
        //Botão Calcular Media GP2
        private void button7_Click_1(object sender, EventArgs e)
        {
            //Instanciamento da Classe Aluno
            Aluno aluno = new Aluno();
            double n1, n2, n3, n4;

            //Declaração de parâmetros para entrar na função 'Media()'
            n1 = Convert.ToDouble(textBox20.Text);
            n2 = Convert.ToDouble(textBox19.Text);
            n3 = Convert.ToDouble(textBox18.Text);
            n4 = Convert.ToDouble(textBox17.Text);

            textBox16.Text = aluno.Media(n1, n2, n3, n4).ToString();
        }
        //Botão Pesquisar GP2
        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=escola;";
            //string query = "SELECT * FROM usuario";
            string query = "SELECT * FROM aluno WHERE nome LIKE '" + textBox15.Text + "%'";


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

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Botão Atualizar GP2
        private void button8_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=escola;";
            string query = "UPDATE `aluno` SET `nome` = '" + textBox26.Text + "',`cpf` = '" + textBox25.Text + "',`endereco` = '" + textBox24.Text + "',`telefone` = '" + textBox23.Text + "',`email` = '" + textBox22.Text + "',`curso` = '" + textBox21.Text + "',`notabim1` = '" + textBox20.Text + "',`notabim2` = '" + textBox19.Text + "',`notabim3` = '" + textBox18.Text + "',`notabim4` = '" + textBox17.Text + "',`media` = '" + textBox16.Text + "' WHERE ra = '" + textBox28.Text + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                MessageBox.Show("Aluno Atualizado com sucesso!");
                databaseConnection.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        //---AREA GROUPBOX3 ALUNO---//
        //Evento ListView GP3
        private void listView2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            System.Windows.Forms.ListView.SelectedListViewItemCollection itens_Selecionados = listView2.SelectedItems;
            foreach (ListViewItem item in itens_Selecionados)
            {
                id_selecionado = Convert.ToInt32(item.SubItems[0].Text);

                textBox14.Text = item.SubItems[0].Text;
            }
        }
        //Botão Pesquisar GP3
        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=escola;";
            //string query = "SELECT * FROM usuario";
            string query = "SELECT * FROM aluno WHERE nome LIKE '" + textBox13.Text + "%'";


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

                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11) };
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
        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=escola;";
            string query = "DELETE FROM `aluno` WHERE ra = '" + textBox14.Text + "' ";

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
        

    }
}
