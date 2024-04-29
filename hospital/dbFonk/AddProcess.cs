using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hastane
{
    class AddProcess
    {
        public static void addProduct(string poliklinik,int kisi_id, string yapilan_islem,int dr_kod,int miktar,double birimf,bool taburcu)
        {
            string sql = "Insert into process(poliklinik,kisi_id,tarih,yapilan_islem,dr_kod,miktar,birim_fiyat,taburcu_mu) values (@poliklinik,@kisi_id,CURRENT_TIMESTAMP,@yapilan_islem,@dr_kod,@miktar,@birim_fiyat,@taburcu_mu)";

            using (SqlConnection connection = new SqlConnection(@"Data Source = BAHADIR; Initial Catalog = Hastane; Integrated Security = True"))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@poliklinik", poliklinik);
                    command.Parameters.AddWithValue("@kisi_id", kisi_id);
                    command.Parameters.AddWithValue("@yapilan_islem", yapilan_islem);
                    command.Parameters.AddWithValue("@dr_kod", dr_kod);
                    command.Parameters.AddWithValue("@miktar", miktar);
                    command.Parameters.AddWithValue("@birim_fiyat", birimf);
                    command.Parameters.AddWithValue("@taburcu_mu", taburcu);

                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Veri başarıyla eklendi.");
                    }
                    else
                    {
                        MessageBox.Show("Veri eklenirken bir hata oluştu.");
                    }
                }
            }
        }
        public static void addClient(int kisi_id, string kisi_ad, string kisi_soyad)
        {
            string sql = "Insert into client(kisi_id,kisi_ad,kisi_soyad) values (@kisi_id,@kisi_ad,@kisi_soyad)";

            using (SqlConnection connection = new SqlConnection(@"Data Source = BAHADIR; Initial Catalog = Hastane; Integrated Security = True"))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@kisi_id", kisi_id);
                    command.Parameters.AddWithValue("@kisi_ad", kisi_ad);
                    command.Parameters.AddWithValue("@kisi_soyad", kisi_soyad);

                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Veri başarıyla eklendi.");
                    }
                    else
                    {
                        MessageBox.Show("Veri eklenirken bir hata oluştu.");
                    }
                }
            }
        }
    }
}
