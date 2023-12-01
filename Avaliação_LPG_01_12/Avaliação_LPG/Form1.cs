using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Avaliação_LPG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //BARRA OPCAO USUARIO
        private void vendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            this.Hide();
            form.Show();
        }

        //BARRA OPCAO PRODUTOS
        private void usúarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            this.Hide();
            form.Show();
        }

        //BARRA OPCAO SERVICO
        private void serviçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            this.Hide();
            form.Show();
        }
    }

    //CLASSE USUARIO
    class Usuario
    {
        private string Nome { get; set; }
        private string Tipo_Usuario { get; set; }
        private string Cpf { get; set; }

        public void BuscarCadastro()
        {

        }

    }

    class Administrador : Usuario
    {
        public void CadastrarVendedor()
        {

        }

        public void CadastrarVeterinario()
        {

        }

        public void CadastrarProduto()
        {

        }

        public void CadastrarServico()
        {

        }

    }

    class Vendedor : Usuario
    {

    }

    class Veterinario : Usuario
    {

    }

    //CLASSE PRODUTO
    class Produtos
    {
        private string Nome { get; set; }
        private string Preco { get; set; }
        private int Quantidade { get; set; }
        private int Id { get; set; }

    }

    //CLASSE SERVICO
    class Servico
    {
        private string Nome { get; set; }
        private string Preco { get; set; }
        private int Id { get; set; }
        
    }

    //CLASSE (ABSTRATA) PAGAMENTO
    abstract class Pagamento
    {
        private double preco;

        private string Descricao { get; set; }
        private string Data { get; set; }
        public double Preco
        {
            get
            {
                return preco;
            }

            set
            {
                preco = value;
            }
        }

        public abstract void Pagar();

    }

    class A_Vista : Pagamento
    {
        public override void Pagar()
        {
            Preco = (Preco / 100) * 5 - Preco;
        }
    }

    class A_Prazo : Pagamento
    {
        public override void Pagar()
        {
            Preco = Preco;
        }
    }
}
