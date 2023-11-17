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

namespace LPG_17_11
{
    public partial class Form1 : Form
    {
        Conta c = new Conta();
        ContaPoupanca cp = new ContaPoupanca();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        //Botão Depositar
        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "Conta Corrente":
                    c.Depositar(Convert.ToDouble(textBox5.Text));
                    textBox4.Text = c.Saldo.ToString();
                    break;

                case "Conta Poupança":
                    cp.Depositar(Convert.ToDouble(textBox5.Text));
                    textBox4.Text = cp.Saldo.ToString();
                    break;
                default:
                    MessageBox.Show("Seleção Inválida! Selecione um tipo de conta");
                    break;
            }
            

        }
        //Botão Sacar
        private void button2_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "Conta Corrente":
                    c.Sacar(Convert.ToDouble(textBox5.Text));
                    textBox4.Text = c.Saldo.ToString();
                    break;

                case "Conta Poupança":
                    cp.Sacar(Convert.ToDouble(textBox5.Text));
                    textBox4.Text = cp.Saldo.ToString();
                    break;
                default:
                    MessageBox.Show("Seleção Inválida! Selecione um tipo de conta");
                    break;
            }
        }

        //Evento ComboBox para preencher os textos 
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "Conta Corrente":
                    
                    textBox4.Text = c.Saldo.ToString();
                    break;

                case "Conta Poupança":
                    textBox4.Text = cp.Saldo.ToString();
                    break;
                default:
                    MessageBox.Show("Seleção Inválida");
                    break;
            }
        }
    }

    public class Conta
    {
        public string Titular { get; set; }
        public int Agencia { get; set; }
        public int Numero { get; set; }
        public int Tipo { get; set; }

        private double saldo;
        public double Saldo
        {
            get
            {
                return this.saldo;
            }
            set
            {
                this.saldo = value;
            }

        }
        
        public virtual void Depositar(double valor)
        {
            this.Saldo += valor;
        }

        public virtual void Sacar(double valor)
        {
            this.Saldo -= valor;
        }
    }

    public class ContaCorrente : Conta
    {
        

    }

    //Herança, associamos uma sub-classe a classe-pai usando ':', sendo 'ContaPoupanca' uma sub-classe e 'Conta' a classe pai
    public class ContaPoupanca : Conta
    {
        public override void Sacar(double valor)
        {
            Saldo -= valor + 0.10;

        }

    }
}
