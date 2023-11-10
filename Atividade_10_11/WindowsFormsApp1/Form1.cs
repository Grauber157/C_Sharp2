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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //Construtor da classe. É construtor pois tem o mesmo nome da classe
        public Form1()
        {
            InitializeComponent();

        }
        //Execulta quando form iniciar
        private void Form1_Load(object sender, EventArgs e)
        {
            //string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=estoque;";
            //string query = "SELECT * FROM produtos ";
            //MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            //MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            //commandDatabase.CommandTimeout = 60;
            //MySqlDataReader reader;

            
        }

        public void Venda()
        {
            Produto p = new Produto();
        }

        public void Relatorio()
        {
            Produto p = new Produto();

            textBox5.Text = p.quantidade.ToString();
            textBox6.Text = p.preco.ToString();
            textBox7.Text = p.ValorTotal.ToString();



        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

    public class Produto
    {
        public Produto()
        {

        }

        //Atributos da classe Produto
        public string item = "Marcelo";
        public int quantidade = 200;
        public double preco = 10;
        private double valorTotal;

        //Propriedades dos atributos
        public double ValorTotal
        {
            get { return valorTotal; }
            set { valorTotal = quantidade*valorTotal; }
        }

    }
}
