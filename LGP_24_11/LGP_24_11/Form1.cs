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

namespace LGP_24_11
{
    public partial class Form1 : Form
    {
        Poupanca poupanca = new Poupanca();

        public Form1()
        {
            InitializeComponent();
            textBox2.Text = 0.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Botão Depositar
        private void button1_Click(object sender, EventArgs e)
        {
            poupanca.Saldo = Convert.ToDouble(textBox2.Text);
            poupanca.Depositar(Convert.ToDouble(textBox3.Text));
            textBox2.Text = poupanca.Saldo.ToString();

        }
        //Botão Extrato
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Cliente: " + textBox1.Text);
            listBox1.Items.Add("Saldo: " + textBox2.Text);

        }
    }

    abstract class Conta
    {
        public string cliente = "";
        private double saldo = 0;

        public string Cliente { get; set; }
        public double Saldo {
            get {return this.saldo;}
            set {this.saldo = value;}
        }

        abstract public void Depositar(double valor);
       
    }

    class Poupanca : Conta
    {
        public double taxa = 10;
        public double valor;

        public override void Depositar(double valor)
        {
            this.Saldo += valor + (valor * (this.taxa/100));
        }
    }



}
