using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hastane
{
    class AllProcess
    {
        public static DataTable islem()
        {
            using (SqlConnection connection = new(@"Data Source = BAHADIR; Initial Catalog = Hastane; Integrated Security = True"))
            {
                string query = "SELECT * FROM process";

                using (SqlCommand command = new(query, connection))
                {

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
