using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hastane.hospital.dbFonk;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace hastane
{
    public partial class FormPage : Form
    {
        public FormPage()
        {
            InitializeComponent();
        }

        private void eklebutton_Click(object sender, EventArgs e)
        {
            AddProcess.addProduct(comboBoxPolik.Text,((int)numericUpDown1.Value),comboBoxIslem.Text,((int)numericUpDowndr.Value),((int)numericUpDownAdet.Value),((double)numericUpDownBirimf.Value),checkBox1.Checked);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text !="")
            {
                int a = int.Parse(textBox4.Text.Trim());
                dataGridView1.DataSource = SearchFile.fileno(a);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = AllProcess.islem();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormAddClient a = new FormAddClient();
            a.Show();
        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece sayıları ve kontrol tuşlarını (Backspace, Delete) kabul et
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SearchFile.name(comboBox1.Text,textBoxname.Text,textBoxsurname.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormSearch formSearch = new FormSearch();
            formSearch.Show();
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            ToplamtutarLabel.Text = SumMoney.sumMoney(dataGridView1).ToString();
        }
    }
}
