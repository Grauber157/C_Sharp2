namespace LPG_17_11_exercicio
{
    public partial class Form1 : Form
    {
        //Estânciamento da classe pai e das sub-classes
        Empregado e = new Empregado();
        Assalariado ea = new Assalariado();
        Comissionado ec = new Comissionado();
        Horista eh = new Horista();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //Botão Calcular GP1
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = ea.Vencimento(Convert.ToDouble(textBox1.Text)).ToString();
        }
        //Evento ComboBox
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "Assalariado":
                    groupBox1.Visible = true;
                    groupBox2.Visible = false;
                    groupBox3.Visible = false;
                    break;

                case "Comissionado":
                    groupBox1.Visible = false;
                    groupBox2.Visible = true;
                    groupBox3.Visible = false;
                    break;

                case "Horista":
                    groupBox1.Visible = false;
                    groupBox2.Visible = false;
                    groupBox3.Visible = true;
                    break;
            }
        }
        //Botão Calcular Comissionado 2
        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Text = ec.Vencimento(Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text)).ToString();
        }
        //Botão Calcular
        private void button3_Click(object sender, EventArgs e)
        {

        }
    }

    //Classe Pai Empregado
    public class Empregado
    {
        private string Nome { get; set; }
        private string Sobrenome { get; set; }
        private string Cpf { get; set; }

        public double Vencimento()
        {
            return 0;
        }

    }

    //Sub-Classe Assalariado
    public class Assalariado : Empregado
    {
        private double Salario { get; set; }

        public double Vencimento(double valor)
        {
            return valor;
        }
    }

    //Sub-Classe Comissionado
    public class Comissionado : Empregado
    {
        private double TotalVenda { get; set; }
        private double TaxaComissao { get; set; }

        public double Vencimento(double totalVenda, double taxaComissao)
        {
            return (totalVenda/100)*taxaComissao;
        }
    }

    //Sub-Classe Horista
    public class Horista : Empregado
    {
        private double PrecoHora { get; set; }
        private double HorasTrabalhadas { get; set; }

        public double Vencimento(double precoHora, double horasTrabalhadas)
        {
            return precoHora*horasTrabalhadas;
        }
    }

}