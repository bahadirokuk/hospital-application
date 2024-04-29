using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hastane
{
    class SearchFile
    {
        public static DataTable fileno(int dosya_no)
        {
            using (SqlConnection connection = new(@"Data Source = BAHADIR; Initial Catalog = Hastane; Integrated Security = True"))
            {
                string query = "SELECT * FROM process WHERE dosya_no=@dosya_no";

                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@dosya_no", dosya_no);
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        return table;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata oluştu: " + ex.Message);
                        return null;
                    }
                }
            }
        }
        public static DataTable name(string poliklinik, string kisi_ad,string kisi_soyad)
        {
            using (SqlConnection connection = new(@"Data Source = BAHADIR; Initial Catalog = Hastane; Integrated Security = True"))
            {
                string query = "SELECT poliklinik,kisi_ad,kisi_soyad,tarih,yapilan_islem,dr_kod,miktar,birim_fiyat,taburcu_mu,dosya_no FROM process INNER JOIN client ON process.kisi_id = client.kisi_id WHERE client.kisi_ad=@kisi_ad and client.kisi_soyad=@kisi_soyad and process.poliklinik=@poliklinik";

                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@kisi_ad", kisi_ad);
                    command.Parameters.AddWithValue("@kisi_soyad", kisi_soyad);
                    command.Parameters.AddWithValue("@poliklinik", poliklinik);
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        return table;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata oluştu: " + ex.Message);
                        return null;
                    }
                }
            }
        }
    }
}
