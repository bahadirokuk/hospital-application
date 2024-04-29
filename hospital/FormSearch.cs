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

namespace hastane
{
    public partial class FormSearch : Form
    {
        public FormSearch()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new(@"Data Source = BAHADIR; Initial Catalog = Hastane; Integrated Security = True"))
                {
                    string query = "SELECT poliklinik,kisi_ad,kisi_soyad,tarih,yapilan_islem,doctors.dr_kod,doctors.dr_adı,doctors.dr_soyadı,miktar,birim_fiyat,taburcu_mu,dosya_no FROM process INNER JOIN client ON process.kisi_id = client.kisi_id INNER JOIN doctors ON process.dr_kod = doctors.dr_kod WHERE";

                    // Seçilen RadioButton'a göre filtreleme
                    if (radioButton1.Checked)
                    {
                        query += " taburcu_mu = 1";
                    }
                    else if (radioButton2.Checked)
                    {
                        query += " taburcu_mu = 0";
                    }else if (radioButton3.Checked)
                    {
                        query += " 1 = 1";
                    }
                    DateTime startDate = dateTimePicker1.Value.Date;
                    DateTime endDate = dateTimePicker2.Value.Date;

                    query += $" AND tarih BETWEEN '{startDate.ToString("yyyy-MM-dd")}' AND '{endDate.ToString("yyyy-MM-dd")}'";


                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            label.Text = "Toplam Tutar = " + SumMoney.sumMoney(dataGridView1).ToString();
        }
    }
}
